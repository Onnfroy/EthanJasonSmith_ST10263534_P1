using Microsoft.EntityFrameworkCore.Migrations;

namespace CLDV6211_POE_P1.Migrations
{
    public partial class DropAndRecreateProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Drop the existing Products table if it exists
            migrationBuilder.Sql("IF OBJECT_ID('dbo.Products', 'U') IS NOT NULL DROP TABLE dbo.Products;");

            // Recreate the Products table with the new schema
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drop the new Products table
            migrationBuilder.DropTable(
                name: "Products");

            // Recreate the original Products table
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });
        }
    }
}

