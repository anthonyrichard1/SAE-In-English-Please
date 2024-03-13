using DbContextLib;
using Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StubbedContextLib;
using API.Controllers;
using DTOToEntity;
using DTO;
using Moq;

namespace TU
{
    [TestClass]
    public class GroupTU
    {



        [TestMethod]
        public async Task TestGetGroups()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<LibraryContext>()
                                .UseSqlite(connection)
                                .Options;

            using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();

                GroupEntity g1 = new GroupEntity { Id = 3, Num = 1, sector = "sect3", year = 2020 };
                await context.Groups.AddAsync(g1);
                await context.Groups.AddAsync(new GroupEntity { Id = 4, Num = 2, sector = "sect4" });
                await context.SaveChangesAsync();

                // Créer un mock pour le logger
                var mockLogger = new Mock<ILogger<GroupController>>();

                var controller = new GroupController(new GroupService(context), mockLogger.Object);

                var result = await controller.GetGroups(0, 5);

                Assert.IsNotNull(result.Value.Items.ToArray());
                Assert.AreEqual(3, result.Value.TotalCount);
                Assert.AreEqual(g1.Num, result.Value.Items.First().Num);
            }
        }



        [TestMethod]
        public async Task TestGetGroup()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<LibraryContext>()
                                .UseSqlite(connection)
                                .Options;

            using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();

                GroupEntity g1 = new GroupEntity { Id = 3, Num = 1, sector = "sect3", year = 2020 };
                await context.Groups.AddAsync(g1);
                await context.SaveChangesAsync();

                // Créer un mock pour le logger
                var mockLogger = new Mock<ILogger<GroupController>>();

                var controller = new GroupController(new GroupService(context), mockLogger.Object);

                var result = await controller.GetGroup(3);

                Assert.IsNotNull(result.Value);
                Assert.AreEqual(g1.Id, result.Value.Id);
            }
        }


        [TestMethod]
        public async Task TestAddGroup()
        {
            // Créer une connexion SQLite en mémoire
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<LibraryContext>()
                                .UseSqlite(connection)
                                .Options;

            using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();

                // Créer un mock pour le logger
                var mockLogger = new Mock<ILogger<GroupController>>();

                var controller = new GroupController(new GroupService(context), mockLogger.Object);

                var newGroupDTO = new GroupDTO { Id = 0, Num = 3, sector = "sect5", Year = 2022 };

                var result = await controller.AddGroup(newGroupDTO);

                Assert.IsNotNull(result.Value);
                Assert.AreEqual(newGroupDTO.Num, result.Value.Num);
                Assert.AreEqual(newGroupDTO.sector, result.Value.sector);
                Assert.AreEqual(newGroupDTO.Year, result.Value.Year); 
            }
        }

        [TestMethod]
        public async Task TestDeleteGroup()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<LibraryContext>()
                                .UseSqlite(connection)
                                .Options;

            using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();

                GroupEntity g1 = new GroupEntity { Id = 3, Num = 1, sector = "sect3", year = 2020 };
                await context.Groups.AddAsync(g1);
                await context.SaveChangesAsync();

                var mockLogger = new Mock<ILogger<GroupController>>();

                var controller = new GroupController(new GroupService(context), mockLogger.Object);

                var result = await controller.DeleteGroup(3);

                Assert.IsNotNull(result.Value);
                Assert.AreEqual(g1.Num, result.Value.Num);
            }
        }


        [TestMethod]
        public async Task TestUpdateGroup()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<LibraryContext>()
                                .UseSqlite(connection)
                                .Options;
            using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();
                GroupEntity g1 = new GroupEntity { Id = 4, Num = 4, sector = "sect3", year = 2020 };
                GroupDTO updatedGroupDTO = new GroupDTO { Id = 4, Num = 2, sector = "sect4", Year = 2021 };
                await context.Groups.AddAsync(g1);
                await context.SaveChangesAsync();

                var mockLogger = new Mock<ILogger<GroupController>>();
                var controller = new GroupController(new GroupService(context), mockLogger.Object);

                var result = await controller.UpdateGroup(updatedGroupDTO);

                Assert.IsNotNull(result.Value);
                Assert.AreEqual(updatedGroupDTO.Num, result.Value.Num);
                Assert.AreEqual(updatedGroupDTO.sector, result.Value.sector);
                Assert.AreEqual(updatedGroupDTO.Year, result.Value.Year);
            }
        }

        [TestMethod]
        public async Task TestGetGroupsByNum()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<LibraryContext>()
                                .UseSqlite(connection)
                                .Options;

            using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();

                await context.Groups.AddRangeAsync(
                    new GroupEntity { Id = 3, Num = 10, sector = "sect1", year = 2021 },
                    new GroupEntity { Id = 4, Num = 2, sector = "sect2", year = 2021 },
                    new GroupEntity { Id = 5, Num = 10, sector = "sect1", year = 2022 }
                );
                await context.SaveChangesAsync();

                var mockLogger = new Mock<ILogger<GroupController>>();

                var controller = new GroupController(new GroupService(context), mockLogger.Object);

                var result = await controller.GetGroupsByNum(0, 5, 10);

                Assert.IsNotNull(result.Value);
                Assert.AreEqual(2, result.Value.Items.Count());
            }
        }
        [TestMethod]
        public async Task TestGetGroupsBySector()
        {
            // Créer une connexion SQLite en mémoire
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<LibraryContext>()
                                .UseSqlite(connection)
                                .Options;

            using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();

                await context.Groups.AddRangeAsync(
                    new GroupEntity { Id = 3, Num = 1, sector = "sect1", year = 2021 },
                    new GroupEntity { Id = 4, Num = 2, sector = "sect2", year = 2021 },
                    new GroupEntity { Id = 5, Num = 1, sector = "sect1", year = 2022 }
                );
                await context.SaveChangesAsync();

                var mockLogger = new Mock<ILogger<GroupController>>();

                var controller = new GroupController(new GroupService(context), mockLogger.Object);

                var result = await controller.GetGroupsBySector(0, 5, "sect1");

                Assert.IsNotNull(result.Value);
                Assert.AreEqual(2, result.Value.Items.Count());
            }
        }

        [TestMethod]
        public async Task TestGetGroupsByYear()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<LibraryContext>()
                                .UseSqlite(connection)
                                .Options;

            using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();

                await context.Groups.AddRangeAsync(
                    new GroupEntity { Id = 3, Num = 1, sector = "sect1", year = 2021 },
                    new GroupEntity { Id = 4, Num = 2, sector = "sect2", year = 2021 },
                    new GroupEntity { Id = 5, Num = 1, sector = "sect1", year = 2022 }
                );
                await context.SaveChangesAsync();

                var mockLogger = new Mock<ILogger<GroupController>>();

                var controller = new GroupController(new GroupService(context), mockLogger.Object);

                var result = await controller.GetGroupsByYear(0, 5, 2021);

                Assert.IsNotNull(result.Value);
                Assert.AreEqual(2, result.Value.Items.Count());
            }
        }

    }
}