namespace Study.LabWork2.Feature.Task1.SubTask1.DtoModels;

public interface IPrimeCounter
{
    PrimeCountResultDto CountPrimes(int start, int end, int threadCount);
}

public class PrimeCountResultDto(int count, long elapsedMs)
{
    public int Counter { get; private set; } = count;
    public long Elapsed { get; private set; } = elapsedMs;
}
