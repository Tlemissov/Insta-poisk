using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace InstaPoisk.Migrations
{
    public partial class Add_InstaAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SubCategoryTypes",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SubCategories",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "InstaAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    UserName = table.Column<string>(maxLength: 64, nullable: false),
                    Link = table.Column<string>(maxLength: 128, nullable: false),
                    LinkOpened = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    IsPublish = table.Column<bool>(nullable: false),
                    PublishDate = table.Column<DateTime>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstaAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstaAccounts_SubCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "SubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstaAccountToSubCategory",
                columns: table => new
                {
                    AccountId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstaAccountToSubCategory", x => new { x.AccountId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_InstaAccountToSubCategory_InstaAccounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "InstaAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstaAccountToSubCategory_SubCategoryTypes_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "SubCategoryTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InstaAccounts_CategoryId",
                table: "InstaAccounts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InstaAccountToSubCategory_CategoryId",
                table: "InstaAccountToSubCategory",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstaAccountToSubCategory");

            migrationBuilder.DropTable(
                name: "InstaAccounts");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SubCategoryTypes",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SubCategories",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20);
        }
    }
}
