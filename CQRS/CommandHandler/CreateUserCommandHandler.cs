using ConsoleApp1.Model;
using CQRS.Command;
using CQRS.Dto;

namespace CQRS.CommandHandler;

public class CreateUserCommandHandler : IHandleMessages<CreateUserCommand>
{
    private readonly CreateUserUseCase _createUserUseCase = new CreateUserUseCase();
    
    public Task Handle(CreateUserCommand command, IMessageHandlerContext context)
    {
        _createUserUseCase.Execute(command.UserName, command.Email, command.Age);
        Console.WriteLine("Message Recieved by CQRS command handler via NServiceBus");
        return Task.CompletedTask;
    }
}