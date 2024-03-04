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
        public async Task TestGetRoles()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<LibraryContext>()
                                .UseSqlite(connection)
                                .Options;
            using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();

                var roles = await context.Roles.ToListAsync();
                Assert.IsNotNull(roles);
                Assert.AreEqual(3, roles.Count);
                Assert.AreEqual("Admin", roles[0].Name);
            }
        }
        [TestMethod]
        public async Task TestGetRole()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
                   connection.Open();
                   var options = new DbContextOptionsBuilder<LibraryContext>()
                                               .UseSqlite(connection)
                                               .Options;
                   using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();

                var newRole = new RoleEntity { Id = 4, Name = "user" };
                await context.Roles.AddAsync(newRole);
                await context.SaveChangesAsync();

                var role1 = await context.Roles.FirstOrDefaultAsync(b => b.Name == "user");
                Assert.IsNotNull(role1);
                Assert.AreEqual("user", role1.Name);
                Assert.AreEqual(4, role1.Id);
            }
        }
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

                var newRole = new RoleEntity { Name = "user" };
                await context.Roles.AddAsync(newRole);
                await context.SaveChangesAsync();

                var role = await context.Roles.FirstOrDefaultAsync(b => b.Name == "user");
                Assert.IsNotNull(role);
                Assert.AreEqual("user", role.Name);
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

                var newRole = new RoleEntity { Name = "user" };
                await context.Roles.AddAsync(newRole);
                await context.SaveChangesAsync();

                var role = await context.Roles.FirstOrDefaultAsync(b => b.Name == "user");
                role.Name = "admin";
                context.Roles.Update(role);
                await context.SaveChangesAsync();
                var role1 = await context.Roles.FirstOrDefaultAsync(b => b. Name == "admin");
                Assert.IsNotNull(role1);
                Assert.AreEqual("admin", role1.Name);
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