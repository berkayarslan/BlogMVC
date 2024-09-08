using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class ArticleUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "ProfileImageUrl",
                table: "Articles",
                newName: "ImageUrl");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Bio", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImageUrl", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("0c14dd28-1d65-4819-a202-1b81dd6de0ad"), 0, null, "3bbe9bc4-0836-4969-bdfa-de2eb0beb511", "admin@blog.com", true, "Admin", "admin", false, null, "ADMIN@BLOG.COM", "ADMIN@BLOG.COM", "AQAAAAEAACcQAAAAELUDXnIuz2H8cIPzHm0aIUgZK9Jyrq6BGu5X/B0YAwTULAMX2s0LJGSScasG/Ynh3w==", null, false, null, "", false, "admin@blog.com" });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("1068bebc-1ebe-4717-bb32-d957be2c7e02"), "Technology" });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("483c2ab9-b31c-4dd6-8064-c94ca58abc24"), "Science" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "ImageUrl", "ReadCount", "Title" },
                values: new object[] { new Guid("5dda08f4-4062-4188-8419-2e81ed73ac03"), new Guid("0c14dd28-1d65-4819-a202-1b81dd6de0ad"), "The medical field is rapidly evolving with new technologies...", new DateTime(2024, 8, 25, 11, 3, 23, 435, DateTimeKind.Utc).AddTicks(6523), null, 0, "Advances in Medicine" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "ImageUrl", "ReadCount", "Title" },
                values: new object[] { new Guid("ac3e27a8-98be-41f9-a19e-93c57729ea6e"), new Guid("0c14dd28-1d65-4819-a202-1b81dd6de0ad"), "Artificial Intelligence (AI) is transforming industries...", new DateTime(2024, 8, 25, 11, 3, 23, 435, DateTimeKind.Utc).AddTicks(6521), null, 0, "The Future of AI" });

            migrationBuilder.InsertData(
                table: "ArticleTopics",
                columns: new[] { "ArticleId", "TopicId" },
                values: new object[] { new Guid("5dda08f4-4062-4188-8419-2e81ed73ac03"), new Guid("483c2ab9-b31c-4dd6-8064-c94ca58abc24") });

            migrationBuilder.InsertData(
                table: "ArticleTopics",
                columns: new[] { "ArticleId", "TopicId" },
                values: new object[] { new Guid("ac3e27a8-98be-41f9-a19e-93c57729ea6e"), new Guid("1068bebc-1ebe-4717-bb32-d957be2c7e02") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ArticleTopics",
                keyColumns: new[] { "ArticleId", "TopicId" },
                keyValues: new object[] { new Guid("5dda08f4-4062-4188-8419-2e81ed73ac03"), new Guid("483c2ab9-b31c-4dd6-8064-c94ca58abc24") });

            migrationBuilder.DeleteData(
                table: "ArticleTopics",
                keyColumns: new[] { "ArticleId", "TopicId" },
                keyValues: new object[] { new Guid("ac3e27a8-98be-41f9-a19e-93c57729ea6e"), new Guid("1068bebc-1ebe-4717-bb32-d957be2c7e02") });

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("5dda08f4-4062-4188-8419-2e81ed73ac03"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("ac3e27a8-98be-41f9-a19e-93c57729ea6e"));

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("1068bebc-1ebe-4717-bb32-d957be2c7e02"));

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("483c2ab9-b31c-4dd6-8064-c94ca58abc24"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0c14dd28-1d65-4819-a202-1b81dd6de0ad"));

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Articles",
                newName: "ProfileImageUrl");

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
    }
}
