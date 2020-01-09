using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookAPIs_Creation_MVCCore.Migrations
{
    public partial class first_Initialization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(maxLength: 200, nullable: false),
                    isbn = table.Column<string>(maxLength: 10, nullable: false),
                    date_Published = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Reviewers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    first_Name = table.Column<string>(maxLength: 100, nullable: false),
                    last_NameW = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviewers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "BookCategories",
                columns: table => new
                {
                    book_Id = table.Column<int>(nullable: false),
                    category_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCategories", x => new { x.book_Id, x.category_Id });
                    table.ForeignKey(
                        name: "FK_BookCategories_Books_book_Id",
                        column: x => x.book_Id,
                        principalTable: "Books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCategories_Categories_category_Id",
                        column: x => x.category_Id,
                        principalTable: "Categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    first_Name = table.Column<string>(maxLength: 100, nullable: false),
                    last_NameW = table.Column<string>(maxLength: 200, nullable: false),
                    Countryid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.id);
                    table.ForeignKey(
                        name: "FK_Authors_Countries_Countryid",
                        column: x => x.Countryid,
                        principalTable: "Countries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    headline = table.Column<string>(maxLength: 100, nullable: false),
                    review_Text = table.Column<string>(maxLength: 2000, nullable: false),
                    rating = table.Column<int>(nullable: false),
                    Reviewerid = table.Column<int>(nullable: true),
                    Bookid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.id);
                    table.ForeignKey(
                        name: "FK_Reviews_Books_Bookid",
                        column: x => x.Bookid,
                        principalTable: "Books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reviews_Reviewers_Reviewerid",
                        column: x => x.Reviewerid,
                        principalTable: "Reviewers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookAuthors",
                columns: table => new
                {
                    book_Id = table.Column<int>(nullable: false),
                    author_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthors", x => new { x.book_Id, x.author_Id });
                    table.ForeignKey(
                        name: "FK_BookAuthors_Authors_author_Id",
                        column: x => x.author_Id,
                        principalTable: "Authors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAuthors_Books_book_Id",
                        column: x => x.book_Id,
                        principalTable: "Books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Authors_Countryid",
                table: "Authors",
                column: "Countryid");

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_author_Id",
                table: "BookAuthors",
                column: "author_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BookCategories_category_Id",
                table: "BookCategories",
                column: "category_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_Bookid",
                table: "Reviews",
                column: "Bookid");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_Reviewerid",
                table: "Reviews",
                column: "Reviewerid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAuthors");

            migrationBuilder.DropTable(
                name: "BookCategories");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Reviewers");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
