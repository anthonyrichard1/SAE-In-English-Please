using API.Controllers;
using DbContextLib;
using DTO;
using DTOToEntity;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using StubbedContextLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TU
{
    [TestClass]
    public class TranslateTU
    {
        [TestMethod]
        public async Task TestAddTranslate()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<SAEContext>()
                                .UseSqlite(connection)
                                .Options;

            using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();

                var mockLogger = new Mock<ILogger<TranslateController>>();

                var controller = new TranslateController(new TranslateService(context), mockLogger.Object);

                var newTranslate = new TranslateDTO { Id = 2, WordsId = "test", VocabularyListVocId = 1 };

                var result = await controller.AddTranslate(newTranslate);

                Assert.IsNotNull(result.Value);
                Assert.AreEqual(newTranslate.Id, result.Value.Id);
                Assert.AreEqual(newTranslate.WordsId, result.Value.WordsId);
                Assert.AreEqual(newTranslate.VocabularyListVocId, result.Value.VocabularyListVocId);
            }
        }


        [TestMethod]
        public async Task TestGetTranslate()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<SAEContext>()
                                .UseSqlite(connection)
                                .Options;

            using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();

                var mockLogger = new Mock<ILogger<TranslateController>>();

                var controller = new TranslateController(new TranslateService(context), mockLogger.Object);


                var result = await controller.GetTranslate(1);
                Assert.IsNotNull(result.Value);
                Assert.AreEqual(1, result.Value.Id);
                Assert.AreEqual("1", result.Value.WordsId);
                Assert.AreEqual(1, result.Value.VocabularyListVocId);
            }
        }
        [TestMethod]
        public async Task TestGetTranslates()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<SAEContext>()
                                .UseSqlite(connection)
                                .Options;

            using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();

                var mockLogger = new Mock<ILogger<TranslateController>>();

                var controller = new TranslateController(new TranslateService(context), mockLogger.Object);
                var result = await controller.GetTranslates(0, 1);
                Assert.IsNotNull(result.Value);
                Assert.AreEqual(1, result.Value.TotalCount);
                Assert.AreEqual(1, result.Value.Items.ToList()[0].Id);
                Assert.AreEqual("1", result.Value.Items.ToList()[0].WordsId);
                Assert.AreEqual(1, result.Value.Items.ToList()[0].VocabularyListVocId);
            }
        }

        [TestMethod]
        public async Task TestUpdateTranslate()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<SAEContext>()
                                .UseSqlite(connection)
                                .Options;

            using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();

                var mockLogger = new Mock<ILogger<TranslateController>>();

                var controller = new TranslateController(new TranslateService(context), mockLogger.Object);
                var newTranslate = await context.Translates.FirstOrDefaultAsync(t => t.Id == 1);
                newTranslate.WordsId = "modifié";
                var result = await controller.UpdateTranslate(newTranslate.ToDTO());
                Assert.IsNotNull(result.Value);
                Assert.AreEqual(1, result.Value.Id);
                Assert.AreEqual("modifié", result.Value.WordsId);
                Assert.AreEqual(1, result.Value.VocabularyListVocId);
            }
        }
        [TestMethod]
        public async Task TestDeleteTranslate()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<SAEContext>()
                                .UseSqlite(connection)
                                .Options;

            using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();

                var mockLogger = new Mock<ILogger<TranslateController>>();

                var controller = new TranslateController(new TranslateService(context), mockLogger.Object);
                var result = await controller.DeleteTranslate(1);
                Assert.IsNotNull(result.Value);
                Assert.AreEqual(1, result.Value.Id);
                Assert.AreEqual("1", result.Value.WordsId);
                Assert.AreEqual(1, result.Value.VocabularyListVocId);
                var res = await context.Translates.FirstOrDefaultAsync(t => t.Id == 1);
                Assert.IsNull(res);
            }
        }

        [TestMethod]
        public async Task TestAddVocabToTranslate()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<SAEContext>()
                                .UseSqlite(connection)
                                .Options;

            using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();

                var mockLogger = new Mock<ILogger<TranslateController>>();

                var controller = new TranslateController(new TranslateService(context), mockLogger.Object);
                var result = await controller.AddVocab("Bonjour", 1);
                Assert.IsNotNull(result.Value);
                Assert.AreEqual("Bonjour", result.Value.word);

                var res = await context.Translates.FirstOrDefaultAsync(v => v.Id == 1);
                Assert.IsNotNull(res);
                var test = res.TransVoc.FirstOrDefault(t => t.word == "Bonjour");
                Assert.IsNotNull(test);
                Assert.AreEqual("Bonjour", test.word);

                var test2 = await context.TransVoc.FirstOrDefaultAsync(t => t.word == "Bonjour");
                Assert.IsNotNull(test2);
                Assert.AreEqual("Bonjour", test2.word);

            }
        }
    }
}
