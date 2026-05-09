using Study.LabWork2.Feature.Task1.SubTask2;

namespace Study.LabWork2;

public static class Program
{
    static void Main()
    {
        var dataSets = LoadDataSets("datasets.txt");

        int maxThreadCount = 3;
        var processor = new NumberSetProcessor(dataSets, maxThreadCount);

        processor.Process();
        var result = processor.GetResult();

        foreach (var entry in result.Results)
            Console.WriteLine(entry);

        Console.WriteLine($"\nResults: {result.TotalSum}");
        Console.WriteLine($"Execution Time: {result.ExecutionTime.TotalMilliseconds} ms");
    }

    static List<int[]> LoadDataSets(string filePath)
    {
        var dataSets = new List<int[]>();
        var lines = File.ReadAllLines(filePath);

        foreach (var line in lines)
        {
            var numbers = line.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            dataSets.Add(numbers);
        }

        return dataSets;
    }
}
