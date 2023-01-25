namespace CQRS.Repository;

public class UserReadRepository
{
    public static List<QueryUserDto> queryUserDtos = new List<QueryUserDto>();

    public string FindUserName(string email)
    {
        var name = queryUserDtos
            .Find(value => value.Email == email)?
            .Name;
        return name;
    }
}

public class QueryUserDto
{
    public QueryUserDto(string email, string name)
    {
        Email = email;
        Name = name;
    }

    public string Email { get; }
    public string Name { get; }
}