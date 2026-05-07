using Study.LabWork2.Feature.Task1.SubTask1;

namespace Study.LabWork2;

public static class Program
{
    public static void Main()
    {
        var monitorService = new MonitorService();
        var result = monitorService.CountPrimes(1, 10000, 5);

        Console.WriteLine($"Found {result.Counter} digits in {result.Elapsed}ms");
    }
}
