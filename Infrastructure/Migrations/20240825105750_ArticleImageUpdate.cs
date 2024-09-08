using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class ArticleImageUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ArticleTopics",
                keyColumns: new[] { "ArticleId", "TopicId" },
                keyValues: new object[] { new Guid("219a83cd-72dc-4a25-8ab0-57484a753ed1"), new Guid("1d0eb1c3-74a6-424f-8272-ce5ff8e192ae") });

            migrationBuilder.DeleteData(
                table: "ArticleTopics",
                keyColumns: new[] { "ArticleId", "TopicId" },
                keyValues: new object[] { new Guid("6e116c48-aa70-4988-9a9d-347fa978911f"), new Guid("45de9a21-8579-4ae4-ab6d-14a1925e35c9") });

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("219a83cd-72dc-4a25-8ab0-57484a753ed1"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("6e116c48-aa70-4988-9a9d-347fa978911f"));

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("1d0eb1c3-74a6-424f-8272-ce5ff8e192ae"));

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("45de9a21-8579-4ae4-ab6d-14a1925e35c9"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8563a2b9-4361-44d0-acc9-067a9cb912b4"));

            migrationBuilder.AddColumn<string>(
                name: "ProfileImageUrl",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Bio", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImageUrl", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("7db64e07-229a-4c61-8aef-e5de3dde9fc2"), 0, null, "15004da2-3334-456c-82d5-e4ca41b2d849", "admin@blog.com", true, "Admin", "admin", false, null, "ADMIN@BLOG.COM", "ADMIN@BLOG.COM", "AQAAAAEAACcQAAAAELa0qnUNtvXIQKNaGZpRT+QUN8I7j4zASpg9+VeFmIJvTgtxy6DxBaz2laPNQDUFNg==", null, false, null, "", false, "admin@blog.com" });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("2b92346e-3617-408e-a99a-6686044dcb55"), "Science" });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("839b3950-5a33-4af9-a719-3a3df0054afd"), "Technology" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "ProfileImageUrl", "ReadCount", "Title" },
                values: new object[] { new Guid("3eda3774-12d8-4a58-afb2-290509bc278e"), new Guid("7db64e07-229a-4c61-8aef-e5de3dde9fc2"), "Artificial Intelligence (AI) is transforming industries...", new DateTime(2024, 8, 25, 10, 57, 50, 658, DateTimeKind.Utc).AddTicks(6554), null, 0, "The Future of AI" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "ProfileImageUrl", "ReadCount", "Title" },
                values: new object[] { new Guid("a896fa57-7944-4d9a-9d3c-6a96d03645a5"), new Guid("7db64e07-229a-4c61-8aef-e5de3dde9fc2"), "The medical field is rapidly evolving with new technologies...", new DateTime(2024, 8, 25, 10, 57, 50, 658, DateTimeKind.Utc).AddTicks(6555), null, 0, "Advances in Medicine" });

            migrationBuilder.InsertData(
                table: "ArticleTopics",
                columns: new[] { "ArticleId", "TopicId" },
                values: new object[] { new Guid("3eda3774-12d8-4a58-afb2-290509bc278e"), new Guid("839b3950-5a33-4af9-a719-3a3df0054afd") });

            migrationBuilder.InsertData(
                table: "ArticleTopics",
                columns: new[] { "ArticleId", "TopicId" },
                values: new object[] { new Guid("a896fa57-7944-4d9a-9d3c-6a96d03645a5"), new Guid("2b92346e-3617-408e-a99a-6686044dcb55") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ArticleTopics",
                keyColumns: new[] { "ArticleId", "TopicId" },
                keyValues: new object[] { new Guid("3eda3774-12d8-4a58-afb2-290509bc278e"), new Guid("839b3950-5a33-4af9-a719-3a3df0054afd") });

            migrationBuilder.DeleteData(
                table: "ArticleTopics",
                keyColumns: new[] { "ArticleId", "TopicId" },
                keyValues: new object[] { new Guid("a896fa57-7944-4d9a-9d3c-6a96d03645a5"), new Guid("2b92346e-3617-408e-a99a-6686044dcb55") });

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("3eda3774-12d8-4a58-afb2-290509bc278e"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("a896fa57-7944-4d9a-9d3c-6a96d03645a5"));

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("2b92346e-3617-408e-a99a-6686044dcb55"));

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("839b3950-5a33-4af9-a719-3a3df0054afd"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7db64e07-229a-4c61-8aef-e5de3dde9fc2"));

            migrationBuilder.DropColumn(
                name: "ProfileImageUrl",
                table: "Articles");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Bio", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImageUrl", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("8563a2b9-4361-44d0-acc9-067a9cb912b4"), 0, null, "74b1e7fc-63dc-4a1b-930e-b1a0048c49c0", "admin@blog.com", true, "Admin", "admin", false, null, "ADMIN@BLOG.COM", "ADMIN@BLOG.COM", "AQAAAAEAACcQAAAAEM51/sQEqhac3u2pXg0Yurd9BSA6FmDsA9hJaJBcI3PbjXwablVfxjg9cGO50ntLUQ==", null, false, null, "", false, "admin@blog.com" });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("1d0eb1c3-74a6-424f-8272-ce5ff8e192ae"), "Technology" });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("45de9a21-8579-4ae4-ab6d-14a1925e35c9"), "Science" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "ReadCount", "Title" },
                values: new object[] { new Guid("219a83cd-72dc-4a25-8ab0-57484a753ed1"), new Guid("8563a2b9-4361-44d0-acc9-067a9cb912b4"), "Artificial Intelligence (AI) is transforming industries...", new DateTime(2024, 8, 24, 23, 26, 4, 318, DateTimeKind.Utc).AddTicks(1045), 0, "The Future of AI" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "ReadCount", "Title" },
                values: new object[] { new Guid("6e116c48-aa70-4988-9a9d-347fa978911f"), new Guid("8563a2b9-4361-44d0-acc9-067a9cb912b4"), "The medical field is rapidly evolving with new technologies...", new DateTime(2024, 8, 24, 23, 26, 4, 318, DateTimeKind.Utc).AddTicks(1114), 0, "Advances in Medicine" });

            migrationBuilder.InsertData(
                table: "ArticleTopics",
                columns: new[] { "ArticleId", "TopicId" },
                values: new object[] { new Guid("219a83cd-72dc-4a25-8ab0-57484a753ed1"), new Guid("1d0eb1c3-74a6-424f-8272-ce5ff8e192ae") });

            migrationBuilder.InsertData(
                table: "ArticleTopics",
                columns: new[] { "ArticleId", "TopicId" },
                values: new object[] { new Guid("6e116c48-aa70-4988-9a9d-347fa978911f"), new Guid("45de9a21-8579-4ae4-ab6d-14a1925e35c9") });
        }
    }
}
