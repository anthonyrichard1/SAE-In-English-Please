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
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<VocabularyEntity>()
            .HasMany(al => al.translations)
            .WithMany(ar => ar.Words).UsingEntity<VocabularyTranslateEntity>();

            modelBuilder.Entity<VocabularyListEntity>()
                .HasMany(u => u.Groups)
                .WithMany(g => g.VocabularyList)
                .UsingEntity<VocabularyListGroup>();


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
                Email = "",
                RoleId = 1

            },
            new UserEntity
            {
                Id = 2,
                Name = "name2",
                UserName = "username2",
                NickName = "nickname2",
                ExtraTime = true,
                GroupId = 1,
                Password = "1234",
                Email = "",
                RoleId = 2
            },
            new UserEntity
            {
                Id = 3,
                Name = "name3",
                UserName = "username3",
                NickName = "nickname3",
                ExtraTime = true,
                GroupId = 1,
                Password = "1234",
                Email = "",
                RoleId = 3,
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
            modelBuilder.Entity<GroupEntity>().HasData(
                new GroupEntity
                {
                    Id = 1,
                    Num = 1,
                    sector = "informatics",
                    year = 1,
                    VocabularyList = null

                });
            modelBuilder.Entity<TranslateEntity>().HasData(
                new TranslateEntity
                               {
                    Id = 1,
                    WordsId = "1",
                    VocabularyListVocId = 1,
                    VocabularyListVoc = null
                });
            modelBuilder.Entity<VocabularyEntity>().HasData(
                new VocabularyEntity
                {
                    LangueName = "French",
                    word = "Bonjour"
                });
            modelBuilder.Entity<VocabularyListEntity>().HasData(
                new VocabularyListEntity
                {
                    Id = 1,
                    Name = "Liste1",
                    UserId = 1,
                    Image = "image1",
                });

        }

        public StubbedContext() { }

        public StubbedContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

    }
}
