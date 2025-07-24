using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Target1.Migrations
{
    /// <inheritdoc />
    public partial class AddBankingAffer3ToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BankingAffer3",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BanksId = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Loan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankingAffer3", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankingAffer3_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BankingAffer3_BanksAffer_BanksId",
                        column: x => x.BanksId,
                        principalTable: "BanksAffer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankingAffer3_ApplicationUserId",
                table: "BankingAffer3",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BankingAffer3_BanksId",
                table: "BankingAffer3",
                column: "BanksId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankingAffer3");
        }
    }
}
