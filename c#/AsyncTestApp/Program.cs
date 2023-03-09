using System.Net;

namespace AsyncTestApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            var option = 2;

            Console.WriteLine($"elapsed Millis:{watch.ElapsedMilliseconds}");
            var fileUrl = "https://visualstudio.microsoft.com/keyboard-shortcuts.pdf";
            switch (option)
            {
                case 1:
                    // Sync Code
                    var data = downloadWebSiteSync(fileUrl);
                    Console.WriteLine($"Size of site {data.Length}");
                    break;
                case 2:
                    data = await downloadWebSiteAsync(fileUrl);
                    Console.WriteLine($"Size of site {data.Length}");
                    break;
            }
            Console.WriteLine($"elapsed Millis:{watch.ElapsedMilliseconds}");
        }

        public static string downloadWebSiteSync(string websiteString)
        {
            WebClient client = new WebClient();
            var data = client.DownloadString(websiteString);
            return data;
        }

        public static async Task<string> downloadWebSiteAsync(string websiteString)
        {
            var data = await Task.Run(() => downloadWebSiteSync(websiteString));
            return data;
        }
    }


}