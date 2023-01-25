using CQRS.Event;
using CQRS.EventHandler;

namespace CQRS.EventBus;

public class DomainEventBus
{
    //TODO: Check if we can check TParams type from class
    private Dictionary<Type, Object> _dictionary;

    public DomainEventBus()
    {
        _dictionary = new Dictionary<Type, Object>();
        _dictionary.Add(typeof(UserCreatedEvent), new UserCreatedEventHandler());
    }

    public void Dispatch<TParameter>(TParameter @event) where TParameter : IEvent
    {
        RunEvent<TParameter>(@event);
    }

    private void RunEvent<TParameter>(TParameter @event) where TParameter : IEvent
    {
        var eventHandler = (IEventHandler<TParameter>) _dictionary[@event.GetType()];

        eventHandler.Handle(@event);
    }
}

//TODO: Rename Interfaces without I