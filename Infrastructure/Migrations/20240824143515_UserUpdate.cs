using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class UserUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ArticleTopics",
                keyColumns: new[] { "ArticleId", "TopicId" },
                keyValues: new object[] { new Guid("6edf85ed-8400-46aa-ba45-ace775193ce8"), new Guid("b8896894-8af6-45bd-ad77-e19d948897c4") });

            migrationBuilder.DeleteData(
                table: "ArticleTopics",
                keyColumns: new[] { "ArticleId", "TopicId" },
                keyValues: new object[] { new Guid("dcda4b8c-9442-4e21-8c80-62c5551b85e0"), new Guid("417f5e01-4ac5-4e51-8d3c-ca09544e8a15") });

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("6edf85ed-8400-46aa-ba45-ace775193ce8"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("dcda4b8c-9442-4e21-8c80-62c5551b85e0"));

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("417f5e01-4ac5-4e51-8d3c-ca09544e8a15"));

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("b8896894-8af6-45bd-ad77-e19d948897c4"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d0190949-6c81-4744-b780-d778541f33af"));

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Bio", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImageUrl", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("d0190949-6c81-4744-b780-d778541f33af"), 0, null, "bf39a2a8-84d2-4948-9376-c159efb4bc73", "admin@blog.com", true, "Admin", "admin", false, null, "ADMIN@BLOG.COM", "ADMIN@BLOG.COM", "AQAAAAEAACcQAAAAECs7XYQQEpnZVSiTsK1bMY0jm+f76Mv6R0p2SJRFelTAJQma+luRSBUYWM8eJiQ9KA==", null, false, null, "", false, "admin@blog.com" });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("417f5e01-4ac5-4e51-8d3c-ca09544e8a15"), "Technology" });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("b8896894-8af6-45bd-ad77-e19d948897c4"), "Science" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "ReadCount", "Title" },
                values: new object[] { new Guid("6edf85ed-8400-46aa-ba45-ace775193ce8"), new Guid("d0190949-6c81-4744-b780-d778541f33af"), "The medical field is rapidly evolving with new technologies...", new DateTime(2024, 8, 24, 13, 55, 14, 915, DateTimeKind.Utc).AddTicks(1359), 0, "Advances in Medicine" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "ReadCount", "Title" },
                values: new object[] { new Guid("dcda4b8c-9442-4e21-8c80-62c5551b85e0"), new Guid("d0190949-6c81-4744-b780-d778541f33af"), "Artificial Intelligence (AI) is transforming industries...", new DateTime(2024, 8, 24, 13, 55, 14, 915, DateTimeKind.Utc).AddTicks(1357), 0, "The Future of AI" });

            migrationBuilder.InsertData(
                table: "ArticleTopics",
                columns: new[] { "ArticleId", "TopicId" },
                values: new object[] { new Guid("6edf85ed-8400-46aa-ba45-ace775193ce8"), new Guid("b8896894-8af6-45bd-ad77-e19d948897c4") });

            migrationBuilder.InsertData(
                table: "ArticleTopics",
                columns: new[] { "ArticleId", "TopicId" },
                values: new object[] { new Guid("dcda4b8c-9442-4e21-8c80-62c5551b85e0"), new Guid("417f5e01-4ac5-4e51-8d3c-ca09544e8a15") });
        }
    }
}
