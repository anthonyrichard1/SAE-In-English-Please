using adminBlazor.Models;
using Blazorise;
using System.Data;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace adminBlazor.Factories
{
    public static class UserFactory
    {
        public static User ToModel(User user, byte[] imageContent)
        {
            return new User
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Nickname = user.Nickname,
                ExtraTime = user.ExtraTime,
                Image = user.Image,
                Group = user.Group,
                Password = user.Password,
                Email = user.Email,
                Roles = user.Roles
            };
        }

        public static User Create(User user)
        {
            return new User
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Nickname = user.Nickname,
                ExtraTime = user.ExtraTime,
                Image = user.Image,
                Group = user.Group,
                Password = user.Password,
                Email = user.Email,
                Roles = user.Roles
            };
        }

        public static void Update(User item, User user)
        {
            item.Id = user.Id;
            item.Name = user.Name;
            item.Surname = user.Surname;
            item.Nickname = user.Nickname;
            item.ExtraTime = user.ExtraTime;
            item.Image = user.Image;
            item.Group = user.Group;
            item.Password = user.Password;
            item.Email = user.Email;
            item.Roles = user.Roles;
        }
    }
}
