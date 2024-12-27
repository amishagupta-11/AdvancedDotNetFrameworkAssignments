using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdvanceDataAccessAssignment.Migrations
{
    /// <inheritdoc />
    public partial class AddingUsersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
    name: "Users",
    columns: table => new
    {
        UserId = table.Column<int>(type: "int", nullable: false)
            .Annotation("SqlServer:Identity", "1, 1"),
        UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
        PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
        EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
        ElectronicId = table.Column<int>(type: "int", nullable: false)
    },
    constraints: table =>
    {
        table.PrimaryKey("PK_Users", x => x.UserId);
        table.ForeignKey(
            name: "FK_Users_Electronics_ElectronicId",
            column: x => x.ElectronicId,
            principalTable: "Electronics",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    });

            migrationBuilder.CreateIndex(
                name: "IX_Users_ElectronicId",
                table: "Users",
                column: "ElectronicId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");           
        }
    }
}
