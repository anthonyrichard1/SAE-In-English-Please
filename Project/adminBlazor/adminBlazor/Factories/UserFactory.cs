﻿using adminBlazor.Models;
using Blazorise;
using Blazorise.Extensions;
using System.Data;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace adminBlazor.Factories
{
    public static class UserFactory
    {
        public static UserModel ToModel(User user, byte[] imageContent)
        {
            return new UserModel
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Nickname = user.Nickname,
                ExtraTime = user.ExtraTime,
                Image = imageContent,
                Group = user.Group,
                Password = user.Password,
                Email = user.Email,
                Roles = user.Roles,
                ImageBase64 = string.IsNullOrWhiteSpace(user.ImageBase64) ? Convert.ToBase64String(imageContent) : user.ImageBase64
            };
        }

        public static User Create(UserModel user)
        {
            return new User
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Nickname = user.Nickname,
                ExtraTime = user.ExtraTime,
                //Image = user.Image,
                Group = user.Group,
                Password = user.Password,
                Email = user.Email,
                Roles = user.Roles,
                ImageBase64 = user.Image != null ? Convert.ToBase64String(user.Image) : null
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

                item.ExtraTime = user.ExtraTime;

            if (user.Group != 0)
                item.Group = user.Group;

            if (!string.IsNullOrEmpty(user.Password))
                item.Password = user.Password;

            if (!string.IsNullOrEmpty(user.Email))
                item.Email = user.Email;

            if (user.ImageBase64 != null && user.Image != null)
                item.ImageBase64 = Convert.ToBase64String(user.Image);

            if (user.Roles != null)
            {

                if (user.Roles.Contains("student"))
                {
                    item.Roles = new List<string>();
                    item.Roles.Add("Student");
                }
                else
                {
                    if (user.Roles.Contains("teacher") || user.Roles.Contains("admin"))
                    {
                        item.Roles = new List<string>();
                        if (user.Roles.Contains("teacher"))
                        {
                            item.Roles.Add("Teacher");
                        }
                        if (user.Roles.Contains("admin"))
                        {
                            item.Roles.Add("Admin");
                        }
                    }
                }

            }
                            
                }
            }

    }

