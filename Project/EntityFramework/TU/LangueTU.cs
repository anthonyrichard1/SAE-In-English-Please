using DbContextLib;
using Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using StubbedContextLib;

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
            var options = new DbContextOptionsBuilder<LibraryContext>()
                                .UseSqlite(connection)
                                .Options;
            using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();

                var newLangue = new LangueEntity { name = "français" , vocabularys=null };
                await context.Langues.AddAsync(newLangue);
                await context.SaveChangesAsync();

                var langue = await context.Langues.FirstOrDefaultAsync(b => b.name == "français");
                Assert.IsNotNull(langue);
                Assert.AreEqual("français", langue.name);
                Assert.IsNull(langue.vocabularys);


            }
        }
        [TestMethod]
        public async Task TestDeleteLangue()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<LibraryContext>()
                                .UseSqlite(connection)
                                .Options;
            using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();
                var vocab = new VocabularyEntity { word = "test", Langue = null };
                var newLangue = new LangueEntity { name = "français", vocabularys=[vocab] };
                vocab.Langue = newLangue;
                await context.Langues.AddAsync(newLangue);
                await context.SaveChangesAsync();

                var langue = await context.Langues.FirstOrDefaultAsync(b => b.name == "français");
                Assert.IsNotNull(langue);
                Assert.AreEqual("français", langue.name);
                Assert.AreEqual(vocab, langue.vocabularys.First());

                context.Langues.Remove(newLangue);
                await context.SaveChangesAsync();
                var langue2 = await context.Langues.FirstOrDefaultAsync(b => b.name == "français");
                Assert.IsNull(langue2);
            }
        }
        [TestMethod]
        public async Task TestUpdateLangue()
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

        [TestMethod]
        public async Task TestGetLangues()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<LibraryContext>()
                                .UseSqlite(connection)
                                .Options;
            using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();

                var langues = await context.Langues.ToListAsync();
                Assert.IsNotNull(langues);
                Assert.AreEqual(2, langues.Count);
                Assert.AreEqual("English", langues[0].name);
                Assert.AreEqual("French", langues[1].name);
            }
        }

        [TestMethod]
        public async Task TestGetLangue()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<LibraryContext>()
                                .UseSqlite(connection)
                                .Options;
            using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();

                var newLangue = new LangueEntity { name = "francais" };
                await context.Langues.AddAsync(newLangue);
                await context.SaveChangesAsync();

                var langue = await context.Langues.FirstOrDefaultAsync(b => b.name == "francais");
                Assert.IsNotNull(langue);
                Assert.AreEqual("francais", langue.name);
            }
        }
    }
}