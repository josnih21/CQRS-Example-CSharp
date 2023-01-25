using CQRS.Command;

namespace CQRS.CommandHandler;

public interface ICommandHandler<in TParameter> where TParameter : ICommand
{
    void Handle(TParameter command);
}