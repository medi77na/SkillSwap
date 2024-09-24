using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkillSwap.Models;

namespace SkillSwap.Seeders
{
    public class ReportSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Report>().HasData(
                new Report
                {
                    Id = 1,
                    TitleReport = "Inactividad en la solicitud",
                    Description = "El usuario no respondió a la solicitud de conexión.",
                    DateReport = new DateOnly(2024, 9, 1),
                    ActionTaken = "Se envió un recordatorio al usuario.",
                    IdState = 1,
                    IdUser = 1,            // ID del usuario que reporta
                    IdReportedUser = 2     // ID del usuario reportado
                },
                new Report
                {
                    Id = 2,
                    TitleReport = "Comportamiento inapropiado",
                    Description = "El usuario hizo comentarios ofensivos en la conversación.",
                    DateReport = new DateOnly(2024, 9, 2),
                    ActionTaken = "Se revisó el historial de mensajes.",
                    IdState = 1,
                    IdUser = 3,            // ID del usuario que reporta
                    IdReportedUser = 4     // ID del usuario reportado
                },
                new Report
                {
                    Id = 3,
                    TitleReport = "Solicitud de conexión ignorada",
                    Description = "El usuario ha ignorado múltiples solicitudes de conexión.",
                    DateReport = new DateOnly(2024, 9, 3),
                    ActionTaken = "Se notificó al usuario sobre la inactividad.",
                    IdState = 1,
                    IdUser = 5,            // ID del usuario que reporta
                    IdReportedUser = 6     // ID del usuario reportado
                },
                new Report
                {
                    Id = 4,
                    TitleReport = "Malentendidos en la comunicación",
                    Description = "Se reportaron malentendidos constantes en el intercambio de mensajes.",
                    DateReport = new DateOnly(2024, 9, 4),
                    ActionTaken = "Se propuso una reunión para aclarar malentendidos.",
                    IdState = 1,
                    IdUser = 7,            // ID del usuario que reporta
                    IdReportedUser = 8     // ID del usuario reportado
                },
                new Report
                {
                    Id = 5,
                    TitleReport = "Solicitud de consejo no respondida",
                    Description = "El usuario solicitó ayuda pero no recibió respuesta.",
                    DateReport = new DateOnly(2024, 9, 5),
                    ActionTaken = "Se contactó al usuario para ofrecer asistencia.",
                    IdState = 1,
                    IdUser = 9,            // ID del usuario que reporta
                    IdReportedUser = 10    // ID del usuario reportado
                }
            );
        }
    }
}