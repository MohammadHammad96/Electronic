using Microsoft.EntityFrameworkCore.Migrations;

namespace Electronic.API.Migrations
{
    public partial class InsertBasicSubCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO SubCategories (Name, CategoryId) VALUES ('Touch'" +
               ", (SELECT Id FROM Categories WHERE NAME = 'Phone'))");
            migrationBuilder.Sql("INSERT INTO SubCategories (Name, CategoryId) VALUES ('Buttons'" +
               ", (SELECT Id FROM Categories WHERE NAME = 'Phone'))");
            migrationBuilder.Sql("INSERT INTO SubCategories (Name, CategoryId) VALUES ('Touch & buttons'" +
               ", (SELECT Id FROM Categories WHERE NAME = 'Phone'))");
            migrationBuilder.Sql("INSERT INTO SubCategories (Name, CategoryId) VALUES ('Top Freezer'" +
               ", (SELECT Id FROM Categories WHERE NAME = 'Refrigerator'))");
            migrationBuilder.Sql("INSERT INTO SubCategories (Name, CategoryId) VALUES ('Side-by-Side'" +
               ", (SELECT Id FROM Categories WHERE NAME = 'Refrigerator'))");
            migrationBuilder.Sql("INSERT INTO SubCategories (Name, CategoryId) VALUES ('French Door'" +
               ", (SELECT Id FROM Categories WHERE NAME = 'Refrigerator'))");
            migrationBuilder.Sql("INSERT INTO SubCategories (Name, CategoryId) VALUES ('Top load agitator'" +
               ", (SELECT Id FROM Categories WHERE NAME = 'Washer'))");
            migrationBuilder.Sql("INSERT INTO SubCategories (Name, CategoryId) VALUES ('Front load'" +
               ", (SELECT Id FROM Categories WHERE NAME = 'Washer'))");
            migrationBuilder.Sql("INSERT INTO SubCategories (Name, CategoryId) VALUES ('Top load impeller'" +
               ", (SELECT Id FROM Categories WHERE NAME = 'Washer'))");
            migrationBuilder.Sql("INSERT INTO SubCategories (Name, CategoryId) VALUES ('LCD'" +
               ", (SELECT Id FROM Categories WHERE NAME = 'Screen'))");
            migrationBuilder.Sql("INSERT INTO SubCategories (Name, CategoryId) VALUES ('LED'" +
               ", (SELECT Id FROM Categories WHERE NAME = 'Screen'))");
            migrationBuilder.Sql("INSERT INTO SubCategories (Name, CategoryId) VALUES ('QLED'" +
               ", (SELECT Id FROM Categories WHERE NAME = 'Screen'))");
            migrationBuilder.Sql("INSERT INTO SubCategories (Name, CategoryId) VALUES ('Convection'" +
               ", (SELECT Id FROM Categories WHERE NAME = 'Oven'))");
            migrationBuilder.Sql("INSERT INTO SubCategories (Name, CategoryId) VALUES ('Conveyor'" +
               ", (SELECT Id FROM Categories WHERE NAME = 'Oven'))");
            migrationBuilder.Sql("INSERT INTO SubCategories (Name, CategoryId) VALUES ('Rotisserie'" +
               ", (SELECT Id FROM Categories WHERE NAME = 'Oven'))");
            migrationBuilder.Sql("INSERT INTO SubCategories (Name, CategoryId) VALUES ('Steam'" +
               ", (SELECT Id FROM Categories WHERE NAME = 'Oven'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM SubCategories WHERE Name IN ('Touch', 'Buttons'" +
               ", 'Touch & buttons', 'Top Freezer', 'Side-by-Side', 'French Door', 'Top load agitator')");
            migrationBuilder.Sql("DELETE FROM SubCategories WHERE Name IN ('LCD', 'LED', 'QLED'" +
               ", 'Front load', 'Top load impeller', 'Convection', 'Conveyor', 'Rotisserie', 'Steam')");
        }
    }
}
