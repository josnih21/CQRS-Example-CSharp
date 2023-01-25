using CQRS.QueryResult;
using CQRS.Repository;

namespace CQRS.QueryHandler;

public class UserByEmailUseCase
{
    private readonly UserReadRepository _userReadRepository = new UserReadRepository();
    public String Execute(string email)
    {
        //execute call to repository to check user by email
        Console.WriteLine("User email value");
        Console.WriteLine(email);
        
        return _userReadRepository.FindUserName(email);
    }
}