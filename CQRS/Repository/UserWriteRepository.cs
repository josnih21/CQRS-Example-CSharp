using MongoDB.Bson;
using System;
using ConsoleApp1.Model;

namespace CQRS.Repository;
using MongoDB.Driver;
public class UserWriteRepository
{
    private List<User> users = new List<User>()
    {
        new User{age = 25, email = "josnih@leanmind.es", userName = "Jose Angel"},
        new User{age = 31, email = "jonay.goday@leanmind.es", userName = "Jonay"},
    };

    public void createUser(User user)
    {
        users.Add(user);
    }
}