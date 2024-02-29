using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StubbedContextLib.Migrations
{
    /// <inheritdoc />
    public partial class FirstMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
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
                name: "Langue",
                columns: table => new
                {
                    name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Langue", x => x.name);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
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
                        name: "FK_Vocabularys_Langue_LangueName",
                        column: x => x.LangueName,
                        principalTable: "Langue",
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
                    GroupId1 = table.Column<int>(type: "INTEGER", nullable: true),
                    RoleId = table.Column<long>(type: "INTEGER", nullable: false),
                    RoleId1 = table.Column<int>(type: "INTEGER", nullable: true),
                    ExtraTime = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Groups_GroupId1",
                        column: x => x.GroupId1,
                        principalTable: "Groups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId1",
                        column: x => x.RoleId1,
                        principalTable: "Roles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "vocabularyListEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Image = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vocabularyListEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_vocabularyListEntities_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Translates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WordsId = table.Column<string>(type: "TEXT", nullable: false),
                    VocabularyListVocId = table.Column<long>(type: "INTEGER", nullable: false),
                    VocabularyListVocId1 = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Translates_vocabularyListEntities_VocabularyListVocId1",
                        column: x => x.VocabularyListVocId1,
                        principalTable: "vocabularyListEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VocabularyListGroup",
                columns: table => new
                {
                    GroupsId = table.Column<int>(type: "INTEGER", nullable: false),
                    VocabularyListId1 = table.Column<int>(type: "INTEGER", nullable: false),
                    GroupId = table.Column<long>(type: "INTEGER", nullable: false),
                    VocabularyListId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VocabularyListGroup", x => new { x.GroupsId, x.VocabularyListId1 });
                    table.ForeignKey(
                        name: "FK_VocabularyListGroup_Groups_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VocabularyListGroup_vocabularyListEntities_VocabularyListId1",
                        column: x => x.VocabularyListId1,
                        principalTable: "vocabularyListEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VocabularyTranslateEntity",
                columns: table => new
                {
                    Wordsword = table.Column<string>(type: "TEXT", nullable: false),
                    translationsId = table.Column<int>(type: "INTEGER", nullable: false),
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
                values: new object[] { 1, 1, "informatics", 1 });

            migrationBuilder.InsertData(
                table: "Langue",
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
                    { 1, "Admin" },
                    { 2, "Teacher" },
                    { 3, "Student" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "ExtraTime", "GroupId", "GroupId1", "Name", "NickName", "Password", "RoleId", "RoleId1", "UserName", "image" },
                values: new object[,]
                {
                    { 1L, "", true, 1L, null, "name", "nickname", "1234", 0L, null, "username", null },
                    { 2L, "", true, 2L, null, "name2", "nickname2", "1234", 0L, null, "username2", null },
                    { 3L, "", true, 3L, null, "name3", "nickname3", "1234", 0L, null, "username3", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Translates_VocabularyListVocId1",
                table: "Translates",
                column: "VocabularyListVocId1");

            migrationBuilder.CreateIndex(
                name: "IX_Users_GroupId1",
                table: "Users",
                column: "GroupId1");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId1",
                table: "Users",
                column: "RoleId1");

            migrationBuilder.CreateIndex(
                name: "IX_vocabularyListEntities_UserId",
                table: "vocabularyListEntities",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_VocabularyListGroup_VocabularyListId1",
                table: "VocabularyListGroup",
                column: "VocabularyListId1");

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
                name: "vocabularyListEntities");

            migrationBuilder.DropTable(
                name: "Langue");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
