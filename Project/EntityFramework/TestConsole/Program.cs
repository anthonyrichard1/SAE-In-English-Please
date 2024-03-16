// See https://aka.ms/new-console-template for more information
using DbContextLib;
using Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using StubbedContextLib;


Console.WriteLine("Hello, World!");


var connection = new SqliteConnection("DataSource=:memory:");
connection.Open();
var options = new DbContextOptionsBuilder<SAEContext>()
                    .UseSqlite(connection)
                    .Options;
Console.WriteLine("Test Users : \n\n");
using (var context = new StubbedContext(options))
{
    context.Database.EnsureCreated();

    var users = context.Users.ToList();
    Console.WriteLine("Users: " + users.Count);
    var roles = context.Roles.ToList();
    Console.WriteLine("Roles: " + roles.Count);

    Console.WriteLine("\ntest show 5 first Users : \n");
    foreach (var user in context.Users.Take(5))
    {
        Console.WriteLine(user.toString());
    }

    var user1 = new UserEntity
    {
        Name = "name4",
        UserName = "username4",
        NickName = "nickname4",
        ExtraTime = true,
        GroupId = 1,
        Password = "12344",
        Email = "",
        RoleId = 3,
        image = "image4",
    };

    context.Users.Add(user1);
    context.SaveChanges();

    Console.WriteLine("\ntest ajout (1 user suplementaire normalement) \n");
    foreach (var user in context.Users.Take(5))
    {
        Console.WriteLine(user.toString());
    }


    user1.Name = "updated";
    context.Users.Update(user1);
    context.SaveChanges();
    Console.WriteLine("\ntest update (le nom doit etre 'updated') \n");
    Console.WriteLine(user1.toString());

    context.Users.Remove(user1);
    context.SaveChanges();
    Console.WriteLine("\ntest suppression\n");
    foreach (var user in context.Users.Take(5))
    {
        Console.WriteLine(user.toString());
    }

    Console.WriteLine("\n\nTest VocsGroups : \n\n");
    var groups = context.Groups.ToList();
    Console.WriteLine("VocsGroups: " + groups.Count);
    Console.WriteLine("\ntest show 5 first VocsGroups : \n");
    foreach (var group in context.Groups.Take(5))
    {
        Console.WriteLine(group.toString());
    }

    var group1 = new GroupEntity
    {
        Id = 4,
        Num = 4,
        year = 4,
        sector = "sector4",
        Users = [user1],

    };

    context.Groups.Add(group1);
    context.SaveChanges();

    Console.WriteLine("\ntest ajout (1 group suplementaire normalement) \n");
    foreach (var group in context.Groups.Take(5))
    {
        Console.WriteLine(group.toString());
    }
    group1.Num = 5;
    group1.sector = "updated";
    context.Update(group1);
    context.SaveChanges();
    Console.WriteLine("\ntest update (le nom doit etre 'updated' et le Num = 5) \n");
    Console.WriteLine(group1.toString());

    Console.WriteLine("\n test utilisateur du groupe normalement le user : updated ");
    foreach (var group in context.Groups.Take(5))
    {
        foreach (var user in group.Users.Take(5))
        {
            Console.WriteLine(user.toString());
        }
    }
    context.Remove(group1);
    context.SaveChanges();
    Console.WriteLine("\ntest suppression\n");
    foreach (var group in context.Groups.Take(5))
    {
        Console.WriteLine(group.toString());
    }

    Console.WriteLine("\n\nTest Langue : \n\n");

    context.Database.EnsureCreated();
    var langues = context.Langues.ToList();
    Console.WriteLine("Langues: " + langues.Count);
    Console.WriteLine("\ntest show 5 first Langues : \n");
    foreach (var langue in context.Langues.Take(5))
    {
        Console.WriteLine(langue.name);
    }
    Console.WriteLine("\n ajout Langue (normalement chinese\n");
    var langue1 = new LangueEntity
    {
        name = "Chinese"
    };
    context.Langues.Add(langue1);
    context.SaveChanges();
    foreach (var langue in context.Langues.Take(5))
    {
        Console.WriteLine(langue.name);
    }
    Console.WriteLine("\n test des liens langues <=> vocabulaires (resultat attendu : 'word1 Chinese'\n");
    var vocabularyList1 = new VocabularyEntity
    {
        word = "word1",
        LangueName = "Chinese",
        Langue = langue1
    };
    context.Vocabularys.Add(vocabularyList1);
    foreach (var langue in context.Langues.Take(5))
    {
        foreach (var vocabularyList in langue.vocabularys.Take(5))
        {
            Console.WriteLine(vocabularyList.toString());
        
        }
    }
    context.Langues.Remove(langue1);
    context.SaveChanges();
    Console.WriteLine("\ntest suppression (il n'y a normalement plus la langue 'Chinese'\n");
    foreach (var langue in context.Langues.Take(5))
    {
        Console.WriteLine(langue.name);
    }
    Console.WriteLine("\n\nTest Roles : \n\n");
    context.Database.EnsureCreated();
    var roles2 = context.Roles.ToList();
    Console.WriteLine("Roles: " + roles2.Count);
    Console.WriteLine("\ntest show 5 first Roles : \n");
    foreach (var role in context.Roles.Take(5))
    {
        Console.WriteLine(role.toString());
    }
    var role1 = new RoleEntity
    {
        Id = 4,
        Name = "Role4"
    };
    context.Roles.Add(role1);
    context.SaveChanges();
    Console.WriteLine("\n ajout Role (normalement Role4\n");
    foreach (var role in context.Roles.Take(5))
    {
        Console.WriteLine(role.toString());
    }
    role1.Name = "updated";
    context.Roles.Update(role1);
    context.SaveChanges();
    Console.WriteLine("\ntest update (le nom doit etre 'updated') \n");
    Console.WriteLine(role1.toString());


    Console.WriteLine("\n test utilisateur du role normalement");
        foreach (var role in context.Roles.Take(5))
    {
        foreach (var user in role.Users.Take(5))
        {
            Console.WriteLine(user.toString());
        }
    }
    context.Roles.Remove(role1);
    context.SaveChanges();
    Console.WriteLine("\ntest suppression (il n'y a normalement plus le role 'Role4'\n");
    foreach (var role in context.Roles.Take(5))
    {
        Console.WriteLine(role.toString());
    }
    
   Console.WriteLine("\n\nTest Translate : \n\n");
    context.Database.EnsureCreated();
     var translates = context.Translates.ToList();
    Console.WriteLine("Translates: " + translates.Count);
    Console.WriteLine("\ntest show 5 first Translates : \n");
    foreach (var translate in context.Translates.Take(5))
    {
        Console.WriteLine(translate.toString());
    }
    var translate1 = new TranslateEntity
    {
        Id = 4,
        WordsId = "Bonjour",
        VocabularyListVocId = 1
};
    context.Translates.Add(translate1);
    context.SaveChanges();
    Console.WriteLine("\n ajout Translate (normalement word4\n");
    foreach (var translate in context.Translates.Take(5))
    {
        Console.WriteLine(translate.toString());
    }
    var translate2 = new VocabularyEntity
    {
        word = "word4",
        LangueName = "English",
    };
    context.Vocabularys.Add(translate2);
    context.SaveChanges();
    translate1.WordsId = "word4";
    context.Translates.Update(translate1);
    context.SaveChanges();
    Console.WriteLine("\ntest update (le mot doit etre 'updated') \n");
    Console.WriteLine(translate1.toString());

    context.Translates.Remove(translate1);
    context.SaveChanges();
    Console.WriteLine("\ntest suppression (il n'y a normalement plus le mot 'word4'\n");
    foreach (var translate in context.Translates.Take(5))
    {
        Console.WriteLine(translate.toString());
    }
    Console.WriteLine("\n\nTest Vocabulary : \n\n");
    context.Database.EnsureCreated();

    var vocabularys = context.Vocabularys.ToList();
    Console.WriteLine("Vocabularys: " + vocabularys.Count);
    Console.WriteLine("\ntest show 5 first Vocabularys : \n");
    foreach (var vocabulary in context.Vocabularys.Take(5))
    {
        Console.WriteLine(vocabulary.toString());
    }
       var vocabulary1 = new VocabularyEntity
       {
        word = "NewWord",
        LangueName = "English"
    };
    context.Vocabularys.Add(vocabulary1);
    context.SaveChanges();
    Console.WriteLine("\n ajout Vocabulary (normalement NewWord) \n");
    foreach (var vocabulary in context.Vocabularys.Take(5))
    {
        Console.WriteLine(vocabulary.toString());
    }
    vocabulary1.LangueName = "French";
    context.Vocabularys.Update(vocabulary1);
    context.SaveChanges();
    Console.WriteLine("\ntest update (la langue doit etre 'French') \n");
    Console.WriteLine(vocabulary1.toString());

    context.Vocabularys.Remove(vocabulary1);
    context.SaveChanges();
    Console.WriteLine("\ntest suppression (il n'y a normalement plus le mot 'NewWord'\n");
    foreach (var vocabulary in context.Vocabularys.Take(5))
    {
        Console.WriteLine(vocabulary.toString());
    }

    Console.WriteLine("\n\nTest GroupVocabularyList : \n\n");
    context.Database.EnsureCreated();
    var vocabularyLists = context.VocabularyLists.ToList();
    Console.WriteLine("VocabularyLists: " + vocabularyLists.Count);
    Console.WriteLine("\ntest show 5 first VocabularyLists : \n");
    foreach (var vocabularyList in context.VocabularyLists.Take(5))
    {
        Console.WriteLine(vocabularyList.toString());
    }
    var vocabularyList2 = new VocabularyListEntity
    {
        Id = 4,
        Name = "name4",
        Image = "image4",
        UserId = 3
    };
    context.VocabularyLists.Add(vocabularyList2);
    context.SaveChanges();
    Console.WriteLine("\n ajout GroupVocabularyList (normalement name4) \n");
    foreach (var vocabularyList in context.VocabularyLists.Take(5))
    {
        Console.WriteLine(vocabularyList.toString());
    }
    vocabularyList2.Name = "updated";
    context.VocabularyLists.Update(vocabularyList2);
    context.SaveChanges();
    Console.WriteLine("\ntest update (le nom doit etre 'updated') \n");
    Console.WriteLine(vocabularyList2.toString());
    Console.WriteLine("\n test affichage des owner (user) des listes normalement");
    foreach (var vocabularyList in context.VocabularyLists.Take(5))
    {

            Console.WriteLine(vocabularyList.User.toString());
    }
    
    context.VocabularyLists.Remove(vocabularyList2);
    context.SaveChanges();
    Console.WriteLine("\ntest suppression (il n'y a normalement plus la liste 'name4'\n");
    foreach (var vocabularyList in context.VocabularyLists.Take(5))
    {
        Console.WriteLine(vocabularyList.toString());
    }

    Console.WriteLine("\n\nTest Many to Many (si pas d'erreur alors test reussi) : \n\n");

    context.Database.EnsureCreated();
    var groupVoc = new GroupEntity { Id = 2, Num = 1, year = 1, sector = "sector1" };
    VocabularyListEntity VocListGroup = new VocabularyListEntity { Id = 2, Name = "name1", Image = "image1", UserId = 1 };
    context.AddRange(groupVoc, VocListGroup);
    context.SaveChanges();

    var transVoc = new TranslateEntity { Id = 2, WordsId = "1", VocabularyListVocId = 1 };
    var VocTrans = new VocabularyEntity { word = "Test", LangueName = "French" };
    context.AddRange(transVoc, VocTrans);
    context.SaveChanges();








}