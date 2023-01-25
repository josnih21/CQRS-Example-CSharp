using CQRS.Repository;

namespace CQRS.EventHandler;


/// <summary>
/// We may call directly from this layer to the reading database to sync the data from the Writing model
/// </summary>
public class UserSynchronizer
{
    public void sync(string eventUserName, string eventEmail)
    {
        UserReadRepository.queryUserDtos.Add(new QueryUserDto(eventEmail, eventUserName));
    }

    public void syncAll()
    {
        var writeUsers = UserWriteRepository.users;
        writeUsers.ForEach(value => UserReadRepository.queryUserDtos.Add(new QueryUserDto(value.email, value.userName)));
    }
}