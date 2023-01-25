using CQRS.QueryResult;

namespace CQRS.QueryHandler;

public class UserByEmailUseCase
{
    public UserQueryResult Execute(string email)
    {
        //execute call to repository to check user by email
        Console.WriteLine("User email value");
        Console.WriteLine(email);
        var userQueryResult = new UserQueryResult();
        userQueryResult.userName = "Pepe";
        userQueryResult.email = email;
        userQueryResult.age = 18;
        return userQueryResult;
    }
}