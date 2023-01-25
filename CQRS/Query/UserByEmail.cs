namespace CQRS.Query;

public class UserByEmail : IQuery
{
    public string Email { get; }

    public UserByEmail(string email)
    {
        Email = email;
    }
}