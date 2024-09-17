using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkillSwap.Models;

namespace SkillSwap.Seeders
{
    public class StateReportSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StateReport>().HasData(
            new StateReport { Id = 1, Name = "Pendiente", Description = "El reporte no ha sido solucionado y está esperando revisión o respuesta por parte del administrador." },
            new StateReport { Id = 2, Name = "En proceso", Description = "El reporte esta siendo revisado por el administrador." },
            new StateReport { Id = 3, Name = "Resuelto", Description = "El reporte ha sido revisado y aceptado por el administrador." }
            );
        }
    }
}