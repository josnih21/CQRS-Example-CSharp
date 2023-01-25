using CQRS.Command;
using CQRS.CommandHandler;

namespace CQRS.Dispatcher;
public class CommandBus
{
    //TODO: Check if we can check TParams type from class
    private Dictionary<Type, Object> _dictionary;

    public CommandBus()
    {
        _dictionary = new Dictionary<Type, Object>();
        _dictionary.Add(typeof(CreateUserCommand), new CreateUserCommandHandler());
    }

    public void Dispatch<TParameter>(TParameter command) where TParameter : ICommand
    {
        RunCommand<TParameter>(command);
    }

    private void RunCommand<TParameter>(TParameter command) where TParameter : ICommand
    {
        var commandHandler = (ICommandHandler<TParameter>) _dictionary[command.GetType()];

        commandHandler.Handle(command);
    }
}