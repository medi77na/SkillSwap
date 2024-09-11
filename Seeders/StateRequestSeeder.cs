using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkillSwap.Models;

namespace SkillSwap.Seeders
{
    public class StateRequestSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StateRequest>().HasData(
            new StateRequest { Id = 1, Name = "Pendiente", Description = "La solicitud ha sido enviada y está esperando revisión o respuesta por parte del destinatario." },
            new StateRequest { Id = 2, Name = "Aceptado", Description = "La solicitud ha sido revisada y aceptada por el destinatario, lo que indica que se ha establecido una conexión o se ha acordado proceder con la solicitud." },
            new StateRequest { Id = 3, Name = "Rechazado", Description = "La solicitud ha sido revisada pero no ha sido aceptada por el destinatario, lo que indica que no se procederá con la solicitud en este momento." }
            );
        }
    }
}
