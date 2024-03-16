using DbContextLib;
using Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using StubbedContextLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TU_EF
{
    [TestClass]
    public class UserTU
    {
        [TestMethod]
            public void TestAdd()
        {
                var connection = new SqliteConnection("DataSource=:memory:");
                connection.Open();
                var options = new DbContextOptionsBuilder<SAEContext>()
                                    .UseSqlite(connection)
                                    .Options;
    
                using (var context = new StubbedContext(options))
            {
                    context.Database.EnsureCreated();

                var newUser = new UserEntity { Id = 100, Name = "test", Email = "e", ExtraTime = false, image = "img", NickName = "nick", Password = "pass", UserName = "username", GroupId = 1, RoleId = 2 };
                context.Users.Add(newUser);
                    context.SaveChanges();
    
                    var test = context.Users.FirstOrDefault(g => g.Id == newUser.Id);
                    Assert.IsNotNull(test);
                Assert.AreEqual("test", test.Name);
                Assert.AreEqual("e", test.Email);
                Assert.AreEqual(false, test.ExtraTime);
                Assert.AreEqual("img", test.image);
                Assert.AreEqual("nick", test.NickName);
                Assert.AreEqual("pass", test.Password);
                Assert.AreEqual("username", test.UserName);
                Assert.AreEqual(1, test.GroupId);
                Assert.AreEqual(2, test.RoleId);
                }
            }

        [TestMethod]
            public void TestDelete()
        {
                var connection = new SqliteConnection("DataSource=:memory:");
                connection.Open();
                var options = new DbContextOptionsBuilder<SAEContext>()
                                    .UseSqlite(connection)
                                    .Options;
    
                using (var context = new StubbedContext(options))
            {
                    context.Database.EnsureCreated();
    
                    var user = context.Users.FirstOrDefault(g => g.Id == 1);
                    Assert.IsNotNull(user);
                    context.Users.Remove(user);
                    context.SaveChanges();
                    var test = context.Users.FirstOrDefault(g => g.Id == 1);
                    Assert.IsNull(test);
                }
            }

        [TestMethod]
            public void TestUpdate()
        {
                var connection = new SqliteConnection("DataSource=:memory:");
                connection.Open();
                var options = new DbContextOptionsBuilder<SAEContext>()
                                    .UseSqlite(connection)
                                    .Options;
    
                using (var context = new StubbedContext(options))
            {
                    context.Database.EnsureCreated();
    
                    var user = context.Users.FirstOrDefault(g => g.Id == 1);
                    Assert.IsNotNull(user);
                    user.Name = "test2";
                    user.Email = "e2";
                    user.ExtraTime = true;
                    user.image = "img2";
                    context.Users.Update(user);
                    context.SaveChanges();
                    var test = context.Users.FirstOrDefault(g => g.Id == 1);
                    Assert.IsNotNull(test);
                    Assert.AreEqual("test2", test.Name);
                    Assert.AreEqual("e2", test.Email);
                    Assert.AreEqual(true, test.ExtraTime);
                    Assert.AreEqual("img2", test.image);


                }
            }



    }
}
