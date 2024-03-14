using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StubbedContextLib.Migrations
{
    /// <inheritdoc />
    public partial class NewMigs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Num = table.Column<int>(type: "INTEGER", nullable: false),
                    year = table.Column<int>(type: "INTEGER", nullable: false),
                    sector = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Langues",
                columns: table => new
                {
                    name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Langues", x => x.name);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vocabularys",
                columns: table => new
                {
                    word = table.Column<string>(type: "TEXT", nullable: false),
                    LangueName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vocabularys", x => x.word);
                    table.ForeignKey(
                        name: "FK_Vocabularys_Langues_LangueName",
                        column: x => x.LangueName,
                        principalTable: "Langues",
                        principalColumn: "name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    NickName = table.Column<string>(type: "TEXT", nullable: false),
                    image = table.Column<string>(type: "TEXT", nullable: true),
                    GroupId = table.Column<long>(type: "INTEGER", nullable: false),
                    RoleId = table.Column<long>(type: "INTEGER", nullable: false),
                    ExtraTime = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VocabularyLists",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Image = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VocabularyLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VocabularyLists_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Translates",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WordsId = table.Column<string>(type: "TEXT", nullable: false),
                    VocabularyListVocId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Translates_VocabularyLists_VocabularyListVocId",
                        column: x => x.VocabularyListVocId,
                        principalTable: "VocabularyLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VocabularyListGroup",
                columns: table => new
                {
                    VocabularyListId = table.Column<long>(type: "INTEGER", nullable: false),
                    GroupsId = table.Column<long>(type: "INTEGER", nullable: false),
                    GroupId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VocabularyListGroup", x => new { x.GroupsId, x.VocabularyListId });
                    table.ForeignKey(
                        name: "FK_VocabularyListGroup_Groups_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VocabularyListGroup_VocabularyLists_VocabularyListId",
                        column: x => x.VocabularyListId,
                        principalTable: "VocabularyLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VocabularyTranslateEntity",
                columns: table => new
                {
                    Wordsword = table.Column<string>(type: "TEXT", nullable: false),
                    translationsId = table.Column<long>(type: "INTEGER", nullable: false),
                    Word = table.Column<string>(type: "TEXT", nullable: false),
                    Translation = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VocabularyTranslateEntity", x => new { x.Wordsword, x.translationsId });
                    table.ForeignKey(
                        name: "FK_VocabularyTranslateEntity_Translates_translationsId",
                        column: x => x.translationsId,
                        principalTable: "Translates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VocabularyTranslateEntity_Vocabularys_Wordsword",
                        column: x => x.Wordsword,
                        principalTable: "Vocabularys",
                        principalColumn: "word",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Num", "sector", "year" },
                values: new object[] { 1L, 1, "informatics", 1 });

            migrationBuilder.InsertData(
                table: "Langues",
                column: "name",
                values: new object[]
                {
                    "English",
                    "French"
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Admin" },
                    { 2L, "Teacher" },
                    { 3L, "Student" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "ExtraTime", "GroupId", "Name", "NickName", "Password", "RoleId", "UserName", "image" },
                values: new object[,]
                {
                    { 1L, "", true, 1L, "name", "nickname", "1234", 1L, "username", null },
                    { 2L, "", true, 1L, "name2", "nickname2", "1234", 2L, "username2", null },
                    { 3L, "", true, 1L, "name3", "nickname3", "1234", 3L, "username3", null }
                });

            migrationBuilder.InsertData(
                table: "Vocabularys",
                columns: new[] { "word", "LangueName" },
                values: new object[] { "Bonjour", "French" });

            migrationBuilder.InsertData(
                table: "VocabularyLists",
                columns: new[] { "Id", "Image", "Name", "UserId" },
                values: new object[] { 1L, "image1", "Liste1", 1L });

            migrationBuilder.InsertData(
                table: "Translates",
                columns: new[] { "Id", "VocabularyListVocId", "WordsId" },
                values: new object[] { 1L, 1L, "1" });

            migrationBuilder.CreateIndex(
                name: "IX_Translates_VocabularyListVocId",
                table: "Translates",
                column: "VocabularyListVocId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_GroupId",
                table: "Users",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_VocabularyListGroup_VocabularyListId",
                table: "VocabularyListGroup",
                column: "VocabularyListId");

            migrationBuilder.CreateIndex(
                name: "IX_VocabularyLists_UserId",
                table: "VocabularyLists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Vocabularys_LangueName",
                table: "Vocabularys",
                column: "LangueName");

            migrationBuilder.CreateIndex(
                name: "IX_VocabularyTranslateEntity_translationsId",
                table: "VocabularyTranslateEntity",
                column: "translationsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VocabularyListGroup");

            migrationBuilder.DropTable(
                name: "VocabularyTranslateEntity");

            migrationBuilder.DropTable(
                name: "Translates");

            migrationBuilder.DropTable(
                name: "Vocabularys");

            migrationBuilder.DropTable(
                name: "VocabularyLists");

            migrationBuilder.DropTable(
                name: "Langues");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
