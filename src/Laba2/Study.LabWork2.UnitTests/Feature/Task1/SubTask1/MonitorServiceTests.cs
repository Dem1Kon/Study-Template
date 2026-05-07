using Study.LabWork2.Feature.Task1.SubTask1;

namespace Study.LabWork2.UnitTests.Feature.Task1.SubTask1;

[TestFixture]
public sealed class MonitorServiceTests
{
    private MonitorService _monitorService;

    [SetUp]
    public void SetUp()
    {
        _monitorService = new MonitorService();
    }

    [Test]
    public void CountPrimes_WithValidRange_ReturnsCorrectPrimeCount()
    {
        // Arrange
        int start = 1;
        int end = 10000;
        int threadCount = 4;
        int expectedPrimeCount = 1229;

        // Act
        var result = _monitorService.CountPrimes(start, end, threadCount);

        // Assert
        Assert.That(result.PrimeCount, Is.EqualTo(1229));
    }


    [Test]
    public void CountPrimes_SingleThread_ReturnsCorrectPrimeCount()
    {
        // Arrange
        int start = 1;
        int end = 1000;
        int threadCount = 1;
        int expectedPrimeCount = 168; // 168 простых чисел от 1 до 1000

        // Act
        var result = _monitorService.CountPrimes(start, end, threadCount);

        // Assert
        Assert.That(result.PrimeCount, Is.EqualTo(expectedPrimeCount));
    }

    [Test]
    public void CountPrimes_SmallRange_ReturnsCorrectPrimeCount()
    {
        // Arrange
        int start = 1;
        int end = 100;
        int threadCount = 4;
        int expectedPrimeCount = 25; // 25 простых чисел от 1 до 100

        // Act
        var result = _monitorService.CountPrimes(start, end, threadCount);

        // Assert
        Assert.That(result.PrimeCount, Is.EqualTo(expectedPrimeCount));
    }

    [Test]
    public void CountPrimes_WithLargeThreadCount_CompletesSuccessfully()
    {
        // Arrange
        int start = 1;
        int end = 1000;
        int threadCount = 10;

        // Act
        var result = _monitorService.CountPrimes(start, end, threadCount);

        // Assert
        Assert.That(result.PrimeCount, Is.EqualTo(168));
    }
}
