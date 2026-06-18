using Study.LabWork1.Features.Task2;
using Study.LabWork1.Shared.Abstractions;

namespace Study.LabWork1.Shared.Services;

/// <summary>
/// Реализация заданий Л/Р
/// </summary>
public class RunService : IRunService
{
    /// <summary>
    /// Задание 1
    /// </summary>
    public void RunTask1() => throw new NotImplementedException();

    /// <summary>
    /// Задание 2
    /// </summary>
    public void RunTask2()
    {
        ConcreteMediator mediator = new();
        ConcreteUser programmer = new(mediator, "Programmer");
        ConcreteUser admin = new(mediator, "Admin");

        mediator.user1 = programmer;
        mediator.user2 = admin;

        programmer.Send("Hello from programmer");
        admin.Send("Hello from admin");
    }

    /// <summary>
    /// Задание 3
    /// </summary>
    public void RunTask3() => throw new NotImplementedException();
}
