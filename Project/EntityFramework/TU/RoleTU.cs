using API.Controllers;
using DbContextLib;
using DTO;
using DTOToEntity;
using Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
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

                var mockLogger = new Mock<ILogger<RoleController>>();

                var controller = new RoleController(new RoleService(context), mockLogger.Object);

                var newRole = new RoleDTO { Id = 100, Name = "test" };

                var result = await controller.AddRole(newRole);

                Assert.IsNotNull(result.Value);
                //ici on met 4 pour verifier que le Id n'est pas celui que l'on donne mais bien : CountList + 1
                Assert.AreEqual(4, result.Value.Id);
                Assert.AreEqual("test", result.Value.Name);
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

                var mockLogger = new Mock<ILogger<RoleController>>();

                var controller = new RoleController(new RoleService(context), mockLogger.Object);

                var newRole = new RoleDTO { Id = 4, Name = "test" };
                await controller.AddRole(newRole);
                var newRole2 = new RoleDTO { Id = 4, Name = "modifié" };
                await controller.UpdateRole(newRole2);
                var res = await context.Roles.FirstOrDefaultAsync(r =>r.Id == 4);
                Assert.IsNotNull(res);
                Assert.AreEqual(4, res.Id);
                Assert.AreEqual("modifié", res.Name);
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

                var mockLogger = new Mock<ILogger<RoleController>>();

                var controller = new RoleController(new RoleService(context), mockLogger.Object);

                var newRole = new RoleDTO { Id = 4, Name = "test" };
                await context.Roles.AddAsync(newRole.ToEntity());
                await context.SaveChangesAsync();
                var result = await controller.DeleteRole(4);
                Assert.IsNotNull(result.Value);
                Assert.AreEqual(4, result.Value.Id);
                Assert.AreEqual("test", result.Value.Name);
            }
        }

    }
}