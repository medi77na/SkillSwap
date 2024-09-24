using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkillSwap.Migrations
{
    /// <inheritdoc />
    public partial class SeAgreganSeeders2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "State_reports",
                columns: new[] { "Id", "description", "name" },
                values: new object[,]
                {
                    { 1, "El reporte no ha sido solucionado y está esperando revisión o respuesta por parte del administrador.", "Pendiente" },
                    { 2, "El reporte esta siendo revisado por el administrador.", "En proceso" },
                    { 3, "El reporte ha sido revisado y aceptado por el administrador.", "Resuelto" }
                });
            migrationBuilder.InsertData(
                table: "Abilities",
                columns: new[] { "id", "abilities", "category" },
                values: new object[,]
                {
                    { 1, "Programación en C#, Desarrollo Web, Bases de Datos", "Desarrollo" },
                    { 2, "Diseño Gráfico, UX/UI, Illustrator", "Diseño" },
                    { 3, "Habilidades de Presentación, Redacción, Negociación", "Comunicación" },
                    { 4, "Estrategias de SEO, Marketing de Contenidos, Publicidad Digital", "Marketing" },
                    { 5, "Producción de Video, Edición de Audio, Actuación", "Entretenimiento" },
                    { 6, "JavaScript, HTML, CSS", "Desarrollo" },
                    { 7, "UX/UI, Adobe Photoshop, Illustrator", "Diseño" },
                    { 8, "Redacción, Presentaciones, Relaciones Públicas", "Comunicación" },
                    { 9, "Marketing de Contenidos, PPC, Email Marketing", "Marketing" },
                    { 10, "Edición de Video, Producción de Podcast, Fotografía", "Entretenimiento" }
                });

            migrationBuilder.InsertData(
                table: "Qualifications",
                columns: new[] { "id", "accumulator_adition", "count" },
                values: new object[,]
                {
                    { 1, 35, 10 },
                    { 2, 15, 5 },
                    { 3, 60, 15 },
                    { 4, 24, 8 },
                    { 5, 45, 12 },
                    { 6, 35, 10 },
                    { 7, 15, 5 },
                    { 8, 60, 15 },
                    { 9, 24, 8 },
                    { 10, 45, 12 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Qualifications",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Qualifications",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Qualifications",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Qualifications",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Qualifications",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Qualifications",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Qualifications",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Qualifications",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Qualifications",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Qualifications",
                keyColumn: "id",
                keyValue: 10);
        }
    }
}
