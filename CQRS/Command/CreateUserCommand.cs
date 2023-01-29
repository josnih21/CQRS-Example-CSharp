using CQRS.Dto;

namespace CQRS.Command;

public class CreateUserCommand : ICommand
{
    public string UserName { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }

    public CreateUserCommand(string userName, int age, string email)
    {
        UserName = userName;
        Age = age;
        Email = email;
    }
    
    public CreateUserCommand(){}
}