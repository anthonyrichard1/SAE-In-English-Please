using API.Controllers;
using DbContextLib;
using DTOToEntity;
using Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Logging;
using StubbedContextLib;
using DTO;
using Moq;

namespace TU
{
    [TestClass]
    public class LangueTU
    {

        [TestMethod]
        public async Task TestAddLangue()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<SAEContext>()
                                .UseSqlite(connection)
                                .Options;

            using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();

                // Créer un mock pour le logger
                var mockLogger = new Mock<ILogger<LangueController>>();

                var controller = new LangueController(new LangueService(context), mockLogger.Object);

                var newLangue = new LangueDTO { name = "test" };

                var result = await controller.AddLangue(newLangue);

                Assert.IsNotNull(result.Value);
                Assert.AreEqual(newLangue.name, result.Value.name);
            }
            
        }
        [TestMethod]
        public async Task TestDeleteLangue()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<SAEContext>()
                                .UseSqlite(connection)
                                .Options;

            using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();
                var newLangue = new LangueDTO { name = "test" };
                await context.Langues.AddAsync(newLangue.ToEntity());
                // Créer un mock pour le logger
                var mockLogger = new Mock<ILogger<LangueController>>();

                var controller = new LangueController(new LangueService(context), mockLogger.Object);


                var result = await controller.DeleteLangue("test");
                Assert.IsNotNull(result.Value);
                Assert.AreEqual(newLangue.name, result.Value.name);
                var res = await context.Langues.FirstOrDefaultAsync(l => l.name == "test");
                Assert.IsNull(res);

                
            }
        }

        [TestMethod]
        public async Task TestGetById()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<SAEContext>()
                                .UseSqlite(connection)
                                .Options;

            using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();
                var newLangue = new LangueDTO { name = "test" };
                await context.Langues.AddAsync(newLangue.ToEntity());
                // Créer un mock pour le logger
                var mockLogger = new Mock<ILogger<LangueController>>();

                var controller = new LangueController(new LangueService(context), mockLogger.Object);


                var result = await controller.GetLangue("test");
                Assert.IsNotNull(result.Value);
                Assert.AreEqual(newLangue.name, result.Value.name);
            }
        }

        [TestMethod]
        public async Task TestGetGroups()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<SAEContext>()
                                .UseSqlite(connection)
                                .Options;

            using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();
                var mockLogger = new Mock<ILogger<LangueController>>();

                var controller = new LangueController(new LangueService(context), mockLogger.Object);


                var result = await controller.GetLangues(0, 5);
                Assert.IsNotNull(result.Value);
                Assert.AreEqual(2, result.Value.TotalCount);
                Assert.AreEqual("English", result.Value.Items.ToList()[0].name);
                Assert.AreEqual("French", result.Value.Items.ToList()[1].name);

            }
        }
    }
}