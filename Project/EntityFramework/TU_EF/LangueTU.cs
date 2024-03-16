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
    public class LangueTU
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

                var langue = new LangueEntity { name="name1"};

                context.Langues.Add(langue);
                context.SaveChanges();

                var test = context.Langues.FirstOrDefault(g => g.name == "name1");
                Assert.IsNotNull(test);
                Assert.AreEqual("name1", test.name);
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

                var langue = context.Langues.FirstOrDefault(g => g.name == "French");
                Assert.IsNotNull(langue);
                context.Langues.Remove(langue);
                context.SaveChanges();

                var test = context.Langues.FirstOrDefault(g => g.name == "French");
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
                Assert.IsNotNull(vocabulary);
                var langue = context.Langues.FirstOrDefault(g => g.name == "French");
                Assert.IsNotNull(langue);
                langue.vocabularys.Add(vocabulary);
                context.Langues.Update(langue);
                context.SaveChanges();

                var test = context.Langues.FirstOrDefault(g => g.name == "French");
                Assert.IsNotNull(test);
                Assert.AreEqual(vocabulary, test.vocabularys.FirstOrDefault());
            }
        }


    }
}
