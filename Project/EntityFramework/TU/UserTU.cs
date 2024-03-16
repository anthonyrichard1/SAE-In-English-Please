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
            var options = new DbContextOptionsBuilder<SAEContext>()
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
            var options = new DbContextOptionsBuilder<SAEContext>()
                                .UseSqlite(connection)
                                .Options;

            using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();

                var mockLogger = new Mock<ILogger<UserController>>();

                var controller = new UserController(new UserService(context), mockLogger.Object);


                var result2 = await controller.DeleteUser(1);

                Assert.IsNotNull(result2);
                Assert.AreEqual(1, result2.Value.Id);
                Assert.AreEqual("name", result2.Value.Name);
                Assert.AreEqual("", result2.Value.Email);
                Assert.AreEqual(true, result2.Value.ExtraTime);
                Assert.AreEqual(null, result2.Value.image);
                Assert.AreEqual("nickname", result2.Value.NickName);
                Assert.AreEqual("username", result2.Value.UserName);
                Assert.AreEqual(1, result2.Value.GroupId);
                Assert.AreEqual(1, result2.Value.RoleId);
                Assert.AreEqual("1234", result2.Value.Password);


                var res = await context.Users.FirstOrDefaultAsync(l => l.Id == result2.Value.Id);
                Assert.IsNull(res);
            }
        }
        [TestMethod]
        public async Task TestGetUser()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<SAEContext>()
                                .UseSqlite(connection)
                                .Options;

            using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();

                var mockLogger = new Mock<ILogger<UserController>>();

                var controller = new UserController(new UserService(context), mockLogger.Object);

                var result2 = await controller.GetUser(1);

                Assert.IsNotNull(result2);
                Assert.AreEqual(1, result2.Value.Id);
                Assert.AreEqual("name", result2.Value.Name);
                Assert.AreEqual("", result2.Value.Email);
                Assert.AreEqual(true, result2.Value.ExtraTime);
                Assert.AreEqual(null, result2.Value.image);
                Assert.AreEqual("nickname", result2.Value.NickName);
                Assert.AreEqual("username", result2.Value.UserName);
                Assert.AreEqual(1, result2.Value.GroupId);
                Assert.AreEqual(1, result2.Value.RoleId);
                Assert.AreEqual("1234", result2.Value.Password);
            }
        }

        [TestMethod]
        public async Task TestGetUsers()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<SAEContext>()
                                .UseSqlite(connection)
                                .Options;

            using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();

                var mockLogger = new Mock<ILogger<UserController>>();

                var controller = new UserController(new UserService(context), mockLogger.Object);

                var result = await controller.GetUsers(0,5);

                Assert.IsNotNull(result.Value);
                Assert.AreEqual(3, result.Value.TotalCount);
                Assert.AreEqual(1, result.Value.Items.First().Id);
                Assert.AreEqual("name", result.Value.Items.First().Name);
                Assert.AreEqual("", result.Value.Items.First().Email);
                Assert.AreEqual(true, result.Value.Items.First().ExtraTime);
                Assert.AreEqual(null, result.Value.Items.First().image);
                Assert.AreEqual("nickname", result.Value.Items.First().NickName);
                Assert.AreEqual("username", result.Value.Items.First().UserName);
                Assert.AreEqual(1, result.Value.Items.First().GroupId);
                Assert.AreEqual(1, result.Value.Items.First().RoleId);
                Assert.AreEqual("1234", result.Value.Items.First().Password);
            }
        }
        
        [TestMethod]
        public async Task TestGetUsersByGroup()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<SAEContext>()
                                .UseSqlite(connection)
                                .Options;

            using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();

                var mockLogger = new Mock<ILogger<UserController>>();

                var controller = new UserController(new UserService(context), mockLogger.Object);

                var result = await controller.GetUsersByGroup(0, 5, 1);

                Assert.IsNotNull(result.Value);
                Assert.AreEqual(3, result.Value.TotalCount);
                Assert.AreEqual(1, result.Value.Items.First().Id);
                Assert.AreEqual("name", result.Value.Items.First().Name);
                Assert.AreEqual("", result.Value.Items.First().Email);
                Assert.AreEqual(true, result.Value.Items.First().ExtraTime);
                Assert.AreEqual(null, result.Value.Items.First().image);
                Assert.AreEqual("nickname", result.Value.Items.First().NickName);
                Assert.AreEqual("username", result.Value.Items.First().UserName);
                Assert.AreEqual(1, result.Value.Items.First().GroupId);
                Assert.AreEqual(1, result.Value.Items.First().RoleId);
                Assert.AreEqual("1234", result.Value.Items.First().Password);
            }
        }

        [TestMethod]
        public async Task TestUpdateUser()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<SAEContext>()
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
            var options = new DbContextOptionsBuilder<SAEContext>()
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
