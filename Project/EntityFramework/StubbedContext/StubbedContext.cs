using DbContextLib;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using Entities;
namespace StubbedContextLib
{
    public class StubbedContext : LibraryContext
    {
        //permet la création des données à ajouter dans la base de données

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().HasData(
            new UserEntity
            {

                Id = 1,
                Name = "name",
                UserName = "username",
                NickName = "nickname",
                ExtraTime = true,
                GroupId = 1,
                Password = "1234",
                Email = ""

            },
            new UserEntity
            {
                Id = 2,
                Name = "name2",
                UserName = "username2",
                NickName = "nickname2",
                ExtraTime = true,
                GroupId = 2,
                Password = "1234",
                Email = ""
            },
            new UserEntity
            {
                Id = 3,
                Name = "name3",
                UserName = "username3",
                NickName = "nickname3",
                ExtraTime = true,
                GroupId = 3,
                Password = "1234",
                Email = ""
            }
            );

            modelBuilder.Entity<RoleEntity>().HasData(
                new RoleEntity
                {
                    Id = 1,
                    Name = "Admin"
                },
                new RoleEntity
                {
                    Id = 2,
                    Name = "Teacher"
                },
                new RoleEntity
                {
                    Id = 3,
                    Name = "Student"
                }
          );

            modelBuilder.Entity<LangueEntity>().HasData(
                new LangueEntity
                {
                    name = "French"

                },
                new LangueEntity
                {
                    name = "English"
                }
                );
            }



        public StubbedContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

    }
}
