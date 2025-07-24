using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Target1.Migrations
{
    /// <inheritdoc />
    public partial class AddBanksAfferToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BanksAffer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankId = table.Column<int>(type: "int", nullable: true),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rates = table.Column<double>(type: "float", nullable: false),
                    LimitLine = table.Column<int>(type: "int", nullable: false),
                    Imagurl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BanksAffer", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BanksAffer");
        }
    }
}
