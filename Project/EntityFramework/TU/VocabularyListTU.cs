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
    public class VocabularyListTU
    {
        [TestMethod]
        public async Task TestAddVocabularyList()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<SAEContext>()
                                .UseSqlite(connection)
                                .Options;

            using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();

                var mockLogger = new Mock<ILogger<VocabularyListController>>();

                var controller = new VocabularyListController(new VocabularyListService(context), mockLogger.Object);

                var newVocabList = new VocabularyListDTO { Id = 2, Name = "TestVocabList", Image="img", UserId=1 };

                var result = await controller.AddVocabularyList(newVocabList);

                Assert.IsNotNull(result.Value);
                Assert.AreEqual(newVocabList.Name, result.Value.Name);

                var res = await context.VocabularyLists.FirstOrDefaultAsync(v => v.Id == 2);
                Assert.IsNotNull(res);
                Assert.AreEqual(newVocabList.Name, res.Name);


            }
        }

        [TestMethod]
        public async Task TestDeleteVocabularyList()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<SAEContext>()
                                .UseSqlite(connection)
                                .Options;

            using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();

                var mockLogger = new Mock<ILogger<VocabularyListController>>();

                var controller = new VocabularyListController(new VocabularyListService(context), mockLogger.Object);

                var deleteResult = await controller.DeleteVocabularyList(1);
                Assert.IsNotNull(deleteResult.Value);
                Assert.AreEqual("Liste1", deleteResult.Value.Name);

                var res2 = await context.VocabularyLists.FirstOrDefaultAsync(v => v.Id == 1);
                Assert.IsNull(res2);
            }
        }

        [TestMethod]
        public async Task TestGetVocabularyListById()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<SAEContext>()
                                .UseSqlite(connection)
                                .Options;

            using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();

                var mockLogger = new Mock<ILogger<VocabularyListController>>();

                var controller = new VocabularyListController(new VocabularyListService(context), mockLogger.Object);

                var getResult = await controller.GetVocabularyList(1);
                Assert.IsNotNull(getResult.Value);
                Assert.AreEqual("Liste1", getResult.Value.Name);
                Assert.AreEqual("image1", getResult.Value.Image);
            }
        }

        [TestMethod]
        public async Task TestGetVocabularyLists()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<SAEContext>()
                                .UseSqlite(connection)
                                .Options;

            using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();

                var mockLogger = new Mock<ILogger<VocabularyListController>>();

                var controller = new VocabularyListController(new VocabularyListService(context), mockLogger.Object);

                var getResult = await controller.GetVocabularyLists(0, 5);
                Assert.IsNotNull(getResult.Value);
                Assert.AreEqual(1, getResult.Value.TotalCount);
            }
        }

        [TestMethod]
        public async Task TestUpdateVocabularyList()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<SAEContext>()
                                .UseSqlite(connection)
                                .Options;

            using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();

                var mockLogger = new Mock<ILogger<VocabularyListController>>();

                var controller = new VocabularyListController(new VocabularyListService(context), mockLogger.Object);

                var newVocabList = new VocabularyListDTO { Id = 1, Name = "TestVocabList", Image = "img", UserId = 1 };

                var result = await controller.UpdateVocabularyList(newVocabList);

                Assert.IsNotNull(result.Value);
                Assert.AreEqual(newVocabList.Name, result.Value.Name);

                var res = await context.VocabularyLists.FirstOrDefaultAsync(v => v.Id == 1);
                Assert.IsNotNull(res);
                Assert.AreEqual(newVocabList.Name, res.Name);
            }
        }

        [TestMethod]
        public async Task TestGetVocabularyListByUser()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<SAEContext>()
                                .UseSqlite(connection)
                                .Options;

            using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();

                var mockLogger = new Mock<ILogger<VocabularyListController>>();

                var controller = new VocabularyListController(new VocabularyListService(context), mockLogger.Object);

                var getResult = await controller.GetVocabularyListsByUser(0, 5, 1);
                Assert.IsNotNull(getResult.Value);
                Assert.AreEqual(1, getResult.Value.TotalCount);
                Assert.AreEqual("Liste1", getResult.Value.Items.ToList()[0].Name);
                Assert.AreEqual("image1", getResult.Value.Items.ToList()[0].Image);
                Assert.AreEqual(1, getResult.Value.Items.ToList()[0].UserId);



            }
        }
    }
}
