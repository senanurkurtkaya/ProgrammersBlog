using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProgrammersBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Logged = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Level = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Message = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    Logger = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Callsite = table.Column<string>(type: "NVARCHAR(MAX)", nullable: true),
                    Exception = table.Column<string>(type: "NVARCHAR(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    About = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    YoutubeLink = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    TwitterLink = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    InstagramLink = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FacebookLink = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    LinkedInLink = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    GitHubLink = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    WebsiteLink = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    Thumbnail = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ViewCount = table.Column<int>(type: "int", nullable: false),
                    CommentCount = table.Column<int>(type: "int", nullable: false),
                    SeoAuthor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SeoDescription = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SeoTags = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ViewsCount = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Articles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Articles_Id",
                        column: x => x.Id,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "Description", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Name", "Note" },
                values: new object[,]
                {
                    { 1, "InitialCreate", new DateTime(2025, 1, 1, 18, 5, 13, 686, DateTimeKind.Local).AddTicks(1564), "C# Programlama Dili İle İlgili En Güncel Bilgiler", true, false, "InitialCreate", new DateTime(2025, 1, 1, 18, 5, 13, 686, DateTimeKind.Local).AddTicks(1565), "C#", "C# Blog Kategorisi" },
                    { 2, "InitialCreate", new DateTime(2025, 1, 1, 18, 5, 13, 686, DateTimeKind.Local).AddTicks(1568), "C++ Programlama Dili İle İlgili En Güncel Bilgiler", true, false, "InitialCreate", new DateTime(2025, 1, 1, 18, 5, 13, 686, DateTimeKind.Local).AddTicks(1569), "C++", "C++ Blog Kategorisi" },
                    { 3, "InitialCreate", new DateTime(2025, 1, 1, 18, 5, 13, 686, DateTimeKind.Local).AddTicks(1572), "JavaScript Programlama Dili İle İlgili En Güncel Bilgiler", true, false, "InitialCreate", new DateTime(2025, 1, 1, 18, 5, 13, 686, DateTimeKind.Local).AddTicks(1572), "JavaScript", "JavaScript Blog Kategorisi" },
                    { 4, "InitialCreate", new DateTime(2025, 1, 1, 18, 5, 13, 686, DateTimeKind.Local).AddTicks(1575), "Typescript Programlama Dili ile İlgili En Güncel Bilgiler", true, false, "InitialCreate", new DateTime(2025, 1, 1, 18, 5, 13, 686, DateTimeKind.Local).AddTicks(1575), "Typescript", "Typescript Blog Kategorisi" },
                    { 5, "InitialCreate", new DateTime(2025, 1, 1, 18, 5, 13, 686, DateTimeKind.Local).AddTicks(1578), "Java Programlama Dili ile İlgili En Güncel Bilgiler", true, false, "InitialCreate", new DateTime(2025, 1, 1, 18, 5, 13, 686, DateTimeKind.Local).AddTicks(1579), "Java", "Java Blog Kategorisi" },
                    { 6, "InitialCreate", new DateTime(2025, 1, 1, 18, 5, 13, 686, DateTimeKind.Local).AddTicks(1581), "Python Programlama Dili ile İlgili En Güncel Bilgiler", true, false, "InitialCreate", new DateTime(2025, 1, 1, 18, 5, 13, 686, DateTimeKind.Local).AddTicks(1582), "Python", "Python Blog Kategorisi" },
                    { 7, "InitialCreate", new DateTime(2025, 1, 1, 18, 5, 13, 686, DateTimeKind.Local).AddTicks(1584), "Php Programlama Dili ile İlgili En Güncel Bilgiler", true, false, "InitialCreate", new DateTime(2025, 1, 1, 18, 5, 13, 686, DateTimeKind.Local).AddTicks(1585), "Php", "Php Blog Kategorisi" },
                    { 8, "InitialCreate", new DateTime(2025, 1, 1, 18, 5, 13, 686, DateTimeKind.Local).AddTicks(1587), "Kotlin Programlama Dili ile İlgili En Güncel Bilgiler", true, false, "InitialCreate", new DateTime(2025, 1, 1, 18, 5, 13, 686, DateTimeKind.Local).AddTicks(1588), "Kotlin", "Kotlin Blog Kategorisi" },
                    { 9, "InitialCreate", new DateTime(2025, 1, 1, 18, 5, 13, 686, DateTimeKind.Local).AddTicks(1590), "Swift Programlama Dili ile İlgili En Güncel Bilgiler", true, false, "InitialCreate", new DateTime(2025, 1, 1, 18, 5, 13, 686, DateTimeKind.Local).AddTicks(1591), "Swift", "Swift Blog Kategorisi" },
                    { 10, "InitialCreate", new DateTime(2025, 1, 1, 18, 5, 13, 686, DateTimeKind.Local).AddTicks(1593), "Ruby Programlama Dili ile İlgili En Güncel Bilgiler", true, false, "InitialCreate", new DateTime(2025, 1, 1, 18, 5, 13, 686, DateTimeKind.Local).AddTicks(1594), "Ruby", "Ruby Blog Kategorisi" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "33dd2686-3cf3-4e6a-9da0-26ed12f6ae5a", "Category.Create", "CATEGORY.CREATE" },
                    { 2, "35c4368d-f864-44af-b4ed-fd50232ba7a8", "Category.Read", "CATEGORY.READ" },
                    { 3, "56157c65-b92b-4df0-800a-1f8ddee39bc6", "Category.Update", "CATEGORY.UPDATE" },
                    { 4, "bc38b223-ad7e-44f0-acc4-83b35fcc38f1", "Category.Delete", "CATEGORY.DELETE" },
                    { 5, "514ab27b-1d22-4f95-b2a9-ab424773ff9f", "Article.Create", "ARTICLE.CREATE" },
                    { 6, "76254b4d-15d1-454e-bea0-5cd225430fb9", "Article.Read", "ARTICLE.READ" },
                    { 7, "058fb0b2-f934-4d58-839a-662a338eca3b", "Article.Update", "ARTICLE.UPDATE" },
                    { 8, "8f0b5b10-70a6-4c97-8d4f-7896fea7f46a", "Article.Delete", "ARTICLE.DELETE" },
                    { 9, "0190be55-165d-4ce7-9c84-eaac8370634a", "User.Create", "USER.CREATE" },
                    { 10, "5acb72f4-84cb-45b9-b1e9-cb3763f66924", "User.Read", "USER.READ" },
                    { 11, "4d66ecae-8914-4734-8dc6-93cd54723ada", "User.Update", "USER.UPDATE" },
                    { 12, "1d6deefc-70e0-40c9-a12d-e325fe8a2c8f", "User.Delete", "USER.DELETE" },
                    { 13, "84317a3f-72bc-461d-b446-e1ff229621f9", "Role.Create", "ROLE.CREATE" },
                    { 14, "3c35eca8-4540-4554-8a98-e44175cbb32d", "Role.Read", "ROLE.READ" },
                    { 15, "4ff86da3-64ac-49d9-ba47-8092b7ac32ab", "Role.Update", "ROLE.UPDATE" },
                    { 16, "480df839-e005-402e-b9e1-0588b19c2295", "Role.Delete", "ROLE.DELETE" },
                    { 17, "7ddf31a7-57de-49d2-8b61-bf830903e495", "Comment.Create", "COMMENT.CREATE" },
                    { 18, "36dccdbe-2f47-453d-9879-536486f57ec1", "Comment.Read", "COMMENT.READ" },
                    { 19, "7e9983df-b76a-4d24-ae09-94330548aabc", "Comment.Update", "COMMENT.UPDATE" },
                    { 20, "88a04f29-654b-436a-8c43-02acae770ed2", "Comment.Delete", "COMMENT.DELETE" },
                    { 21, "b4d8a731-8e5e-46a5-83c9-f4e5f9179e59", "AdminArea.Home.Read", "ADMINAREA.HOME.READ" },
                    { 22, "f50a494f-097e-4e5a-9196-ea7850580d7b", "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CategoryId",
                table: "Articles",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_UserId",
                table: "Articles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserId",
                table: "Users",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
