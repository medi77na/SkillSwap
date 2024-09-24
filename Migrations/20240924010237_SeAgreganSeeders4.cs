using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkillSwap.Migrations
{
    /// <inheritdoc />
    public partial class SeAgreganSeeders4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "Id", "action_taken", "date_report", "description", "id_user_reported", "id_state_report", "id_user", "title" },
                values: new object[,]
                {
                    { 1, "Se envió un recordatorio al usuario.", new DateOnly(2024, 9, 1), "El usuario no respondió a la solicitud de conexión.", 2, 1, 1, "Inactividad en la solicitud" },
                    { 2, "Se revisó el historial de mensajes.", new DateOnly(2024, 9, 2), "El usuario hizo comentarios ofensivos en la conversación.", 4, 1, 3, "Comportamiento inapropiado" },
                    { 3, "Se notificó al usuario sobre la inactividad.", new DateOnly(2024, 9, 3), "El usuario ha ignorado múltiples solicitudes de conexión.", 6, 1, 5, "Solicitud de conexión ignorada" },
                    { 4, "Se propuso una reunión para aclarar malentendidos.", new DateOnly(2024, 9, 4), "Se reportaron malentendidos constantes en el intercambio de mensajes.", 8, 1, 7, "Malentendidos en la comunicación" },
                    { 5, "Se contactó al usuario para ofrecer asistencia.", new DateOnly(2024, 9, 5), "El usuario solicitó ayuda pero no recibió respuesta.", 10, 1, 9, "Solicitud de consejo no respondida" }
                });

            migrationBuilder.InsertData(
                table: "Requests",
                columns: new[] { "id", "description", "disponibility_schedule", "id_receiving_user", "id_requesting_user", "id_state_request" },
                values: new object[,]
                {
                    { 1, "Hola, quiero conectar contigo para aprender sobre desarrollo en C#.", "Lunes a Viernes, 9 AM - 5 PM", 1, 2, 2 },
                    { 2, "¡Hola! Me gustaría aprender sobre diseño gráfico y creo que podrías ayudarme.", "Sábados, 10 AM - 3 PM", 2, 3, 2 },
                    { 3, "Me encantaría aprender más sobre SEO y marketing digital contigo.", "Lunes, Miércoles y Viernes, 1 PM - 4 PM", 3, 4, 2 },
                    { 4, "Hola, estoy interesado en mejorar mis habilidades de comunicación y creo que tú eres la persona adecuada para ayudarme.", "Martes y Jueves, 3 PM - 6 PM", 4, 5, 2 },
                    { 5, "¡Hola! Me gustaría aprender sobre producción de video y creo que tu experiencia puede ser valiosa.", "Todo el día disponible", 5, 6, 2 },
                    { 6, "Quiero mejorar mis habilidades en JavaScript, ¿podemos conectar?", "Lunes a Viernes, 10 AM - 5 PM", 1, 7, 2 },
                    { 7, "Me gustaría aprender más sobre gestión de proyectos, ¿te gustaría ayudarme?", "Sábados, 11 AM - 2 PM", 2, 8, 2 },
                    { 8, "Estoy interesado en estrategias de contenido, ¿puedes ayudarme?", "Martes y Jueves, 1 PM - 4 PM", 3, 9, 2 },
                    { 9, "Hola, quiero aprender sobre edición de video y me gustaría tu guía.", "Lunes a Miércoles, 3 PM - 6 PM", 4, 10, 2 },
                    { 10, "Quiero explorar más sobre análisis de datos, ¿puedes ayudarme?", "Todo el día disponible", 5, 1, 2 },
                    { 11, "Estoy buscando mejorar mis habilidades en UX/UI, ¿puedes asesorarme?", "Lunes a Viernes, 9 AM - 5 PM", 6, 2, 2 },
                    { 12, "Me gustaría aprender sobre marketing en redes sociales, ¿puedes ayudarme?", "Sábados, 10 AM - 3 PM", 7, 3, 1 },
                    { 13, "Hola, quiero mejorar mis habilidades de redacción, ¿podemos conectar?", "Lunes, Miércoles y Viernes, 1 PM - 4 PM", 8, 4, 1 },
                    { 14, "Quiero aprender sobre producción de contenido, ¿puedes asesorarme?", "Martes y Jueves, 3 PM - 6 PM", 9, 5, 1 },
                    { 15, "Hola, me gustaría aprender sobre gestión de tiempo y productividad, ¿puedes ayudarme?", "Todo el día disponible", 10, 1, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "id",
                keyValue: 15);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "AQAAAAIAAYagAAAAEHruOsnMbKhFXd6/yay9YBypEcyAHSNZb7Y/JTrL0YxZrJkno8qsHEmrlY4AVEDIow==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: "AQAAAAIAAYagAAAAECqJixbLTu6Int3XFt3rjZuppKnxyPqFrabpKrxgYjUqXJQjdsaqNcy1kGgDIElqXQ==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "AQAAAAIAAYagAAAAEFdxBIFNcg+F3QnhiCx4UTNflpYKY7KaIQGgvG5sKwBqc5hxo3O1avoB9BBuZWm+Iw==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 4,
                column: "password",
                value: "AQAAAAIAAYagAAAAEBGmgqjt756eGRvzjvUTU0NueOsT1AGhdMOZERo6O8bZLAcJvYHlWHZoEVKItOFdbQ==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 5,
                column: "password",
                value: "AQAAAAIAAYagAAAAEN9fBAoMmgfs822RMB3fyT4Mwa+o+8N8w5yGDR6lhyZJxSKcoVQ2u2aPD5/OXMGmfw==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 6,
                column: "password",
                value: "AQAAAAIAAYagAAAAELpqOPl4r8ACDYYf8KfRxZIDWjrTJ3oS0EZur5/cuu1pkJy/bFqcMJcVrcQr22TB5g==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 7,
                column: "password",
                value: "AQAAAAIAAYagAAAAEEXEFAUcr56TewfkPksfpNPNhyCqn/PW9CHmBHTNHQmmiT3gmMrH/RtLiz7r39+Z8A==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 8,
                column: "password",
                value: "AQAAAAIAAYagAAAAEFSRiiyzMgNF8ihmuFEQri/AMpVJ4hUBl9OHzR91EwFpeAz+TIH0DW4+iuMERMRlrQ==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 9,
                column: "password",
                value: "AQAAAAIAAYagAAAAEDsbClb67rAQ68ich9R51O7RrlGB39ClA/ZhGRQ1acnIBc4R2htUQQrO4nwzs42JNQ==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 10,
                column: "password",
                value: "AQAAAAIAAYagAAAAEEnUgtOTa25XVw/HzmgAgiY4ZA+jtHveiqVxc24+tC72VlEdbL8su8csCtZZMvVNww==");
        }
    }
}
