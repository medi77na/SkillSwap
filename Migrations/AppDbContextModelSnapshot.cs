﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SkillSwap.Models;

#nullable disable

namespace SkillSwap.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8_general_ci")
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8");
            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("SkillSwap.Models.Ability", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Abilities")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("abilities");

                    b.Property<string>("Category")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("category");

                    b.HasKey("Id");

                    b.ToTable("Abilities");
                });

            modelBuilder.Entity("SkillSwap.Models.Qualification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AccumulatorAdition")
                        .HasColumnType("int(11)")
                        .HasColumnName("accumulator_adition");

                    b.Property<int?>("Count")
                        .HasColumnType("int(11)")
                        .HasColumnName("count");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("Qualifications");
                });

            modelBuilder.Entity("SkillSwap.Models.Report", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ActionTaken")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("action_taken");

                    b.Property<DateOnly>("DateReport")
                        .HasColumnType("date")
                        .HasColumnName("date_report");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("description");

                    b.Property<int>("IdReportedUser")
                        .HasColumnType("int(11)")
                        .HasColumnName("id_user_reported");

                    b.Property<int>("IdState")
                        .HasColumnType("int")
                        .HasColumnName("id_state_report");

                    b.Property<int>("IdUser")
                        .HasColumnType("int(11)")
                        .HasColumnName("id_user");

                    b.Property<string>("TitleReport")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.HasIndex("IdReportedUser");

                    b.HasIndex("IdState");

                    b.HasIndex("IdUser");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("SkillSwap.Models.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("description");

                    b.Property<string>("DisponibilitySchedule")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("disponibility_schedule");

                    b.Property<int?>("IdReceivingUser")
                        .HasColumnType("int(11)")
                        .HasColumnName("id_receiving_user");

                    b.Property<int?>("IdRequestingUser")
                        .HasColumnType("int(11)")
                        .HasColumnName("id_requesting_user");

                    b.Property<int?>("IdStateRequest")
                        .HasColumnType("int(11)")
                        .HasColumnName("id_state_request");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdReceivingUser" }, "id_receiving_user");

                    b.HasIndex(new[] { "IdRequestingUser" }, "id_requesting_user");

                    b.HasIndex(new[] { "IdStateRequest" }, "id_state_request");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("SkillSwap.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Responsable de la gestión y configuración del sitio, incluyendo la moderación de contenido, la gestión de usuarios.",
                            Name = "Administrador"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Un profesional que busca oportunidades laborales o empleadores que buscan candidatos.",
                            Name = "Usuario"
                        });
                });

            modelBuilder.Entity("SkillSwap.Models.StateReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("State_reports");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "El reporte no ha sido solucionado y está esperando revisión o respuesta por parte del administrador.",
                            Name = "Pendiente"
                        },
                        new
                        {
                            Id = 2,
                            Description = "El reporte esta siendo revisado por el administrador.",
                            Name = "En proceso"
                        },
                        new
                        {
                            Id = 3,
                            Description = "El reporte ha sido revisado y aceptado por el administrador.",
                            Name = "Resuelto"
                        });
                });

            modelBuilder.Entity("SkillSwap.Models.StateRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("State_requests", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "La solicitud ha sido enviada y está esperando revisión o respuesta por parte del destinatario.",
                            Name = "Pendiente"
                        },
                        new
                        {
                            Id = 2,
                            Description = "La solicitud ha sido revisada y aceptada por el destinatario, lo que indica que se ha establecido una conexión o se ha acordado proceder con la solicitud.",
                            Name = "Aceptado"
                        },
                        new
                        {
                            Id = 3,
                            Description = "La solicitud ha sido revisada pero no ha sido aceptada por el destinatario, lo que indica que no se procederá con la solicitud en este momento.",
                            Name = "Rechazado"
                        });
                });

            modelBuilder.Entity("SkillSwap.Models.StateUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("description");

                    b.Property<int?>("DurationSuspension")
                        .HasColumnType("int(11)")
                        .HasColumnName("duration_suspension");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("State_users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "La cuenta está completamente operativa y en uso.",
                            DurationSuspension = 0,
                            Name = "Activo"
                        },
                        new
                        {
                            Id = 2,
                            Description = " La cuenta ha sido revisada y está en un estado de pausa o desactivación temporal. ",
                            DurationSuspension = 0,
                            Name = "Inactivo"
                        },
                        new
                        {
                            Id = 3,
                            Description = "La cuenta ha sido suspendida durante 5 dias",
                            DurationSuspension = 5,
                            Name = "Suspendido"
                        });
                });

            modelBuilder.Entity("SkillSwap.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Birthdate")
                        .HasColumnType("date")
                        .HasColumnName("birthdate");

                    b.Property<DateOnly>("CreatedAt")
                        .HasColumnType("date")
                        .HasColumnName("createdAt");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("description");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("email");

                    b.Property<int?>("IdAbility")
                        .HasColumnType("int");

                    b.Property<int?>("IdQualification")
                        .HasColumnType("int(11)")
                        .HasColumnName("id_qualification");

                    b.Property<int?>("IdRol")
                        .HasColumnType("int(11)")
                        .HasColumnName("id_rol");

                    b.Property<int?>("IdState")
                        .HasColumnType("int(11)")
                        .HasColumnName("id_state");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("job_title");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("last_name");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("password");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("phone_number");

                    b.Property<string>("UrlBehance")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("url_behance");

                    b.Property<string>("UrlGithub")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("url_github");

                    b.Property<string>("UrlImage")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("url_image");

                    b.Property<string>("UrlLinkedin")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("url_linkedin");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex("IdAbility")
                        .IsUnique();

                    b.HasIndex("IdQualification")
                        .IsUnique();

                    b.HasIndex(new[] { "IdRol" }, "id_rol");

                    b.HasIndex(new[] { "IdState" }, "id_state");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SkillSwap.Models.Report", b =>
                {
                    b.HasOne("SkillSwap.Models.User", "UserReported")
                        .WithMany()
                        .HasForeignKey("IdReportedUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SkillSwap.Models.StateReport", "StateReport")
                        .WithMany()
                        .HasForeignKey("IdState")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SkillSwap.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StateReport");

                    b.Navigation("User");

                    b.Navigation("UserReported");
                });

            modelBuilder.Entity("SkillSwap.Models.Request", b =>
                {
                    b.HasOne("SkillSwap.Models.User", "IdReceivingUserNavigation")
                        .WithMany("RequestIdReceivingUserNavigations")
                        .HasForeignKey("IdReceivingUser")
                        .HasConstraintName("Requests_ibfk_2");

                    b.HasOne("SkillSwap.Models.User", "IdRequestingUserNavigation")
                        .WithMany("RequestIdRequestingUserNavigations")
                        .HasForeignKey("IdRequestingUser")
                        .HasConstraintName("Requests_ibfk_3");

                    b.HasOne("SkillSwap.Models.StateRequest", "IdStateRequestNavigation")
                        .WithMany("Requests")
                        .HasForeignKey("IdStateRequest")
                        .HasConstraintName("Requests_ibfk_1");

                    b.Navigation("IdReceivingUserNavigation");

                    b.Navigation("IdRequestingUserNavigation");

                    b.Navigation("IdStateRequestNavigation");
                });

            modelBuilder.Entity("SkillSwap.Models.User", b =>
                {
                    b.HasOne("SkillSwap.Models.Ability", "Ability")
                        .WithOne("User")
                        .HasForeignKey("SkillSwap.Models.User", "IdAbility")
                        .HasConstraintName("Users_ibfk_3");

                    b.HasOne("SkillSwap.Models.Qualification", "Qualification")
                        .WithOne("User")
                        .HasForeignKey("SkillSwap.Models.User", "IdQualification")
                        .HasConstraintName("Qualification_CualificationProfile_FK");

                    b.HasOne("SkillSwap.Models.Role", "IdRolNavigation")
                        .WithMany("Users")
                        .HasForeignKey("IdRol")
                        .HasConstraintName("Users_ibfk_2");

                    b.HasOne("SkillSwap.Models.StateUser", "IdStateNavigation")
                        .WithMany("Users")
                        .HasForeignKey("IdState")
                        .HasConstraintName("Users_ibfk_1");

                    b.Navigation("Ability");

                    b.Navigation("IdRolNavigation");

                    b.Navigation("IdStateNavigation");

                    b.Navigation("Qualification");
                });

            modelBuilder.Entity("SkillSwap.Models.Ability", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("SkillSwap.Models.Qualification", b =>
                {
                    b.Navigation("User")
                        .IsRequired();
                });

            modelBuilder.Entity("SkillSwap.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("SkillSwap.Models.StateRequest", b =>
                {
                    b.Navigation("Requests");
                });

            modelBuilder.Entity("SkillSwap.Models.StateUser", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("SkillSwap.Models.User", b =>
                {
                    b.Navigation("RequestIdReceivingUserNavigations");

                    b.Navigation("RequestIdRequestingUserNavigations");
                });
#pragma warning restore 612, 618
        }
    }
}
