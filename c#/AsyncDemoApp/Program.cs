// C# program
using System;
using System.Threading;
public class Program
{
    static async Task Main(string[] args)
    {
        await GetUrlContentLengthAsync();

    }

    public static async Task<int> GetUrlContentLengthAsync()
    {

        Console.WriteLine("Getting string...");

        Task<int> count = someAsyncTask();
        DoIndependentWork();

        int contents = await count;

        return contents;
    }

    static void DoIndependentWork()
    {
        Console.WriteLine("DoIndependentWork...");
    }

    static async Task<int> someAsyncTask()
    {
        Console.WriteLine("AsyncTask");
        Console.WriteLine("AsyncTask");
        Console.WriteLine("AsyncTask");
        Console.WriteLine("AsyncTask");
        Console.WriteLine("AsyncTask");
        var client = new HttpClient();

        Task<string> getStringTask =
            client.GetStringAsync("https://docs.microsoft.com/dotnet");
        string str = await getStringTask;
        Console.WriteLine("Going to finish");
        return str.Length;
    }
}

