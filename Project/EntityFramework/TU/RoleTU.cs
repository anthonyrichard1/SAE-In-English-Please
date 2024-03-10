using DbContextLib;
using Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using StubbedContextLib;

namespace TU
{
    [TestClass]
    public class RoleTU
    {
        [TestMethod]
        public async Task TestAddRole()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<LibraryContext>()
                                .UseSqlite(connection)
                                .Options;
            using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();
                var user = new UserEntity { Id = 1, Name = "name", UserName = "username", NickName = "nickname", ExtraTime = true, GroupId = 1, Password = "1234", Email = "" };
                var newRole = new RoleEntity { Id=4, Name = "user" , Users = [user]  };
                await context.Roles.AddAsync(newRole);
                await context.SaveChangesAsync();

                var role = await context.Roles.FirstOrDefaultAsync(b => b.Name == "user");
                Assert.IsNotNull(role);
                Assert.AreEqual("user", role.Name);
                Assert.AreEqual(user, role.Users.First());
            }
        }
        [TestMethod]
        public async Task TestUpdateRole()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<LibraryContext>()
                                .UseSqlite(connection)
                                .Options;
            using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();
                var user = new UserEntity { Id = 4, Name = "name", UserName = "username", NickName = "nickname", ExtraTime = true, GroupId = 1, Password = "1234", Email = "", RoleId=5 };
                var user1 = new UserEntity { Id = 5, Name = "name2", UserName = "username2", NickName = "nickname2", ExtraTime = true, GroupId = 2, Password = "1234", Email = "", RoleId=5 };
                var newRole = new RoleEntity { Id=5,Name = "user" };
                newRole.Users.Add(user);
                await context.Roles.AddAsync(newRole);
                await context.SaveChangesAsync();

                var role = await context.Roles.FirstOrDefaultAsync(b => b.Name == "user");
                Assert.AreEqual(newRole, role);
                role.Name = "admin";
                context.Roles.Update(role); 

                await context.SaveChangesAsync();
                var role1 = await context.Roles.FirstOrDefaultAsync(b => b. Name == "admin");
                Assert.IsNotNull(role1);
                Assert.AreEqual("admin", role1.Name);
                Assert.AreEqual(user, role1.Users.First());
            }
        }

        [TestMethod]
        public async Task TestDeleteRole()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<LibraryContext>()
                                .UseSqlite(connection)
                                .Options;
            using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();

                var newRole = new RoleEntity { Name = "user" };
                await context.Roles.AddAsync(newRole);
                await context.SaveChangesAsync();

                var role = await context.Roles.FirstOrDefaultAsync(b => b.Name == "user");
                context.Roles.Remove(role);
                await context.SaveChangesAsync();
                var role1 = await context.Roles.FirstOrDefaultAsync(b => b.Name == "user");
                Assert.IsNull(role1);
            }
        }
    }

}