using CQRS.Event;

namespace CQRS.EventHandler;

public interface IEventHandler <in TParameter>
{
    void Handle(TParameter @event);
}