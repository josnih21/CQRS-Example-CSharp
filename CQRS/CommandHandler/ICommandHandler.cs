using CQRS.Command;

namespace CQRS.CommandHandler;

public interface ICommandHandler<in TParameter> where TParameter : NServiceBus.ICommand
{
    void Handle(TParameter command);
}