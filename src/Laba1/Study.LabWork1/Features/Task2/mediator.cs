using System.Reflection.Metadata;

namespace Study.LabWork1.Features.Task2;

public abstract class Mediator
{
    public abstract void Send(string message, User user);
}

public class ConcreteMediator : Mediator
{
    public User user1{get;set;}
    public User user2{get;set;}
    public override void Send(string msg, User user)
    {
        if (user1 == user)
            user2.Notify(msg);
        else
            user1.Notify(msg);
    }
}
