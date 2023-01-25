using CQRS.Dto;

namespace CQRS.Command;

public class CreateUserCommand : ICommand
{
    public string UserName { get; }
    public int Age { get; }
    public string Email { get; }

    public CreateUserCommand(string userName, int age, string email)
    {
        UserName = userName;
        Age = age;
        Email = email;
    }
}