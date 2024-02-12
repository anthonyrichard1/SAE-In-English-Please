// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CraftingController.cs" company="UCA Clermont-Ferrand">
//     Copyright (c) UCA Clermont-Ferrand All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Minecraft.Crafting.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Minecraft.Crafting.Api.Models;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    /// <summary>
    /// The crafting controller.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// The json serializer options.
        /// </summary>
        private readonly JsonSerializerOptions _jsonSerializerOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
        };

        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>The async task.</returns>
        [HttpPost]
        [Route("")]
        public Task Add(User item)
        {
            var data = JsonSerializer.Deserialize<List<User>>(System.IO.File.ReadAllText("Data/users.json"), _jsonSerializerOptions);

            if (data == null)
            {
                throw new Exception("Unable to get the users.");
            }

            // Simulate the Id
            item.Id = data.Max(s => s.Id) + 1;

            data.Add(item);

            System.IO.File.WriteAllText("Data/users.json", JsonSerializer.Serialize(data, _jsonSerializerOptions));

            return Task.CompletedTask;
        }

        /// <summary>
        /// Get all users.
        /// </summary>
        /// <returns>All users.</returns>
        [HttpGet]
        [Route("all")]
        public Task<List<User>> All()
        {
            var data = JsonSerializer.Deserialize<List<User>>(System.IO.File.ReadAllText("Data/users.json"), _jsonSerializerOptions);

            if (data == null)
            {
                throw new Exception("Unable to get the users.");
            }

            return Task.FromResult(data.ToList());
        }

        /// <summary>
        /// Count the number of users.
        /// </summary>
        /// <returns>The number of users.</returns>
        [HttpGet]
        [Route("count")]
        public Task<int> Count()
        {
            var data = JsonSerializer.Deserialize<List<User>>(System.IO.File.ReadAllText("Data/users.json"), _jsonSerializerOptions);

            if (data == null)
            {
                throw new Exception("Unable to get the users.");
            }

            return Task.FromResult(data.Count);
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The async task.</returns>
        [HttpDelete]
        [Route("{id}")]
        public Task Delete(int id)
        {
            var data = JsonSerializer.Deserialize<List<User>>(System.IO.File.ReadAllText("Data/users.json"), _jsonSerializerOptions);

            if (data == null)
            {
                throw new Exception("Unable to get the users.");
            }

            var item = data.FirstOrDefault(w => w.Id == id);

            if (item == null)
            {
                throw new Exception($"Unable to found the item with ID: {id}");
            }

            data.Remove(item);

            System.IO.File.WriteAllText("Data/users.json", JsonSerializer.Serialize(data, _jsonSerializerOptions));

            return Task.CompletedTask;
        }

        /// <summary>
        /// Gets the item by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The item.</returns>
        [HttpGet]
        [Route("{id}")]
        public Task<User> GetById(int id)
        {
            var data = JsonSerializer.Deserialize<List<User>>(System.IO.File.ReadAllText("Data/users.json"), _jsonSerializerOptions);

            if (data == null)
            {
                throw new Exception("Unable to get the users.");
            }

            var item = data.FirstOrDefault(w => w.Id == id);

            if (item == null)
            {
                throw new Exception($"Unable to found the item with ID: {id}");
            }

            return Task.FromResult(item);
        }

   


        /// <summary>
        /// Get the users with pagination.
        /// </summary>
        /// <param name="currentPage">The current page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>The users.</returns>
        [HttpGet]
        [Route("")]
        public Task<List<User>> List(int currentPage, int pageSize)
        {
            var data = JsonSerializer.Deserialize<List<User>>(System.IO.File.ReadAllText("Data/users.json"), _jsonSerializerOptions);

            if (data == null)
            {
                throw new Exception("Unable to get the users.");
            }

            return Task.FromResult(data.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList());
        }



        /// <summary>
        /// Updates the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="item">The item.</param>    
        /// <returns>The async task.</returns>
        [HttpPut]
        [Route("{id}")]
        public Task Update(int id, User item)
        {
            var data = JsonSerializer.Deserialize<List<User>>(System.IO.File.ReadAllText("Data/users.json"), _jsonSerializerOptions);

            var itemOriginal = data?.FirstOrDefault(w => w.Id == id);

            if (itemOriginal == null)
            {
                throw new Exception($"Unable to found the item with ID: {id}");
            }
            //itemOriginal.Id = item.Id;
            itemOriginal.Name = item.Name;
            itemOriginal.Surname = item.Surname;
            itemOriginal.Nickname = item.Nickname;
            itemOriginal.Email = item.Email;
            itemOriginal.ExtraTime = item.ExtraTime;
            itemOriginal.Password = item.Password;
            itemOriginal.Roles = item.Roles;
            itemOriginal.Group = item.Group;
            itemOriginal.ImageBase64 = item.ImageBase64;

            System.IO.File.WriteAllText("Data/users.json", JsonSerializer.Serialize(data, _jsonSerializerOptions));

            return Task.CompletedTask;
        }

        /// <summary>
        /// Gets the name of the item.
        /// </summary>
        /// <param name="users">The items.</param>
        /// <param name="inShape">The in shape.</param>
        /// <param name="line">The line.</param>
        /// <param name="row">The row.</param>
        /// <returns>The name of the item.</returns>





    }
}