using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkillSwap.Migrations
{
    /// <inheritdoc />
    public partial class SeAgreganSeeders3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "birthdate", "created_at", "description", "email", "IdAbility", "id_qualification", "id_rol", "id_state", "job_title", "last_name", "name", "password", "password_reset_token", "password_reset_token_expiry", "phone_number", "reactivation_date", "suspension_date", "url_behance", "url_github", "url_image", "url_linkedin" },
                values: new object[,]
                {
                    { 1, new DateOnly(2000, 5, 23), new DateOnly(2024, 9, 23), "Desarrollador full-stack especializado en aplicaciones web.", "arlex.z96@gmail.com", 1, 1, 1, 1, "Desarrollador Web", "zapata", "arlex", "AQAAAAIAAYagAAAAEHruOsnMbKhFXd6/yay9YBypEcyAHSNZb7Y/JTrL0YxZrJkno8qsHEmrlY4AVEDIow==", null, null, "+1234567891", null, null, null, "https://github.com/arlexz96", "https://media.istockphoto.com/id/1200677760/es/foto/retrato-de-apuesto-joven-sonriente-con-los-brazos-cruzados.jpg?s=612x612&w=0&k=20&c=RhKR8pxX3y_YVe5CjrRnTcNFEGDryD2FVOcUT_w3m4w=", "https://www.linkedin.com/in/arlex-zapata-02aab6243/" },
                    { 2, new DateOnly(1999, 3, 14), new DateOnly(2024, 9, 23), "Diseñador creativo con pasión por UX/UI.", "franco@gmail.com", 2, 2, 2, 1, "Diseñador Gráfico", "mena", "franco", "AQAAAAIAAYagAAAAECqJixbLTu6Int3XFt3rjZuppKnxyPqFrabpKrxgYjUqXJQjdsaqNcy1kGgDIElqXQ==", null, null, "+1234567892", null, null, "https://www.behance.net/franccoina", null, "https://media.istockphoto.com/id/1200677760/es/foto/retrato-de-apuesto-joven-sonriente-con-los-brazos-cruzados.jpg?s=612x612&w=0&k=20&c=RhKR8pxX3y_YVe5CjrRnTcNFEGDryD2FVOcUT_w3m4w=", "https://www.linkedin.com/in/franccoina/" },
                    { 3, new DateOnly(2000, 7, 30), new DateOnly(2024, 9, 23), "Experto en comunicaciones corporativas y oratoria.", "jonathan@gmail.com", 3, 3, 2, 1, "Especialista en Comunicaciones", "escobar", "jonathan", "AQAAAAIAAYagAAAAEFdxBIFNcg+F3QnhiCx4UTNflpYKY7KaIQGgvG5sKwBqc5hxo3O1avoB9BBuZWm+Iw==", null, null, "+1234567893", null, null, null, null, "https://st4allthings4p4ci.blob.core.windows.net/allthingshair/allthingshair/wp-content/uploads/sites/13/2023/04/43848/cortes-de-pelo-para-hombres-jovenes-nueva.jpg", "https://www.linkedin.com/in/jonathanescobarm/" },
                    { 4, new DateOnly(2005, 11, 11), new DateOnly(2024, 2, 1), "Estratega de marketing digital enfocado en SEO y marketing de contenidos.", "joan@ejemplo.com", 4, 4, 2, 1, "Especialista en Marketing", "zapata", "joan", "AQAAAAIAAYagAAAAEBGmgqjt756eGRvzjvUTU0NueOsT1AGhdMOZERo6O8bZLAcJvYHlWHZoEVKItOFdbQ==", null, null, "+1234567894", null, null, null, null, "https://media.istockphoto.com/id/1319763895/es/foto/sonriente-raza-mixta-hombre-maduro-sobre-fondo-gris.jpg?s=612x612&w=0&k=20&c=sGBwMEZr8RdyFuOF0084teSTc1TwMzdpHjowP9QRWTw=", "https://www.linkedin.com/in/davebrown" },
                    { 5, new DateOnly(1999, 6, 20), new DateOnly(2024, 1, 1), "Productora y editora con experiencia en producción de video y audio.", "luisa@gmail.com", 5, 5, 2, 1, "Productora de Entretenimiento", "ramirez", "luisa", "AQAAAAIAAYagAAAAEN9fBAoMmgfs822RMB3fyT4Mwa+o+8N8w5yGDR6lhyZJxSKcoVQ2u2aPD5/OXMGmfw==", null, null, "+1234567895", null, null, null, null, "https://media.istockphoto.com/id/1369508766/es/foto/hermosa-mujer-latina-exitosa-sonriendo.jpg?s=612x612&w=0&k=20&c=f-3MdwiVjpE4UWQdqLC3vpWViYMCiGUPr5aKLCmTnDI=", "https://www.linkedin.com/in/luisa-fernanda-ram%C3%ADrez-cardona-0b486565/" },
                    { 6, new DateOnly(1993, 4, 10), new DateOnly(2024, 2, 1), "Desarrolladora web apasionada por el frontend.", "user6@ejemplo.com", 6, 6, 2, 1, "Desarrolladora Frontend", "Torres", "Laura", "AQAAAAIAAYagAAAAELpqOPl4r8ACDYYf8KfRxZIDWjrTJ3oS0EZur5/cuu1pkJy/bFqcMJcVrcQr22TB5g==", null, null, "+1234567801", null, null, null, "https://github.com/lauratorres", "https://randomuser.me/api/portraits/women/6.jpg", "https://www.linkedin.com/in/lauratorres" },
                    { 7, new DateOnly(1985, 8, 20), new DateOnly(2024, 2, 1), "Experto en análisis de datos y visualización.", "user7@ejemplo.com", 7, 7, 2, 1, "Analista de Datos", "Ramírez", "Javier", "AQAAAAIAAYagAAAAEEXEFAUcr56TewfkPksfpNPNhyCqn/PW9CHmBHTNHQmmiT3gmMrH/RtLiz7r39+Z8A==", null, null, "+1234567802", null, null, null, null, "https://randomuser.me/api/portraits/men/7.jpg", "https://www.linkedin.com/in/javierramirez" },
                    { 8, new DateOnly(1991, 12, 15), new DateOnly(2024, 3, 1), "Content creator y especialista en redes sociales.", "user8@ejemplo.com", 8, 8, 2, 1, "Gestora de Redes Sociales", "Gómez", "Sofía", "AQAAAAIAAYagAAAAEFSRiiyzMgNF8ihmuFEQri/AMpVJ4hUBl9OHzR91EwFpeAz+TIH0DW4+iuMERMRlrQ==", null, null, "+1234567803", null, null, "https://www.behance.net/sofiagomez", null, "https://randomuser.me/api/portraits/women/8.jpg", "https://www.linkedin.com/in/sofiagomez" },
                    { 9, new DateOnly(1982, 6, 30), new DateOnly(2024, 4, 1), "Productor de cine y director.", "user9@ejemplo.com", 9, 9, 2, 1, "Productor de Cine", "Martínez", "Fernando", "AQAAAAIAAYagAAAAEDsbClb67rAQ68ich9R51O7RrlGB39ClA/ZhGRQ1acnIBc4R2htUQQrO4nwzs42JNQ==", null, null, "+1234567804", null, null, null, null, "https://randomuser.me/api/portraits/men/9.jpg", "https://www.linkedin.com/in/fernandomartinez" },
                    { 10, new DateOnly(1994, 11, 5), new DateOnly(2024, 5, 1), "Desarrolladora de aplicaciones móviles.", "user10@ejemplo.com", 10, 10, 2, 1, "Desarrolladora Móvil", "Pérez", "Valentina", "AQAAAAIAAYagAAAAEEnUgtOTa25XVw/HzmgAgiY4ZA+jtHveiqVxc24+tC72VlEdbL8su8csCtZZMvVNww==", null, null, "+1234567805", null, null, null, "https://github.com/valentinaperez", "https://randomuser.me/api/portraits/women/10.jpg", "https://www.linkedin.com/in/valentinaperez" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: 10);
        }
    }
}
