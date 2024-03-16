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
            var options = new DbContextOptionsBuilder<SAEContext>()
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
                var test = await context.Roles.FirstOrDefaultAsync(r => r.Id == 4);
                Assert.IsNotNull(test);
            }
        }

        [TestMethod]
        public async Task TestDeleteRole()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<SAEContext>()
                                .UseSqlite(connection)
                                .Options;

            using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();

                var mockLogger = new Mock<ILogger<RoleController>>();

                var controller = new RoleController(new RoleService(context), mockLogger.Object);

                var result = await controller.DeleteRole(3);
                Assert.IsNotNull(result.Value);
                Assert.AreEqual(3, result.Value.Id);
                Assert.AreEqual("Student", result.Value.Name);
                var test = await context.Roles.FirstOrDefaultAsync(r => r.Id == 3);
                Assert.IsNull(test);
            }
        }
        [TestMethod]
        public async Task TestGetRole()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<SAEContext>()
                                .UseSqlite(connection)
                                .Options;

            using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();

                var mockLogger = new Mock<ILogger<RoleController>>();

                var controller = new RoleController(new RoleService(context), mockLogger.Object);

                var result = await controller.GetRole(3);
                Assert.IsNotNull(result.Value);
                Assert.AreEqual(3, result.Value.Id);
                Assert.AreEqual("Student", result.Value.Name);
            }
        }

        [TestMethod]
        public async Task TestGetRoles()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<SAEContext>()
                                .UseSqlite(connection)
                                .Options;

            using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();

                var mockLogger = new Mock<ILogger<RoleController>>();

                var controller = new RoleController(new RoleService(context), mockLogger.Object);

                var result = await controller.GetRoles(0, 5);
                Assert.IsNotNull(result.Value);
                Assert.AreEqual(3, result.Value.TotalCount);
                Assert.AreEqual(3, result.Value.Items.ToList()[2].Id);
                Assert.AreEqual("Student", result.Value.Items.ToList()[2].Name);
            }
        }

    }
}