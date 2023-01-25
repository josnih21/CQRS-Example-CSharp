using ConsoleApp1.Model;
using CQRS.Repository;

namespace CQRS.CommandHandler;

public class CreateUserUseCase
{
    private readonly UserWriteRepository _userWriteRepository = new UserWriteRepository();
    public void Execute(string userName, string email, int age)
    {
        var user = new User
        {
            userName = userName,
            email = email,
            age = age
        };

        Console.WriteLine("Handling the command to write into the database");
        _userWriteRepository.createUser(user);
    }
}