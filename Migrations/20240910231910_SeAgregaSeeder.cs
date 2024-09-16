using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkillSwap.Migrations
{
    /// <inheritdoc />
    public partial class SeAgregaSeeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "id", "description", "name" },
                values: new object[,]
                {
                    { 1, "Responsable de la gestión y configuración del sitio, incluyendo la moderación de contenido, la gestión de usuarios.", "Administrador" },
                    { 2, "Un profesional que busca oportunidades laborales o empleadores que buscan candidatos.", "Usuario" }
                });

            migrationBuilder.InsertData(
                table: "State_requests",
                columns: new[] { "id", "description", "name" },
                values: new object[,]
                {
                    { 1, "La solicitud ha sido enviada y está esperando revisión o respuesta por parte del destinatario.", "Pendiente" },
                    { 2, "La solicitud ha sido revisada y aceptada por el destinatario, lo que indica que se ha establecido una conexión o se ha acordado proceder con la solicitud.", "Aceptado" },
                    { 3, "La solicitud ha sido revisada pero no ha sido aceptada por el destinatario, lo que indica que no se procederá con la solicitud en este momento.", "Rechazado" }
                });

            migrationBuilder.InsertData(
                table: "State_users",
                columns: new[] { "id", "description", "duration_suspension", "name" },
                values: new object[,]
                {
                    { 1, "La cuenta está completamente operativa y en uso.", 0, "Activo" },
                    { 2, " La cuenta ha sido revisada y está en un estado de pausa o desactivación temporal. ", 0, "Inactivo" },
                    { 3, "La cuenta ha sido suspendida", 0, "Suspendido" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "State_requests",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "State_requests",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "State_requests",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "State_users",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "State_users",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "State_users",
                keyColumn: "id",
                keyValue: 3);
        }
    }
}
