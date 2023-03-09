using DurableTask.Core;

namespace SampleTestDTF
{
    public class CopyActivity : AsyncTaskActivity<string, string>
    {

        protected override async Task<string> ExecuteAsync(TaskContext context, string input)
        {

            string source = "C:\\Users\\deepak.MININT-IDR02K3\\Documents\\Bills.zip";
            string target = $"C:\\Users\\deepak.MININT-IDR02K3\\Documents\\temp\\dtffolder\\Bills{input}.zip";

            Console.WriteLine("Copying file" + input[0] + " to "+ input[1] + " started.");
            await CopyFileAsync(source, target);

            Console.WriteLine("Copying file" + input[0] + " to " + input[1] + " completed.");
            return "fine";
        }

        public async Task CopyFileAsync(string sourcePath, string destinationPath)
        {
            using (Stream source = File.Open(sourcePath, FileMode.Open))
            {
                using (Stream destination = File.Create(destinationPath))
                {
                    await source.CopyToAsync(destination);
                }
            }
        }

    }


}
