using ConsoleApp1.Model;
using CQRS.Command;
using CQRS.Dto;

namespace CQRS.CommandHandler;

public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
{
    private readonly CreateUserUseCase _createUserUseCase = new CreateUserUseCase();

    public void Handle(CreateUserCommand command)
    {
        _createUserUseCase.Execute(command.UserName, command.Email, command.Age);
    }
}