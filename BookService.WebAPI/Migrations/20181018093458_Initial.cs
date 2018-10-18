﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookService.WebAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publisher",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    ISBN = table.Column<string>(nullable: true),
                    NumberOfPages = table.Column<int>(nullable: false),
                    AuthorId = table.Column<int>(nullable: true),
                    PublisherId = table.Column<int>(nullable: true),
                    FileName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Book_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Book_Publisher_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publisher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "BirthDate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(1980, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "James", "Sharp" },
                    { 2, new DateTime(1992, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sophie", "Netty" },
                    { 3, new DateTime(1996, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elisa", "Yammy" }
                });

            migrationBuilder.InsertData(
                table: "Publisher",
                columns: new[] { "Id", "Country", "Name" },
                values: new object[,]
                {
                    { 1, "UK", "IT-Publishers" },
                    { 2, "Sweden", "FoodBooks" }
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "AuthorId", "FileName", "ISBN", "NumberOfPages", "PublisherId", "Title" },
                values: new object[,]
                {
                    { 1, 1, null, "123456789", 420, 1, "Learning C#" },
                    { 2, 2, "book2.jpg", "45689132", 360, 1, "Mastering Linq" },
                    { 3, 1, "book3.jpg", "15856135", 360, 1, "Mastering Xamarin" },
                    { 4, 2, "book1.jpg", "56789564", 360, 1, "Exploring ASP.Net Core 2.0" },
                    { 5, 2, "book2.jpg", "234546684", 420, 1, "Unity Game Development" },
                    { 6, 3, "book3.jpg", "789456258", 40, 2, "Cooking is fun" },
                    { 7, 3, "book3.jpg", "94521546", 53, 2, "Secret recipes" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_AuthorId",
                table: "Book",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_PublisherId",
                table: "Book",
                column: "PublisherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "Publisher");
        }
    }
}
