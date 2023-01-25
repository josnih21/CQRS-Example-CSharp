using CQRS.Event;

namespace CQRS.EventHandler;

public class UserCreatedEventHandler : IEventHandler<UserCreatedEvent>
{
    public void Handle(UserCreatedEvent @event)
    {
        new UserSynchronizer().sync(@event.UserName, @event.Email);
    }
}