using CQRS.Command;
using CQRS.CommandHandler;

namespace CQRS.Dispatcher;
public class CommandBus
{
    private Dictionary<Type, Object> _dictionary;

    public CommandBus()
    {
        _dictionary = new Dictionary<Type, Object>();
        _dictionary.Add(typeof(CreateUserCommand), new CreateUserCommandHandler());
    }

    public void Dispatch<TParameter>(TParameter command) where TParameter : NServiceBus.ICommand
    {
        RunCommand<TParameter>(command);
    }

    private void RunCommand<TParameter>(TParameter command) where TParameter : NServiceBus.ICommand
    {
        var commandHandler = (ICommandHandler<TParameter>) _dictionary[command.GetType()];

        commandHandler.Handle(command);
    }
}