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
    public class RoleTU
    {
        [TestMethod]
        public async Task TestAddRole()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<SAEContext>()
                                .UseSqlite(connection)
                                .Options;

            using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();

                var role = new RoleEntity { Id = 4, Name = "test" };
                context.Roles.Add(role);
                await context.SaveChangesAsync();
                var test = context.Roles.FirstOrDefault(r => r.Id == 4);
                Assert.IsNotNull(test);
                Assert.AreEqual("test", test.Name);

            }
        }
        [TestMethod]
        public async Task TestDeleteRole()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<SAEContext>()
                                .UseSqlite(connection)
                                .Options;

            using (var context = new StubbedContext(options))
            {
                context.Database.EnsureCreated();
                var role = context.Roles.FirstOrDefault(r => r.Id == 3);
                Assert.IsNotNull(role);
                context.Roles.Remove(role);
                await context.SaveChangesAsync();
                var test = context.Roles.FirstOrDefault(r => r.Id == 3);
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
                var role = context.Roles.FirstOrDefault(r => r.Id == 3);
                Assert.IsNotNull(role);
                role.Name = "test2";
                await context.SaveChangesAsync();
                var test = context.Roles.FirstOrDefault(r => r.Id == 3);
                Assert.IsNotNull(test);
                Assert.AreEqual("test2", test.Name);
            }
        }
    }
}
