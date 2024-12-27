using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdvanceDataAccessAssignment.Migrations
{
    /// <inheritdoc />
    public partial class filteredtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Electronics_ElectronicId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Electronics");

            migrationBuilder.DropIndex(
                name: "IX_Users_ElectronicId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ElectronicId",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "ElectronicName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ElectronicName",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "ElectronicId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Electronics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Electronics", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_ElectronicId",
                table: "Users",
                column: "ElectronicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Electronics_ElectronicId",
                table: "Users",
                column: "ElectronicId",
                principalTable: "Electronics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
