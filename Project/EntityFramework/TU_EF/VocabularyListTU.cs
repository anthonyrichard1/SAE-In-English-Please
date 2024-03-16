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
    public class VocabularyListTU
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
    
                    var vocabularyList = new VocabularyListEntity { Id=2, Name="name1", Image="image", UserId=2};
    
                    context.VocabularyLists.Add(vocabularyList);
                    await context.SaveChangesAsync();
    
                    var test = context.VocabularyLists.FirstOrDefault(g => g.Id == vocabularyList.Id);
                    Assert.IsNotNull(test);
                    Assert.AreEqual("name1", test.Name);
                    Assert.AreEqual("image", test.Image);
                    Assert.AreEqual(2, test.UserId);
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
    
                    var vocabularyList = context.VocabularyLists.FirstOrDefault(g => g.Id == 1);
                    Assert.IsNotNull(vocabularyList);
                    context.VocabularyLists.Remove(vocabularyList);
                    context.SaveChanges();
    
                    var test = context.VocabularyLists.FirstOrDefault(g => g.Id == 1);
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
    
                    var vocabularyList = context.VocabularyLists.FirstOrDefault(g => g.Id == 1);
                    Assert.IsNotNull(vocabularyList);
                    vocabularyList.Name = "French2";
                    vocabularyList.Image = "image2";
                    vocabularyList.UserId = 2;
                    context.VocabularyLists.Update(vocabularyList);
                    context.SaveChanges();
    
                    var test = context.VocabularyLists.FirstOrDefault(g => g.Id ==1);
                    Assert.IsNotNull(test);
                    Assert.AreEqual("French2", test.Name);
                    Assert.AreEqual("image2", test.Image);
                    Assert.AreEqual(2, test.UserId);
                }
            }
    }
}
