using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillSwap.Migrations
{
    /// <inheritdoc />
    public partial class CambioEstructuraAbility : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users_abilities");

            migrationBuilder.AddColumn<int>(
                name: "IdAbility",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdAbility",
                table: "Users",
                column: "IdAbility",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "Users_ibfk_3",
                table: "Users",
                column: "IdAbility",
                principalTable: "Abilities",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Users_ibfk_3",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_IdAbility",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IdAbility",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "Users_abilities",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    id_ability = table.Column<int>(type: "int", nullable: false),
                    id_user = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users_abilities", x => x.id);
                    table.ForeignKey(
                        name: "FK_Users_abilities_Abilities_id_ability",
                        column: x => x.id_ability,
                        principalTable: "Abilities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_abilities_Users_id_user",
                        column: x => x.id_user,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Users_abilities_id_ability",
                table: "Users_abilities",
                column: "id_ability");

            migrationBuilder.CreateIndex(
                name: "IX_Users_abilities_id_user",
                table: "Users_abilities",
                column: "id_user");
        }
    }
}
