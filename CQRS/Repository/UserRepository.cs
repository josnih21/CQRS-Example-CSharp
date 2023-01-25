using MongoDB.Bson;
using System;
namespace CQRS.Repository;
using MongoDB.Driver;
public class UserRepository
{

    public void GetAllDocuments()
    {
        MongoClient client = new MongoClient("mongodb://localhost:27017");
        var dbList = client.ListDatabases().ToList();
        
        Console.WriteLine("Values: ");
        foreach (var value in dbList)
        {
            Console.WriteLine(value);
        }
    }
}