using API.Controllers;
using DbContextLib;
using DTO;
using DTOToEntity;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using StubbedContextLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TU
{
    [TestClass]
    public class UserTU
    {

        [TestMethod]

        public async Task TestAddUser()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<LibraryContext>()
                                .UseSqlite(connection)
                                .Options;

            using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();

                var mockLogger = new Mock<ILogger<UserController>>();

                var controller = new UserController(new UserService(context), mockLogger.Object);

                var newUser = new UserDTO { Id = 100, Name = "test", Email = "e", ExtraTime = false, image = "img", NickName = "nick", Password = "pass", UserName = "username", GroupId = 1, RoleId = 2 };

                var result = await controller.AddUser(newUser);

                Assert.IsNotNull(result);
                Assert.AreEqual(newUser.Id, result.Value.Id);
                Assert.AreEqual(newUser.Name, result.Value.Name);
                Assert.AreEqual(newUser.Email, result.Value.Email);
            }
        }
        [TestMethod]
        public async Task TestDeleteUser()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<LibraryContext>()
                                .UseSqlite(connection)
                                .Options;

            using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();

                var mockLogger = new Mock<ILogger<UserController>>();

                var controller = new UserController(new UserService(context), mockLogger.Object);

                var newUser = new UserDTO { Id = 4, Name = "test", Email = "e", ExtraTime = false, image = "img", NickName = "nick", Password = "pass", UserName = "username", GroupId = 1, RoleId = 2 };

                var result = await controller.AddUser(newUser);

                Assert.IsNotNull(result);
                Assert.AreEqual(newUser.Id, result.Value.Id);
                Assert.AreEqual(newUser.Name, result.Value.Name);
                Assert.AreEqual(newUser.Email, result.Value.Email);

                var result2 = await controller.DeleteUser(newUser.Id);

                Assert.IsNotNull(result2);
                Assert.AreEqual(newUser.Id, result2.Value.Id);
                Assert.AreEqual(newUser.Name, result2.Value.Name);
                Assert.AreEqual(newUser.Email, result2.Value.Email);

                var res = await context.Users.FirstOrDefaultAsync(l => l.Id == newUser.Id);
                Assert.IsNull(res);
            }
        }
        [TestMethod]
        public async Task TestGetUser()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<LibraryContext>()
                                .UseSqlite(connection)
                                .Options;

            using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();

                var mockLogger = new Mock<ILogger<UserController>>();

                var controller = new UserController(new UserService(context), mockLogger.Object);

                var newUser = new UserDTO { Id = 100, Name = "test", Email = "e", ExtraTime = false, image = "img", NickName = "nick", Password = "pass", UserName = "username", GroupId = 1, RoleId = 2 };

                var result = await controller.AddUser(newUser);

                Assert.IsNotNull(result);
                Assert.AreEqual(newUser.Id, result.Value.Id);
                Assert.AreEqual(newUser.Name, result.Value.Name);
                Assert.AreEqual(newUser.Email, result.Value.Email);

                var result2 = await controller.GetUser(newUser.Id);

                Assert.IsNotNull(result2);
                Assert.AreEqual(newUser.Id, result2.Value.Id);
                Assert.AreEqual(newUser.Name, result2.Value.Name);
                Assert.AreEqual(newUser.Email, result2.Value.Email);
            }
        }

        [TestMethod]
        public async Task TestGetUsers()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<LibraryContext>()
                                .UseSqlite(connection)
                                .Options;

            using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();

                var mockLogger = new Mock<ILogger<UserController>>();

                var controller = new UserController(new UserService(context), mockLogger.Object);

                var newUser = new UserDTO { Id = 4, Name = "test", Email = "e", ExtraTime = false, image = "img", NickName = "nick", Password = "pass", UserName = "username", GroupId = 1, RoleId = 2 };
                context.Users.Add(newUser.ToEntity());
                await context.SaveChangesAsync();
                var result = await controller.GetUsers(0,5);

                Assert.IsNotNull(result);
                Assert.AreEqual(4, result.Value.TotalCount);
                Assert.AreEqual(4, result.Value.Items.Last().Id);
                Assert.AreEqual(newUser.Name, result.Value.Items.Last().Name);
                Assert.AreEqual(newUser.Email, result.Value.Items.Last().Email);
            }
        }
        
        [TestMethod]
        public async Task TestGetUsersByGroup()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<LibraryContext>()
                                .UseSqlite(connection)
                                .Options;

            using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();

                var mockLogger = new Mock<ILogger<UserController>>();

                var controller = new UserController(new UserService(context), mockLogger.Object);

                var newUser = new UserDTO { Id = 4, Name = "test", Email = "e", ExtraTime = false, image = "img", NickName = "nick", Password = "pass", UserName = "username", GroupId = 1, RoleId = 2 };
                context.Users.Add(newUser.ToEntity());
                context.SaveChanges();
                var result = await controller.GetUsersByGroup(0, 5, 1);

                Assert.IsNotNull(result);
                Assert.AreEqual(4, result.Value.TotalCount);
                Assert.AreEqual(newUser.Id, result.Value.Items.Last().Id);
                Assert.AreEqual(newUser.Name, result.Value.Items.Last().Name);
                Assert.AreEqual(newUser.Email, result.Value.Items.Last().Email);
            }
        }

        [TestMethod]
        public async Task TestUpdateUser()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<LibraryContext>()
                                .UseSqlite(connection)
                                .Options;

            using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();
                var newUser = new UserDTO { Id = 4, Name = "test", Email = "e", ExtraTime = false, image = "img", NickName = "nick", Password = "pass", UserName = "username", GroupId = 1, RoleId = 2 };

                var newUser2 = new UserDTO { Id = 4, Name = "test2", Email = "e2", ExtraTime = false, image = "img2", NickName = "nick2", Password = "pass2", UserName = "username2", GroupId = 1, RoleId = 3 };

                var mockLogger = new Mock<ILogger<UserController>>();

                var controller = new UserController(new UserService(context), mockLogger.Object);


                var result = await controller.AddUser(newUser);

                Assert.IsNotNull(result);
                Assert.AreEqual(newUser.Id, result.Value.Id);
                Assert.AreEqual(newUser.Name, result.Value.Name);
                Assert.AreEqual(newUser.Email, result.Value.Email);


                var result2 = await controller.UpdateUser(newUser2);

                Assert.IsNotNull(result2.Value);
                Assert.AreEqual(newUser2.Id, result2.Value.Id);
                Assert.AreEqual(newUser2.Name, result2.Value.Name);
                Assert.AreEqual(newUser2.Email, result2.Value.Email);
                Assert.AreEqual(newUser2.ExtraTime, result2.Value.ExtraTime);
                Assert.AreEqual(newUser2.image, result2.Value.image);
                Assert.AreEqual(newUser2.NickName, result2.Value.NickName);
                Assert.AreEqual(newUser2.Password, result2.Value.Password);
                Assert.AreEqual(newUser2.UserName, result2.Value.UserName);
                Assert.AreEqual(newUser2.GroupId, result2.Value.GroupId);
                Assert.AreEqual(newUser2.RoleId, result2.Value.RoleId);
            }
        }

        [TestMethod]
        public async Task TestGetUsersByRole()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<LibraryContext>()
                                .UseSqlite(connection)
                                .Options;

            using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();

                var mockLogger = new Mock<ILogger<UserController>>();

                var controller = new UserController(new UserService(context), mockLogger.Object);

                var result = await controller.GetUsersByRole(0, 5, "Student");

                Assert.IsNotNull(result.Value);
                Assert.AreEqual(3, result.Value.TotalCount);
                Assert.AreEqual(3, result.Value.Items.ToList()[0].Id) ;
                Assert.AreEqual("name3", result.Value.Items.Last().Name);
                Assert.AreEqual("", result.Value.Items.Last().Email);
            }
        }
        

    }
}
