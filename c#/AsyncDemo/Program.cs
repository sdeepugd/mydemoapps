public class Program
{
    static void Main(string[] args)
    {
        Program p = new Program();
        p.MakeTeaAsync();
    }

    public async Task<string> MakeTeaAsync()
    {
        var boilingWater = BoilWaterAsync();

        Console.WriteLine("take the cups out");

        var a = 0;
        for (int i = 0; i < 100_000_000; i++)
        {
            a += i;
        }

        Console.WriteLine("put tea in cups");

        var water = await boilingWater;

        var tea = $"pour {water} in cups";

        Console.WriteLine($"{tea}");

        return tea;
    }

    public async Task<string> BoilWaterAsync()
    {
        Console.WriteLine("Start the kettle");

        Console.WriteLine("waiting for the kettle");
        await Task.Delay(300);

        Console.WriteLine("kettle finished boiling");

        return "water";
    }

    public string MakeTea()
    {
        var water = BoilWater();

        Console.WriteLine("take the cups out");

        Console.WriteLine("put tea in cups");

        var tea = $"pour {water} in cups";
        Console.WriteLine($"{tea}");
        return tea;
    }

    public string BoilWater()
    {
        Console.WriteLine("Start the kettle");

        Console.WriteLine("waiting for the kettle");
        Task.Delay(2000).GetAwaiter().GetResult();

        Console.WriteLine("kettle finished boiling");

        return "water";
    }

}