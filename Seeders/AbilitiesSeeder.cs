using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkillSwap.Models;

namespace SkillSwap.Seeders
{
    public class AbilitiesSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ability>().HasData(
                new Ability { Id = 1, Category = "Desarrollo", Abilities = "Programación en C#, Desarrollo Web, Bases de Datos" },
                new Ability { Id = 2, Category = "Diseño", Abilities = "Diseño Gráfico, UX/UI, Illustrator" },
                new Ability { Id = 3, Category = "Comunicación", Abilities = "Habilidades de Presentación, Redacción, Negociación" },
                new Ability { Id = 4, Category = "Marketing", Abilities = "Estrategias de SEO, Marketing de Contenidos, Publicidad Digital" },
                new Ability { Id = 5, Category = "Entretenimiento", Abilities = "Producción de Video, Edición de Audio, Actuación" },
                new Ability { Id = 6, Category = "Desarrollo", Abilities = "JavaScript, HTML, CSS" },
                new Ability { Id = 7, Category = "Diseño", Abilities = "UX/UI, Adobe Photoshop, Illustrator" },
                new Ability { Id = 8, Category = "Comunicación", Abilities = "Redacción, Presentaciones, Relaciones Públicas" },
                new Ability { Id = 9, Category = "Marketing", Abilities = "Marketing de Contenidos, PPC, Email Marketing" },
                new Ability { Id = 10, Category = "Entretenimiento", Abilities = "Edición de Video, Producción de Podcast, Fotografía" }
            );
        }
    }
}