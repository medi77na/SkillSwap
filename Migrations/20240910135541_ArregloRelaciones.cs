using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillSwap.Migrations
{
    /// <inheritdoc />
    public partial class ArregloRelaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Qualifications_ibfk_1",
                table: "Qualifications");

            migrationBuilder.DropIndex(
                name: "id_user",
                table: "Qualifications");

            migrationBuilder.DropColumn(
                name: "id_user",
                table: "Qualifications");

            migrationBuilder.CreateIndex(
                name: "IX_Users_id_qualification",
                table: "Users",
                column: "id_qualification",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "Qualification_CualificationProfile_FK",
                table: "Users",
                column: "id_qualification",
                principalTable: "Qualifications",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Qualification_CualificationProfile_FK",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_id_qualification",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "id_user",
                table: "Qualifications",
                type: "int(11)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "id_user",
                table: "Qualifications",
                column: "id_user");

            migrationBuilder.AddForeignKey(
                name: "Qualifications_ibfk_1",
                table: "Qualifications",
                column: "id_user",
                principalTable: "Users",
                principalColumn: "id");
        }
    }
}
