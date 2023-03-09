// See https://aka.ms/new-console-template for more information

using Azure.Storage.Blobs;
using DurableTask.AzureStorage;
using DurableTask.Core;
using SampleTestDTF;
using System.Diagnostics;

namespace AzureDTFDemo
{
    public class Program 
    {
        static string connectionString = "DefaultEndpointsProtocol=https;AccountName=dtf01;AccountKey=JRczYzCDeccB0yrx6qZg4TTqFpPh+Qa0oypN37xMFdisRyxclp9TOubcDIP84anA7uUE/sH/VPoD+AStscGTgw==;EndpointSuffix=core.windows.net";
        static string dconnectionString = "DefaultEndpointsProtocol=https;AccountName=deepakresources8569;AccountKey=szybUyKX/0oFZeJuzDEBV8ZHqW8wg+x2+J1RMSCTVNIx6mVZd3kJZ10MgRpEZw1qRjIYF/yq08bU+AStSf2Elw==;EndpointSuffix=core.windows.net";
        static string containerName = "dc1";
        static string folderPath = @"c:\Temp\";
        static int count = 20;

        public static void Main(string[] args)
        {
            Program program = new Program();

            Task task = program.DTF();
            // uploadFilesToAzure();
            
            Console.ReadLine();
        }

        private void uploadFilesToAzure()
        {
            var files = Directory.GetFiles(folderPath, "*", SearchOption.AllDirectories);

            BlobContainerClient containerClient = new BlobContainerClient(connectionString, containerName);

            foreach (var file in files)
            {
                var filePathOverCloud = file.Replace(folderPath, string.Empty);
                using (MemoryStream stream = new MemoryStream(File.ReadAllBytes(file)))
                {
                    containerClient.UploadBlob(filePathOverCloud, stream);
                    Console.WriteLine(filePathOverCloud + " Uploaded!!");
                }
            }
        }

        public async Task DTF()
        {
            var orchestratorService = new AzureStorageOrchestrationService(new AzureStorageOrchestrationServiceSettings()
            {
                StorageConnectionString = dconnectionString,
                TaskHubName = "dtf",
                MaxConcurrentTaskOrchestrationWorkItems = 5,MaxConcurrentTaskActivityWorkItems = 5
            });

            var taskHubClient = new TaskHubClient(orchestratorService);
            TaskHubWorker taskHubWorker = new TaskHubWorker(orchestratorService)
                .AddTaskOrchestrations(typeof(EncodeVideoOrchestration))
                .AddTaskActivities(typeof(EncodeActivity), typeof(EmailActivity), typeof(DownloadActivity), typeof(CopyActivity))
                .StartAsync().GetAwaiter().GetResult();

            //Console.WriteLine("Stared orchestration submission.");
            Stopwatch regularSW = new Stopwatch();
            regularSW.Restart();
            for (int i =0;i<count;i++)
            {
                var instance = await taskHubClient.CreateOrchestrationInstanceAsync(typeof(EncodeVideoOrchestration), i.ToString() );
                //Console.WriteLine($"Created Orchestration orchestration submission.{instance.ToString()}");
            }

            regularSW.Stop();
            //Console.WriteLine("Ended orchestration submission. Time taken: " + regularSW.Elapsed.ToString(@"m\:ss\.fff"));
            Console.ReadLine();
        }
    }
}