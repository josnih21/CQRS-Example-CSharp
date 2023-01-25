using ConsoleApp1.Model;
using CQRS.Event;
using CQRS.Repository;
using CQRS.EventBus;

namespace CQRS.CommandHandler;

public class CreateUserUseCase
{
    private readonly UserWriteRepository _userWriteRepository = new UserWriteRepository();
    private readonly DomainEventBus _eventBus = new DomainEventBus();

    public void Execute(string userName, string email, int age)
    {
        var user = new User
        {
            userName = userName,
            email = email,
            age = age
        };

        _eventBus.Dispatch(new UserCreatedEvent (user.userName, user.email, user.age));
        Console.WriteLine("Handling the command to write into the database");
        _userWriteRepository.createUser(user);
    }
}