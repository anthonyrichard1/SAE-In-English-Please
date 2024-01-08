using adminBlazor.Models;
using Blazorise;
using Blazorise.Extensions;
using System.Data;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace adminBlazor.Factories
{
    public static class UserFactory
    {
        public static UserModel ToModel(User user/* byte[] imageContent*/)
        {
            return new UserModel
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

        public static UserModel Create(UserModel user)
        {
            return new UserModel
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
        public static void Update(User item, UserModel user)
        {


            if (!string.IsNullOrEmpty(user.Name))
                item.Name = user.Name;

            if (!string.IsNullOrEmpty(user.Surname))
                item.Surname = user.Surname;

            if (!string.IsNullOrEmpty(user.Nickname))
                item.Nickname = user.Nickname;

            if (user.ExtraTime!=null)
                item.ExtraTime = user.ExtraTime;

            if (!string.IsNullOrEmpty(user.Image))
                item.Image = user.Image;

            if (user.Group!=null)
                item.Group = user.Group;

            if (!string.IsNullOrEmpty(user.Password))
                item.Password = user.Password;

            if (!string.IsNullOrEmpty(user.Email))
                item.Email = user.Email;

            if (user.Roles != null)
                item.Roles = user.Roles;
        }

    }
}
