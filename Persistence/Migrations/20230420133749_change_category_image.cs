using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class change_category_image : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoriesImages_ImageFilesCategory_CategoryImageId",
                table: "CategoriesImages");

            migrationBuilder.DropTable(
                name: "ImageFilesCategory");

            migrationBuilder.AddColumn<bool>(
                name: "BlogPostImageFıle_Showcase",
                table: "Files",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriesImages_Files_CategoryImageId",
                table: "CategoriesImages",
                column: "CategoryImageId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoriesImages_Files_CategoryImageId",
                table: "CategoriesImages");

            migrationBuilder.DropColumn(
                name: "BlogPostImageFıle_Showcase",
                table: "Files");

            migrationBuilder.CreateTable(
                name: "ImageFilesCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Showcase = table.Column<bool>(type: "boolean", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageFilesCategory", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriesImages_ImageFilesCategory_CategoryImageId",
                table: "CategoriesImages",
                column: "CategoryImageId",
                principalTable: "ImageFilesCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
