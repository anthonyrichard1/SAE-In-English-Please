// See https://aka.ms/new-console-template for more information
using DbContextLib;
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

}