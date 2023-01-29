namespace CQRS.Event;

public class UserCreatedEvent : NServiceBus.IEvent
{
    public string UserName { get; }
    public string Email { get; }
    public int Age { get; }

    public UserCreatedEvent(string userName, string email, int age)
    {
        UserName = userName;
        Email = email;
        Age = age;
    }
}