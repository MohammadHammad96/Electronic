using Microsoft.EntityFrameworkCore.Migrations;

namespace Electronic.API.Migrations
{
    public partial class InsertBasicCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categories (Name) VALUES ('Phone')");
            migrationBuilder.Sql("INSERT INTO Categories (Name) VALUES ('Refrigerator')");
            migrationBuilder.Sql("INSERT INTO Categories (Name) VALUES ('Washer')");
            migrationBuilder.Sql("INSERT INTO Categories (Name) VALUES ('Screen')");
            migrationBuilder.Sql("INSERT INTO Categories (Name) VALUES ('Oven')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categories WHERE Name IN ('Phone', 'Refrigerator'," +
               " 'Washer', 'Screen', 'Oven')");
        }
    }
}
