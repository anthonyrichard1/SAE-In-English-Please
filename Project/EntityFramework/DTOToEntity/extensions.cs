using DTO;
using Entities;

namespace DTOToEntity
{
    public static class Extensions
    {
        public static GroupEntity ToEntity( this GroupDTO group)
        {
            return new GroupEntity
            {
                Id = group.Id,
                Num = group.Num,
                year = group.Year,
                sector = group.sector,
                //Users = group.Users.Select(u => u.ToEntity()).ToList(),
                //VocabularyList = group.VocabularyList.Select(v => v.ToEntity()).ToList()

            };
        }
        public static GroupDTO ToDTO(this GroupEntity group)
        {
            return new GroupDTO
            {
                Id = group.Id,
                Num = group.Num,
                Year = group.year,
                sector = group.sector,
                //Users = group.Users.Select(u => u.ToDTO()).ToList(),
                //VocabularyList = group.VocabularyList.Select(v => v.ToDTO()).ToList()
            };
        }
        public static LangueEntity ToEntity(this LangueDTO langue)
        {
            return new LangueEntity
            {
                name = langue.name,
                //vocabularys = langue.vocabularys.Select(v => v.ToEntity()).ToList()
            };
        }
        public static LangueDTO ToDTO(this LangueEntity langue)
        {
            return new LangueDTO
            {
                name = langue.name,
                //vocabularys = langue.vocabularys.Select(v => v.ToDTO()).ToList()
            };
        }

        public static RoleEntity ToEntity(this RoleDTO role)
        {
            return new RoleEntity
            {
                Id = role.Id,
                Name = role.Name,
                //Users = role.Users.Select(u => u.ToEntity()).ToList()
            };
        }
        public static RoleDTO ToDTO(this RoleEntity role)
        {
            return new RoleDTO
            {
                Id = role.Id,
                Name = role.Name,
                //Users = role.Users.Select(u => u.ToDTO()).ToList()
            };
        }
        public static TranslateEntity ToEntity(this TranslateDTO translate)
        {
            return new TranslateEntity
            {
                Id = translate.Id,
                WordsId = translate.WordsId,
                //Words = translate.Words.Select(w => w.ToEntity()).ToList(),
                //VocabularyListVoc = translate.VocabularyListVoc.ToEntity(),
                VocabularyListVocId = translate.VocabularyListVocId,
            };
        }
        public static TranslateDTO ToDTO(this TranslateEntity translate)
        {
            return new TranslateDTO
            {
                Id = translate.Id,
                WordsId = translate.WordsId,
                //Words = translate.Words.Select(w => w.ToDTO()).ToList(),
                //VocabularyListVoc = translate.VocabularyListVoc.ToDTO(),
                VocabularyListVocId = translate.VocabularyListVocId,
            };
        }
        public static UserEntity ToEntity(this UserDTO user)
        {
            return new UserEntity
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                UserName = user.UserName,
                NickName = user.NickName,
                image = user.image,
                Password = user.Password,
                GroupId = user.GroupId,
                RoleId = user.RoleId,
                //Group = user.Group.ToEntity(),
                //Role = user.Role.ToEntity()
            };
        }
        public static UserDTO ToDTO(this UserEntity user)
        {
            return new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                UserName = user.UserName,
                NickName = user.NickName,
                image = user.image,
                Password = user.Password,
                GroupId = user.GroupId,
                RoleId = user.RoleId,
                //Group = user.Group.ToDTO(),
                //Role = user.Role.ToDTO()
            };
        }
        public static VocabularyEntity ToEntity(this VocabularyDTO vocabulary)
        {
            return new VocabularyEntity
            {
                word = vocabulary.word,
                //translations = vocabulary.translations.Select(t => t.ToEntity()).ToList(),
                LangueName = vocabulary.LangueName,
              
                //Langue = vocabulary.Langue.ToEntity()
            };
        }
        public static VocabularyDTO ToDTO(this VocabularyEntity vocabulary)
        {
            return new VocabularyDTO
            {
                word = vocabulary.word,
                //translations = vocabulary.translations.Select(t => t.ToDTO()).ToList(),
                LangueName = vocabulary.LangueName,
                //Langue = vocabulary.Langue.ToDTO()
            };
        }
        public static VocabularyListEntity ToEntity(this VocabularyListDTO vocabularyList)
        {
            return new VocabularyListEntity
            {
                Id = vocabularyList.Id,
                Name = vocabularyList.Name,
                Image = vocabularyList.Image,
                UserId = vocabularyList.UserId,
                //translation = vocabularyList.translation.Select(t => t.ToEntity()).ToList(),
                //Groups = vocabularyList.Groups.Select(g => g.ToEntity()).ToList()
            };
        }
        public static VocabularyListDTO ToDTO(this VocabularyListEntity vocabularyList)
        {
            return new VocabularyListDTO
            {
                Id = vocabularyList.Id,
                Name = vocabularyList.Name,
                Image = vocabularyList.Image,
                UserId = vocabularyList.UserId,
                //translation = vocabularyList.translation.Select(t => t.ToDTO()).ToList(),
                //Groups = vocabularyList.Groups.Select(g => g.ToDTO()).ToList()
            };
        }
    }
}
