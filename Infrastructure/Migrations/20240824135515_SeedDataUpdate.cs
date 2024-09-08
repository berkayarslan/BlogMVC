using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class SeedDataUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Topics",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Articles",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "Name",
                table: "Topics",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Articles",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Articles",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
