using DurableTask.Core;

namespace SampleTestDTF
{
    public class DownloadActivity : AsyncTaskActivity<string, string>
    {
        protected override async Task<string> ExecuteAsync(TaskContext context, string input)
        {
            Console.WriteLine("Downloading file" + input + " started.");

            //var result = await new HttpClient().GetStringAsync("http://212.183.159.230/5MB.zip");

            int seconds = 360;
            await Task.Delay(seconds*1000);

            Console.WriteLine("Downloading file " + input + " complete.");

            return "";
        }
    }
}
