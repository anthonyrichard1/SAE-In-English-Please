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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TU
{
    [TestClass]
    public class VocabularyTU
    {

        [TestMethod]
        public async Task TestAddVocabulary()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<LibraryContext>()
                                .UseSqlite(connection)
                                .Options;

            using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();

                var mockLogger = new Mock<ILogger<VocabularyController>>();

                var controller = new VocabularyController(new VocabularyService(context), mockLogger.Object);

                var newVocab = new VocabularyDTO { LangueName = "French", word = "baguette" };
                var result = await controller.AddVocabulary(newVocab);
                Assert.IsNotNull(result.Value);
                var res = context.Vocabularys.FirstOrDefault(v => v.word == result.Value.word);
                Assert.IsNotNull(res);
                Assert.AreEqual(newVocab.LangueName, res.LangueName);
                Assert.AreEqual(newVocab.word, res.word);

            }
        }

        [TestMethod]
            public async Task TestDeleteVocabulary()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<LibraryContext>()
                                .UseSqlite(connection)
                                .Options;

            using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();

                var mockLogger = new Mock<ILogger<VocabularyController>>();

                var controller = new VocabularyController(new VocabularyService(context), mockLogger.Object);

                var newVocab = new VocabularyDTO { LangueName = "French", word = "baguette" };
                var result = await controller.AddVocabulary(newVocab);
                Assert.IsNotNull(result.Value);
                var res = context.Vocabularys.FirstOrDefault(v => v.word == result.Value.word);
                Assert.IsNotNull(res);
                var delResult = await controller.DeleteVocabulary(res.word);
                Assert.IsNotNull(delResult.Value);
                var delRes = context.Vocabularys.FirstOrDefault(v => v.word == delResult.Value.word);
                Assert.IsNull(delRes);
            }
        }

        [TestMethod]
        public async Task TestGetVocabulary()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<LibraryContext>()
                                .UseSqlite(connection)
                                .Options;

            using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();

                var mockLogger = new Mock<ILogger<VocabularyController>>();

                var controller = new VocabularyController(new VocabularyService(context), mockLogger.Object);

                var newVocab = new VocabularyDTO { LangueName = "French", word = "baguette" };
                var result = await controller.AddVocabulary(newVocab);
                Assert.IsNotNull(result.Value);
                var res = context.Vocabularys.FirstOrDefault(v => v.word == result.Value.word);
                Assert.IsNotNull(res);
                var getResult = await controller.GetVocabulary(res.word);
                Assert.IsNotNull(getResult.Value);
                Assert.AreEqual(res.word, getResult.Value.word);
                Assert.AreEqual(res.LangueName, getResult.Value.LangueName);
            }
        }

        [TestMethod]
        public async Task TestGetVocabularies()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<LibraryContext>()
                                .UseSqlite(connection)
                                .Options;

            using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();

                var mockLogger = new Mock<ILogger<VocabularyController>>();

                var controller = new VocabularyController(new VocabularyService(context), mockLogger.Object);

                var getResult = await controller.GetVocabularies(0, 10);
                Assert.IsNotNull(getResult.Value);
                Assert.AreEqual(1, getResult.Value.TotalCount);
                Assert.AreEqual("Bonjour", getResult.Value.Items.Last().word);
                Assert.AreEqual("French", getResult.Value.Items.Last().LangueName);
            }
        }

        [TestMethod]
        public async Task TestUpdateVocabulary()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<LibraryContext>()
                                .UseSqlite(connection)
                                .Options;

            using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();

                var mockLogger = new Mock<ILogger<VocabularyController>>();

                var controller = new VocabularyController(new VocabularyService(context), mockLogger.Object);

                var newVocab = new VocabularyDTO { LangueName = "English", word = "Bonjour" };
                var updateResult = await controller.UpdateVocabulary(newVocab);
                Assert.IsNotNull(updateResult.Value);
                var updatedRes = context.Vocabularys.FirstOrDefault(v => v.word == newVocab.word);
                Assert.IsNotNull(updatedRes);
                Assert.AreEqual(newVocab.word, updatedRes.word);
            }
        }
        [TestMethod]
        public async Task TestGetVocabulariesByLangue()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<LibraryContext>()
                                .UseSqlite(connection)
                                .Options;

            using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();

                var mockLogger = new Mock<ILogger<VocabularyController>>();

                var controller = new VocabularyController(new VocabularyService(context), mockLogger.Object);

                var getResult = await controller.GetByLangue("French", 0, 10);
                Assert.IsNotNull(getResult.Value);
                Assert.AreEqual(1, getResult.Value.TotalCount);
                Assert.AreEqual("Bonjour", getResult.Value.Items.Last().word);
                Assert.AreEqual("French", getResult.Value.Items.Last().LangueName);
            }
        }


    }
}
