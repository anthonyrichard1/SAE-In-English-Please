// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InventoryController.cs" company="UCA Clermont-Ferrand">
//     Copyright (c) UCA Clermont-Ferrand All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Minecraft.Crafting.Api.Models
{
    /// <summary>
    /// The User.
    /// </summary>

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <summary>
        /// Représente un utilisateur.
        /// </summary>
        public class User
        {
            /// <summary>
            /// Obtient ou définit l'identifiant.
            /// </summary>
            public int Id { get; set; }

            /// <summary>
            /// Obtient ou définit le mot de passe.
            /// </summary>
            public string Password { get; set; }

            /// <summary>
            /// Obtient ou définit l'adresse e-mail.
            /// </summary>
            public string Email { get; set; }

            /// <summary>
            /// Obtient ou définit le prénom.
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// Obtient ou définit le nom de famille.
            /// </summary>
            public string Surname { get; set; }

            /// <summary>
            /// Obtient ou définit le surnom.
            /// </summary>
            public string Nickname { get; set; }

            /// <summary>
            /// Obtient ou définit une valeur indiquant si l'utilisateur a du temps supplémentaire.
            /// </summary>
            public bool ExtraTime { get; set; }

            /// <summary>
            /// Obtient ou définit le groupe.
            /// </summary>
            public int Group { get; set; }

            /// <summary>
            /// Obtient ou définit les rôles de l'utilisateur.
            /// </summary>
            public List<string> Roles { get; set; }

            /// <summary>
            /// Obtient ou définit l'image encodée en base64.
            /// </summary>
            public string? ImageBase64 { get; set; }
        }
    }