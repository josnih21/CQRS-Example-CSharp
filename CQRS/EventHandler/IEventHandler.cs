using CQRS.Event;

namespace CQRS.EventHandler;

public interface IEventHandler <in TParameter> where TParameter : IEvent
{
    void Handle(TParameter @event);
}