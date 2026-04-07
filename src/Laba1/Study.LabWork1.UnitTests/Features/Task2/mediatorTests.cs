using System.Runtime.InteropServices.ObjectiveC;
using Xunit;
using Study.LabWork1.Features.Task2;
using Assert = Xunit.Assert;

namespace Study.LabWork1.Tests
{
    public class MockUser : User
    {
        public string? LastMessage { get; set; }

        public MockUser(Mediator mediator, string name) : base(mediator, name) { }

        public override void Notify(string message)
        {
            LastMessage = message;
        }

        public override void Send(string message) => _mediator.Send(message,  this);
    }

    public class MediatorTests
    {
        [Fact]
        public void Send_FromUser1_ShouldDeliverToUser2()
        {
            var mediator = new ConcreteMediator();
            var user1 = new MockUser(mediator, "User1");
            var user2 = new MockUser(mediator, "User2");
            mediator.user1 = user1;
            mediator.user2 = user2;
            const string message = "Hello from User1";

            user1.Send(message);

            Assert.Equal(message, user2.LastMessage);
            Assert.Null(user1.LastMessage);
        }

        [Fact]
        public void Send_FromUser2_ShouldDeliverToUser1()
        {
            var mediator = new ConcreteMediator();
            var user1 = new MockUser(mediator, "User1");
            var user2 = new MockUser(mediator, "User2");
            mediator.user1 = user1;
            mediator.user2 = user2;
            const string message = "Hello from User2";

            user2.Send(message);

            Assert.Equal(message, user1.LastMessage);
            Assert.Null(user2.LastMessage);
        }

        [Xunit.Theory]
        [InlineData("Привет")]
        [InlineData("Hello 123")]
        [InlineData("67")]
        public void Send_ShouldDeliverCorrectMessageContent(string message)
        {
            var mediator = new ConcreteMediator();
            var user1 = new MockUser(mediator, "User1");
            var user2 = new MockUser(mediator, "User2");
            mediator.user1 = user1;
            mediator.user2 = user2;
            string expected = message;

            user1.Send(expected);

            Assert.Equal(expected, user2.LastMessage);
            Assert.Null(user1.LastMessage);
        }

        [Fact]
        public void Send_WhenUser2IsNull_ThrowsNullReferenceException()
        {
            var mediator = new ConcreteMediator();
            var user1 = new MockUser(mediator, "User1");
            mediator.user1 = user1;
            mediator.user2 = null!;

            Assert.Throws<NullReferenceException>(() => user1.Send("Message"));
        }

        [Fact]
        public void Send_WhenUser1IsNull_ThrowsNullReferenceException()
        {
            var mediator = new ConcreteMediator();
            var user2 = new MockUser(mediator, "User2");
            mediator.user1 = null!;
            mediator.user2 = user2;

            Assert.Throws<NullReferenceException>(() => user2.Send("Message"));
        }
    }
}
