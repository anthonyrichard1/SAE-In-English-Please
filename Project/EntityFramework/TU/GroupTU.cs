using DbContextLib;
using Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using StubbedContextLib;

namespace TU
{
    [TestClass]
    public class GroupTU
    {
        [TestMethod]
        public async Task TestAddGroup()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<LibraryContext>()
                                .UseSqlite(connection)
                                .Options;
            using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();

                var newBook = new GroupEntity { Id = 2, year = 2, sector = "medecin" };
                await context.Groups.AddAsync(newBook);
                await context.SaveChangesAsync();

                var group1 = await context.Groups.FirstOrDefaultAsync(b => b.sector == "medecin");
                Assert.IsNotNull(group1);
                Assert.AreEqual("medecin", group1.sector);
                Assert.AreEqual(2, group1.year);
                Assert.AreEqual(2, group1.Id);


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

                var newBook = new GroupEntity { Id = 2, year = 2, sector = "medecin" };
                await context.Groups.AddAsync(newBook);
                await context.SaveChangesAsync();

                var group1 = await context.Groups.FirstOrDefaultAsync(b => b.sector == "medecin");
                Assert.IsNotNull(group1);
                Assert.AreEqual("medecin", group1.sector);
                Assert.AreEqual(2, group1.year);
                Assert.AreEqual(2, group1.Id);

                context.Groups.Remove(group1);
                await context.SaveChangesAsync();
                var group2 = await context.Groups.FirstOrDefaultAsync(b => b.sector == "medecin");
                Assert.IsNull(group2);
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

                var newBook = new GroupEntity { Id = 2, year = 2, sector = "medecin" };
                await context.Groups.AddAsync(newBook);
                await context.SaveChangesAsync();

                var group1 = await context.Groups.FirstOrDefaultAsync(b => b.sector == "medecin");
                Assert.IsNotNull(group1);
                Assert.AreEqual("medecin", group1.sector);
                Assert.AreEqual(2, group1.year);
                Assert.AreEqual(2, group1.Id);

                group1.sector = "informatique";
                group1.year = 3;
                context.Groups.Update(group1);
                await context.SaveChangesAsync();
                var group2 = await context.Groups.FirstOrDefaultAsync(b => b.sector == "informatique");
                Assert.IsNotNull(group2);
                Assert.AreEqual("informatique", group2.sector);
                Assert.AreEqual(3, group2.year);
                Assert.AreEqual(2, group2.Id);
            }
        }
    }
}