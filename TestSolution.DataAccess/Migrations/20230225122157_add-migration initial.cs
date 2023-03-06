using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestSolution.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addmigrationinitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SGKKOD = table.Column<int>(type: "int", nullable: false),
                    TCKN = table.Column<long>(type: "bigint", nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BabaAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tutar = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tests");
        }
    }
}
