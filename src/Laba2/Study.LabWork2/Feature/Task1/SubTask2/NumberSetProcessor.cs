using System.Diagnostics;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask2;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask2.DtoModels;

namespace Study.LabWork2.Feature.Task1.SubTask2;

/// <summary>
/// Определяет реализацию для процессора наборов чисел
/// </summary>
public sealed class NumberSetProcessor(List<int[]> dataSets,
    int maxThreadCount) : INumberSetProcessor
{
    private readonly List<int[]> _dataSets = dataSets;
    private readonly List<ResultEntryDto> _results = [];
    private int _totalSum = 0;
    private readonly object _locker = new();
    private readonly Mutex _mutex = new();
    private readonly Semaphore _semaphore = new(maxThreadCount, maxThreadCount);
    private TimeSpan _execTime = TimeSpan.Zero;



    public void Process()
    {
        var stopwatch = Stopwatch.StartNew();
        var threads = new List<Thread>();

        for (int i = 0; i < _dataSets.Count; i++)
        {
            int setNumber = i + 1;
            int[] data = _dataSets[i];

            var thread = new Thread(() => ProcessDataSet(setNumber, data));
            threads.Add(thread);
            thread.Start();
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }

        stopwatch.Stop();
        _execTime = stopwatch.Elapsed;
    }

    private void ProcessDataSet(int setNumber, int[] data)
    {
        _semaphore.WaitOne();

        try
        {
            int threadId = Thread.GetCurrentProcessorId();
            int sum = 0;

            foreach (int num in data)
            {
                sum += num;
            }

            lock (_locker)
            {
                _results.Add(new ResultEntryDto
                {
                    SetNumber = setNumber,
                    Sum = sum,
                    ThreadId = threadId
                });
            }

            _mutex.WaitOne();
            try
            {
                _totalSum += sum;
            }
            finally
            {
                _mutex.ReleaseMutex();
            }
        }
        finally
        {
            _semaphore.Release();
        }
    }

    public ProcessingResultDto GetResult()
    {
        return new ProcessingResultDto
        {
            Results = _results,
            TotalSum = _totalSum,
            ProcessedSetsCount = _results.Count,
            ExecutionTime = _execTime
        };
    }
}
