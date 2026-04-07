namespace Study.LabWork1.Features.Task2;

public abstract class User
{
    protected string Name { get;}
    protected Mediator _mediator;

    protected User(Mediator mediator,  string name)
    {
        _mediator = mediator;
        Name = name;
    }

    public abstract void Send(string message);
    public abstract void Notify(string message);
}

public class ConcreteUser : User
{
    public ConcreteUser(Mediator mediator, string name) : base(mediator, name){}

    public override void Send(string message)
    {
        _mediator.Send(message, this);
    }

    public override void Notify(string message)
    {
        Console.WriteLine($"User {Name} got notification: {message}");
    }
}
