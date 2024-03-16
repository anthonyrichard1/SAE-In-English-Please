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
    public class TranslateTU
    {

        [TestMethod]
        public async Task TestAdd()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<SAEContext>()
                                .UseSqlite(connection)
                                .Options;

            using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();

                var translate = new TranslateEntity { Id = 2, WordsId="Bonjour" , VocabularyListVocId=1 };
                context.Translates.Add(translate);
                await context.SaveChangesAsync();
                var test = context.Translates.FirstOrDefault(g => g.Id == 2);

                Assert.IsNotNull(test);
                Assert.AreEqual("Bonjour", test.WordsId);
                Assert.AreEqual(1, test.VocabularyListVocId);
            }
        }

        [TestMethod]
        public async Task TestDelete()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<SAEContext>()
                                .UseSqlite(connection)
                                .Options;

            using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();
                var translate = context.Translates.FirstOrDefault(g => g.Id == 1);
                Assert.IsNotNull(translate);
                context.Translates.Remove(translate);
                await context.SaveChangesAsync();
                var test = context.Translates.FirstOrDefault(g => g.Id == 1);
                Assert.IsNull(test);

            }
        }

        [TestMethod]
        public async Task TestUpdate()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<SAEContext>()
                                .UseSqlite(connection)
                                .Options;

            using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();
                var translate = context.Translates.FirstOrDefault(g => g.Id == 1);
                Assert.IsNotNull(translate);
                translate.WordsId = "Hello";
                await context.SaveChangesAsync();
                var test = context.Translates.FirstOrDefault(g => g.Id == 1);
                Assert.IsNotNull(test);
                Assert.AreEqual("Hello", test.WordsId);
                
            }
        }
    }
}
