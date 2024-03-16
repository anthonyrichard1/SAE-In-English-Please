using DbContextLib;
using Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using StubbedContextLib;

namespace TU_EF
{
    [TestClass]
    public class GroupTU
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

                var group = new GroupEntity { Id = 2, Num = 1 , sector="sector1", year=2024 };

                context.Groups.Add(group);
                context.SaveChanges();

                var test = context.Groups.FirstOrDefault(g => g.Id == 2);
                Assert.IsNotNull(test);
                Assert.AreEqual(1, test.Num);
                Assert.AreEqual(2, test.Id);
                Assert.AreEqual("sector1", test.sector);
                Assert.AreEqual(2024, test.year);
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

                var group = new GroupEntity { Id = 2, Num = 1, sector = "sector1", year = 2024 };

                context.Groups.Add(group);
                context.SaveChanges();

                context.Groups.Remove(group);
                context.SaveChanges();

                var test = context.Groups.FirstOrDefault(g => g.Id == 2);
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

                var group = new GroupEntity { Id = 2, Num = 1, sector = "sector1", year = 2024 };

                context.Groups.Add(group);
                context.SaveChanges();

                group.Num = 2;
                context.Groups.Update(group);
                context.SaveChanges();

                var test = context.Groups.FirstOrDefault(g => g.Id == 2);
                Assert.IsNotNull(test);
                Assert.AreEqual(2, test.Num);
            }
        }
    }
}