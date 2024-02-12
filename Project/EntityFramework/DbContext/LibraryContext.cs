using System.Collections.Generic;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DbContextLib
{
    public class LibraryContext : DbContext
    {
        // DbSet<BookEntity> est une propriété dans le contexte de base de données (DbContext) qui représente une table de livres dans la base de données.
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<BeEntity> Bes { get; set; }
        public DbSet<GroupEntity> Groups { get; set; }
        public DbSet<LangueEntity> Langue { get; set; }
        //public DbSet<PracticeEntity> Practices { get; set; }
        public DbSet<RegisterEntity> Registers { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<TranslateEntity> Translates { get; set; }
        public DbSet<VocabularyEntity> Vocabularys { get; set; }
        public DbSet<VocabularyListEntity> vocabularyListEntities { get; set; }
        //permet de créer une base de donnée (fichier .db) ici en Sqlite avec le nom Db.Books.db


        public LibraryContext(DbContextOptions<LibraryContext> options): base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlite($"Data Source=Db.in_english_please.db");
        }
    }
}
