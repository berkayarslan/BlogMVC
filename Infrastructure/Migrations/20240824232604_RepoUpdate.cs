using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class RepoUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ArticleTopics",
                keyColumns: new[] { "ArticleId", "TopicId" },
                keyValues: new object[] { new Guid("aae1d108-1d1c-46a9-b239-65b648efb394"), new Guid("81ba10e9-d1c3-4f25-b129-e237028eefb7") });

            migrationBuilder.DeleteData(
                table: "ArticleTopics",
                keyColumns: new[] { "ArticleId", "TopicId" },
                keyValues: new object[] { new Guid("e0d84f50-1b12-44cf-bd64-2496e149e55d"), new Guid("81d4dc23-98e1-49ac-91d5-357dd2ada4de") });

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("aae1d108-1d1c-46a9-b239-65b648efb394"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("e0d84f50-1b12-44cf-bd64-2496e149e55d"));

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("81ba10e9-d1c3-4f25-b129-e237028eefb7"));

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("81d4dc23-98e1-49ac-91d5-357dd2ada4de"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d4abc37e-b28b-4ea4-8735-af743c645497"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Bio", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImageUrl", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("d4abc37e-b28b-4ea4-8735-af743c645497"), 0, null, "e5db61a3-3485-4ee3-967e-ef8fbd11954b", "admin@blog.com", true, "Admin", "admin", false, null, "ADMIN@BLOG.COM", "ADMIN@BLOG.COM", "AQAAAAEAACcQAAAAELsBr3GqQrC/5WDg/wXBaVkCdRFIDs8E+82XMWOVcnfaS9gYFyvTtEai4N3VMm3wng==", null, false, null, "", false, "admin@blog.com" });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("81ba10e9-d1c3-4f25-b129-e237028eefb7"), "Technology" });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("81d4dc23-98e1-49ac-91d5-357dd2ada4de"), "Science" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "ReadCount", "Title" },
                values: new object[] { new Guid("aae1d108-1d1c-46a9-b239-65b648efb394"), new Guid("d4abc37e-b28b-4ea4-8735-af743c645497"), "Artificial Intelligence (AI) is transforming industries...", new DateTime(2024, 8, 24, 14, 35, 15, 262, DateTimeKind.Utc).AddTicks(9247), 0, "The Future of AI" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "ReadCount", "Title" },
                values: new object[] { new Guid("e0d84f50-1b12-44cf-bd64-2496e149e55d"), new Guid("d4abc37e-b28b-4ea4-8735-af743c645497"), "The medical field is rapidly evolving with new technologies...", new DateTime(2024, 8, 24, 14, 35, 15, 262, DateTimeKind.Utc).AddTicks(9248), 0, "Advances in Medicine" });

            migrationBuilder.InsertData(
                table: "ArticleTopics",
                columns: new[] { "ArticleId", "TopicId" },
                values: new object[] { new Guid("aae1d108-1d1c-46a9-b239-65b648efb394"), new Guid("81ba10e9-d1c3-4f25-b129-e237028eefb7") });

            migrationBuilder.InsertData(
                table: "ArticleTopics",
                columns: new[] { "ArticleId", "TopicId" },
                values: new object[] { new Guid("e0d84f50-1b12-44cf-bd64-2496e149e55d"), new Guid("81d4dc23-98e1-49ac-91d5-357dd2ada4de") });
        }
    }
}
