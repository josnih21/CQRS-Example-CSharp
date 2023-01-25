namespace CQRS.Repository;

public class UserReadRepository
{
    private List<QueryUserDTO> _queryUserDtos = new List<QueryUserDTO>();

    public string FindUserName(string email)
    {
        var name = _queryUserDtos
            .Find(value => value.Email == email)?
            .Name;
        return name;
    }
}

class QueryUserDTO
{
    public string Email { get; set; }
    public string Name { get; set; }
}