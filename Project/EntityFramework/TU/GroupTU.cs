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
        public async Task TestGetGroups()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<LibraryContext>()
                                .UseSqlite(connection)
                                .Options;
            using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();

                var groups = await context.Groups.ToListAsync();
                Assert.IsNotNull(groups);
                Assert.AreEqual(1, groups.Count);
                Assert.AreEqual("informatics", groups[0].sector);
                Assert.AreEqual(1, groups[0].year);
                Assert.AreEqual(1, groups[0].Id);
                Assert.AreEqual(1, groups[0].Num);
                Assert.AreEqual(0, groups[0].VocabularyList.Count());
                Assert.AreEqual(0, groups[0].Users.Count());
            }
        }

        [TestMethod]
        public async Task TestGetGroup() {             
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
                Assert.AreEqual(0, group1.Num);
                Assert.AreEqual(0, group1.VocabularyList.Count());
                Assert.AreEqual(0, group1.Users.Count());
            }
        }

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
                var VocabularyList = new VocabularyListEntity { Id = 1, Name = "name1", Image="image", UserId=4 };
                var user = new UserEntity { Id = 4, Name = "name1", UserName = "username1", image="image", NickName = "nickname1", ExtraTime = true, GroupId = 2, Password = "1234", Email = "", RoleId = 3 };
                var newBook = new GroupEntity { Id = 2, year = 2, sector = "medecin", Users = [user], VocabularyList = [VocabularyList] };
                await context.Groups.AddAsync(newBook);
                await context.SaveChangesAsync();

                var group1 = await context.Groups.FirstOrDefaultAsync(b => b.sector == "medecin");
                Assert.IsNotNull(group1);
                Assert.AreEqual("medecin", group1.sector);
                Assert.AreEqual(2, group1.year);
                Assert.AreEqual(2, group1.Id);
                Assert.AreEqual(0, group1.Num);
                Assert.AreEqual(1, group1.VocabularyList.Count());
                Assert.AreEqual("name1", group1.VocabularyList.First().Name);
                Assert.AreEqual(1, group1.Users.Count());
                Assert.AreEqual("name1", group1.Users.First().Name);

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
                var VocabularyList = new VocabularyListEntity { Id = 1, Name = "name1", Image = "image", UserId = 4 };
                var user = new UserEntity { Id = 4, Name = "name1", UserName = "username1", image = "image", NickName = "nickname1", ExtraTime = true, GroupId = 2, Password = "1234", Email = "", RoleId = 3 };
                var newBook = new GroupEntity { Id = 2, year = 2, sector = "medecin", Users = [user], VocabularyList = [VocabularyList]  };
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

                var newBook = new GroupEntity { Id = 2, year = 2, sector = "medecin", Num=1 };
                await context.Groups.AddAsync(newBook);
                await context.SaveChangesAsync();

                var group1 = await context.Groups.FirstOrDefaultAsync(b => b.sector == "medecin");
                Assert.IsNotNull(group1);
                Assert.AreEqual("medecin", group1.sector);
                Assert.AreEqual(2, group1.year);
                Assert.AreEqual(2, group1.Id);
                Assert.AreEqual(1, group1.Num);

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