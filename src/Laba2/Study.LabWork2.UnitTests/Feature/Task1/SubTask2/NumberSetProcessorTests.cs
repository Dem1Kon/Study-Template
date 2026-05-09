using Study.LabWork2.Feature.Task1.SubTask2;

namespace Study.LabWork2.UnitTests.Feature.Task1.SubTask2;

[TestFixture]
public sealed class NumberSetProcessorTests
{
    private const string TestDataFilePath = "test_datasets.txt";
    private List<int[]> _testDataSets;

    [SetUp]
    public void SetUp()
    {
        _testDataSets = new List<int[]>
        {
            new[] { 1, 2, 3, 4, 5 },           // сумма = 15
            new[] { 10, 20, 30, 40, 50 },      // сумма = 150
            new[] { 2, 4, 6, 8, 10 }           // сумма = 30
        };
    }

    [Test]
    public void Process_CompletesSuccessfully()
    {
        // Arrange
        var processor = new NumberSetProcessor(_testDataSets, 2);

        // Act
        processor.Process();
        var result = processor.GetResult();

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.ProcessedSetsCount, Is.EqualTo(3));
    }

    [Test]
    public void Process_CorrectlyCalculatesAllSums()
    {
        // Arrange
        var expectedSums = new[] { 15, 150, 30 };
        var processor = new NumberSetProcessor(_testDataSets, 2);

        // Act
        processor.Process();
        var result = processor.GetResult();

        // Assert
        var actualSums = result.Results.Select(r => r.Sum).OrderBy(s => s).ToArray();
        Assert.That(actualSums, Is.EqualTo(expectedSums.OrderBy(s => s).ToArray()));
    }

    [Test]
    public void Process_CorrectlyCalculatesTotalSum()
    {
        // Arrange
        int expectedTotalSum = 15 + 150 + 30; // 195
        var processor = new NumberSetProcessor(_testDataSets, 2);

        // Act
        processor.Process();
        var result = processor.GetResult();

        // Assert
        Assert.That(result.TotalSum, Is.EqualTo(expectedTotalSum));
    }

    [Test]
    public void GetResult_AfterProcessing_ReturnsAllResults()
    {
        // Arrange
        var processor = new NumberSetProcessor(_testDataSets, 2);

        // Act
        processor.Process();
        var result = processor.GetResult();

        // Assert
        Assert.That(result.Results, Is.Not.Null);
        Assert.That(result.Results.Count, Is.EqualTo(3));
        Assert.That(result.TotalSum, Is.EqualTo(195));
        Assert.That(result.ProcessedSetsCount, Is.EqualTo(3));
        Assert.That(result.ExecutionTime.TotalMilliseconds, Is.GreaterThan(0));
    }

    [Test]
    public void GetResult_BeforeProcessing_ReturnsEmptyResults()
    {
        // Arrange
        var processor = new NumberSetProcessor(_testDataSets, 2);

        // Act
        var result = processor.GetResult();

        // Assert
        Assert.That(result.Results, Is.Not.Null);
        Assert.That(result.Results.Count, Is.EqualTo(0));
        Assert.That(result.TotalSum, Is.EqualTo(0));
        Assert.That(result.ProcessedSetsCount, Is.EqualTo(0));
    }

    [Test]
    public void Process_WithLargeNumberOfDataSets_CompletesSuccessfully()
    {
        // Arrange: создаём 15 наборов по 100 чисел
        var random = new Random();
        var largeDataSets = new List<int[]>();
        for (int i = 0; i < 15; i++)
        {
            var numbers = new int[100];
            for (int j = 0; j < 100; j++)
                numbers[j] = random.Next(1, 101);
            largeDataSets.Add(numbers);
        }
        var processor = new NumberSetProcessor(largeDataSets, 4);

        // Act
        processor.Process();
        var result = processor.GetResult();

        // Assert
        Assert.That(result.ProcessedSetsCount, Is.EqualTo(15));
    }

    [Test]
    public void Process_ExecutionTimeIsMeasured()
    {
        // Arrange
        var processor = new NumberSetProcessor(_testDataSets, 2);

        // Act
        processor.Process();
        var result = processor.GetResult();

        // Assert
        Assert.That(result.ExecutionTime.TotalMilliseconds, Is.GreaterThan(0));
    }

}
