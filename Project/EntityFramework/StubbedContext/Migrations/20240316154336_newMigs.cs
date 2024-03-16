using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StubbedContextLib.Migrations
{
    /// <inheritdoc />
    public partial class newMigs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroupEntity",
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
                    table.PrimaryKey("PK_GroupEntity", x => x.Id);
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
                name: "VocabularyEntity",
                columns: table => new
                {
                    word = table.Column<string>(type: "TEXT", nullable: false),
                    LangueName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VocabularyEntity", x => x.word);
                    table.ForeignKey(
                        name: "FK_VocabularyEntity_Langues_LangueName",
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
                        name: "FK_Users_GroupEntity_GroupId",
                        column: x => x.GroupId,
                        principalTable: "GroupEntity",
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
                name: "VocabularyListEntity",
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
                    table.PrimaryKey("PK_VocabularyListEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VocabularyListEntity_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupEntityVocabularyListEntity",
                columns: table => new
                {
                    GroupVocabularyListId = table.Column<long>(type: "INTEGER", nullable: false),
                    VocsGroupsId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupEntityVocabularyListEntity", x => new { x.GroupVocabularyListId, x.VocsGroupsId });
                    table.ForeignKey(
                        name: "FK_GroupEntityVocabularyListEntity_GroupEntity_VocsGroupsId",
                        column: x => x.VocsGroupsId,
                        principalTable: "GroupEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupEntityVocabularyListEntity_VocabularyListEntity_GroupVocabularyListId",
                        column: x => x.GroupVocabularyListId,
                        principalTable: "VocabularyListEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TranslateEntity",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WordsId = table.Column<string>(type: "TEXT", nullable: false),
                    VocabularyListVocId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TranslateEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TranslateEntity_VocabularyListEntity_VocabularyListVocId",
                        column: x => x.VocabularyListVocId,
                        principalTable: "VocabularyListEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TranslateEntityVocabularyEntity",
                columns: table => new
                {
                    TransVocword = table.Column<string>(type: "TEXT", nullable: false),
                    VoctranslationsId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TranslateEntityVocabularyEntity", x => new { x.TransVocword, x.VoctranslationsId });
                    table.ForeignKey(
                        name: "FK_TranslateEntityVocabularyEntity_TranslateEntity_VoctranslationsId",
                        column: x => x.VoctranslationsId,
                        principalTable: "TranslateEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TranslateEntityVocabularyEntity_VocabularyEntity_TransVocword",
                        column: x => x.TransVocword,
                        principalTable: "VocabularyEntity",
                        principalColumn: "word",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "GroupEntity",
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
                table: "VocabularyEntity",
                columns: new[] { "word", "LangueName" },
                values: new object[] { "Bonjour", "French" });

            migrationBuilder.InsertData(
                table: "VocabularyListEntity",
                columns: new[] { "Id", "Image", "Name", "UserId" },
                values: new object[] { 1L, "image1", "Liste1", 1L });

            migrationBuilder.InsertData(
                table: "TranslateEntity",
                columns: new[] { "Id", "VocabularyListVocId", "WordsId" },
                values: new object[] { 1L, 1L, "1" });

            migrationBuilder.CreateIndex(
                name: "IX_GroupEntityVocabularyListEntity_VocsGroupsId",
                table: "GroupEntityVocabularyListEntity",
                column: "VocsGroupsId");

            migrationBuilder.CreateIndex(
                name: "IX_TranslateEntity_VocabularyListVocId",
                table: "TranslateEntity",
                column: "VocabularyListVocId");

            migrationBuilder.CreateIndex(
                name: "IX_TranslateEntityVocabularyEntity_VoctranslationsId",
                table: "TranslateEntityVocabularyEntity",
                column: "VoctranslationsId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_GroupId",
                table: "Users",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_VocabularyEntity_LangueName",
                table: "VocabularyEntity",
                column: "LangueName");

            migrationBuilder.CreateIndex(
                name: "IX_VocabularyListEntity_UserId",
                table: "VocabularyListEntity",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupEntityVocabularyListEntity");

            migrationBuilder.DropTable(
                name: "TranslateEntityVocabularyEntity");

            migrationBuilder.DropTable(
                name: "TranslateEntity");

            migrationBuilder.DropTable(
                name: "VocabularyEntity");

            migrationBuilder.DropTable(
                name: "VocabularyListEntity");

            migrationBuilder.DropTable(
                name: "Langues");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "GroupEntity");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
