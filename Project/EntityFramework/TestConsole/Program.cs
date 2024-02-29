// See https://aka.ms/new-console-template for more information
using DbContextLib;
using Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using StubbedContextLib;


Console.WriteLine("Hello, World!");


var connection = new SqliteConnection("DataSource=:memory:");
connection.Open();
var options = new DbContextOptionsBuilder<LibraryContext>()
                    .UseSqlite(connection)
                    .Options;
using (var context = new StubbedContext(options))
{
    context.Database.EnsureCreated();
    Console.WriteLine("Database created");

    var users = context.Users.ToList();
    Console.WriteLine("Users: " + users.Count);
    var roles = context.Roles.ToList();
    Console.WriteLine("Roles: " + roles.Count);

    Console.WriteLine("5 first Users : " );
    foreach ( var user in context.Users.Take(5))
    {
        Console.WriteLine(user.toString());
    }

    var user1 = new UserEntity
    {
        Name = "name4",
        UserName = "username4",
        NickName = "nickname4",
        ExtraTime = true,
        GroupId = 4,
        Password = "12344",
        Email = ""
    };

    context.Users.Add(user1);
    context.SaveChanges();

    Console.WriteLine("5 first Users : ");
    foreach (var user in context.Users.Take(5))
    {
        Console.WriteLine(user.toString());
    }




}