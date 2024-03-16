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
    public class VocabularyTU
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

                var vocabulary = new VocabularyEntity { word="Baguette", LangueName="French"};

                context.Vocabularys.Add(vocabulary);
                context.SaveChanges();

                var test = context.Vocabularys.FirstOrDefault(g => g.word == "Baguette");
                Assert.IsNotNull(test);
                Assert.AreEqual("Baguette", test.word);
                Assert.AreEqual("French", test.LangueName);
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

                var vocabulary = context.Vocabularys.FirstOrDefault(g => g.word == "Bonjour");
                Assert.IsNotNull(vocabulary);
                context.Vocabularys.Remove(vocabulary);
                context.SaveChanges();

                var test = context.Vocabularys.FirstOrDefault(g => g.word == "Bonjour");
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

                var vocabulary = context.Vocabularys.FirstOrDefault(g => g.word == "Bonjour");
                vocabulary.LangueName = "English";

                context.SaveChanges();

                var test = context.Vocabularys.FirstOrDefault(g => g.word == "Bonjour");
                Assert.IsNotNull(test);
                Assert.AreEqual("English", test.LangueName);
            }
        }

    }
}
