using Entities;
using Modele;

namespace ModeleToEntities
{
    public static class Extensions
    {

        public static GroupEntity ToEntity(this Group group)
        {
            return new GroupEntity
            {
                Id = group.Id,
                Num = group.Num,
                year = group.year,
                sector = group.sector,
                VocabularyList = group.VocabularyList.Select(v => v.ToEntity()).ToList()
            };
        }

        public static Group ToModel(this GroupEntity group)
        {
            return new Group
            {
                Id = group.Id,
                Num = group.Num,
                year = group.year,
                sector = group.sector,
                VocabularyList = group.VocabularyList.Select(v => v.ToModel()).ToList()
            };
        }

        public static VocabularyListEntity ToEntity(this VocabularyList vocabularyList)
        {
            return new VocabularyListEntity
            {
                Id = vocabularyList.Id,
                Name = vocabularyList.Name,
                Image = vocabularyList.Image,
                UserId = vocabularyList.UserId,
                translation = vocabularyList.translation.Select(t => t.ToEntity()).ToList(),
                Groups = vocabularyList.Groups.Select(g => g.ToEntity()).ToList()
            };
        }

        public static VocabularyList ToModel(this VocabularyListEntity vocabularyList)
        {
            return new VocabularyList
            {
                Id = vocabularyList.Id,
                Name = vocabularyList.Name,
                Image = vocabularyList.Image,
                UserId = vocabularyList.UserId,
                translation = vocabularyList.translation.Select(t => t.ToModel()).ToList(),
                Groups = vocabularyList.Groups.Select(g => g.ToModel()).ToList()
            };
        }

        public static TranslateEntity ToEntity(this Translate translate)
        {
            return new TranslateEntity
            {
                Id = translate.Id,
                WordsId = translate.WordsId,
                Words = translate.Words.Select(w => w.ToEntity()).ToList(),
                VocabularyListVocId = translate.VocabularyListVocId,
                VocabularyListVoc = translate.VocabularyListVoc.ToEntity()
            };
        }

        public static Translate ToModel(this TranslateEntity translate)
        {
            return new Translate
            {
                Id = translate.Id,
                WordsId = translate.WordsId,
                Words = translate.Words.Select(w => w.ToModel()).ToList(),
                VocabularyListVocId = translate.VocabularyListVocId,
                VocabularyListVoc = translate.VocabularyListVoc.ToModel()
            };
        }

        public static VocabularyEntity ToEntity(this Vocabulary vocabulary)
        {
            return new VocabularyEntity
            {
                word = vocabulary.word,
                LangueName = vocabulary.LangueName
            };
        }

        public static Vocabulary ToModel(this VocabularyEntity vocabulary)
        {
            return new Vocabulary
            {
                word = vocabulary.word,
                LangueName = vocabulary.LangueName
            };
        }

        public static UserEntity ToEntity(this User user)
        {
            return new UserEntity
            {
                Id = user.Id,
                Name = user.Name,
                UserName = user.UserName,
                NickName = user.NickName,
                ExtraTime = user.ExtraTime,
                GroupId = user.GroupId,
                Password = user.Password,
                Email = user.Email
            };
        }

        public static User ToModel(this UserEntity user)
        {
            return new User
            {
                Id = user.Id,
                Name = user.Name,
                UserName = user.UserName,
                NickName = user.NickName,
                ExtraTime = user.ExtraTime,
                GroupId = user.GroupId,
                Password = user.Password,
                Email = user.Email
            };
        }

        public static RoleEntity ToEntity(this Role role)
        {
            return new RoleEntity
            {
                Id = role.Id,
                Name = role.Name
            };
        }

        public static Role ToModel(this RoleEntity role)
        {
            return new Role
            {
                Id = role.Id,
                Name = role.Name
            };
        }

        public static LangueEntity ToEntity(this Langue langue)
        {
            return new LangueEntity
            {
                name = langue.name
            };
        }

        public static Langue ToModel(this LangueEntity langue)
        {
            return new Langue
            {
                name = langue.name
            };
        }


    }
}
