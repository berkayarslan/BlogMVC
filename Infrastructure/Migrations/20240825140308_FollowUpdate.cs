using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class FollowUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "UserTopics",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TopicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTopics", x => new { x.UserId, x.TopicId });
                    table.ForeignKey(
                        name: "FK_UserTopics_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTopics_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTopics_TopicId",
                table: "UserTopics",
                column: "TopicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserTopics");

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
    }
}
