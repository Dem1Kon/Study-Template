using Study.LabWork2.Abstractions.Feature.Task1.SubTask1.DtoModels;

namespace Study.LabWork2.Feature.Task1.SubTask1.DtoModels;

public interface IPrimeCounter
{
    PrimeCountResultDto CountPrimes(int start, int end, int threadCount);
}
