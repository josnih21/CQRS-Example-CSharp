using CQRS.Event;

namespace CQRS.EventHandler;

public class UserCreatedEventHandler : IHandleMessages<UserCreatedEvent>
{
    public Task Handle(UserCreatedEvent message, IMessageHandlerContext context)
    {
        new UserSynchronizer().sync(message.UserName, message.Email);
        Console.WriteLine("Received Event when user created");
        return Task.CompletedTask;
    }
}