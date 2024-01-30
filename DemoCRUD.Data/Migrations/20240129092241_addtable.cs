using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoCRUD.Data.Migrations
{
    /// <inheritdoc />
    public partial class addtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "tblGender",
                columns: table => new
                {
                    GenderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenderName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblGender", x => x.GenderID);
                });

            migrationBuilder.CreateTable(
                name: "tblState",
                columns: table => new
                {
                    StateID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblState", x => x.StateID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_GenderId",
                table: "Students",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_StateId",
                table: "Students",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_tblGender_GenderId",
                table: "Students",
                column: "GenderId",
                principalTable: "tblGender",
                principalColumn: "GenderID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_tblState_StateId",
                table: "Students",
                column: "StateId",
                principalTable: "tblState",
                principalColumn: "StateID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_tblGender_GenderId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_tblState_StateId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "tblGender");

            migrationBuilder.DropTable(
                name: "tblState");

            migrationBuilder.DropIndex(
                name: "IX_Students_GenderId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_StateId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "Students");
        }
    }
}
