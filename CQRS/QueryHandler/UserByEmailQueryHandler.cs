using ConsoleApp1.Model;
using CQRS.Query;
using CQRS.QueryResult;

namespace CQRS.QueryHandler;

public class UserByEmailQueryHandler : IQueryHandler<String, UserByEmail>
{
    private readonly UserByEmailUseCase _userByEmailUseCase = new UserByEmailUseCase();


    public void RunQuery(UserByEmail query)
    {
        Handle(query);
    }

    public String Handle(UserByEmail query)
    {
        var queryResult = _userByEmailUseCase.Execute(query.Email);
        return queryResult;
    }
}