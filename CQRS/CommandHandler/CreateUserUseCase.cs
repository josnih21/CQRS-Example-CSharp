using ConsoleApp1.Model;
using CQRS.Repository;

namespace CQRS.CommandHandler;

public class CreateUserUseCase
{
    private readonly UserRepository _userRepository = new UserRepository();
    public void Execute(string userName, string email, int age)
    {
        var user = new User
        {
            userName = userName,
            email = email,
            age = age
        };

        Console.WriteLine("Handling the command to write into the database");
        //_userRepository.GetAllDocuments();
        //Now I should call my repository to write directly into the write model
    }
}