﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SkillSwap.Models;

#nullable disable

namespace SkillSwap.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240910015403_CambioDeNombreState_requests")]
    partial class CambioDeNombreState_requests
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8_general_ci")
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8");
            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("SkillSwap.Models.PrimaryAbility", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("Primary_abilities", (string)null);
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

                    b.Property<int?>("IdUser")
                        .HasColumnType("int(11)")
                        .HasColumnName("id_user");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdUser" }, "id_user");

                    b.ToTable("Qualifications");
                });

            modelBuilder.Entity("SkillSwap.Models.Report", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("description");

                    b.Property<int>("IdReportedUser")
                        .HasColumnType("int(11)")
                        .HasColumnName("id_user_reported");

                    b.Property<int>("IdUser")
                        .HasColumnType("int(11)")
                        .HasColumnName("id_usuario");

                    b.Property<string>("TitleReport")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.HasIndex("IdReportedUser");

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
                });

            modelBuilder.Entity("SkillSwap.Models.SecondaryAbility", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("IdPrimaryAbilitie")
                        .HasColumnType("int(11)")
                        .HasColumnName("id_primary_abilitie");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdPrimaryAbilitie" }, "id_primary_abilitie");

                    b.ToTable("Secondary_abilities", (string)null);
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

                    b.ToTable("state_requests", (string)null);
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

                    b.HasIndex(new[] { "IdRol" }, "id_rol");

                    b.HasIndex(new[] { "IdState" }, "id_state");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SkillSwap.Models.UsersSecondaryAbility", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("IdSecondaryAbilitie")
                        .HasColumnType("int(11)")
                        .HasColumnName("id_secondary_abilitie");

                    b.Property<int?>("IdUser")
                        .HasColumnType("int(11)")
                        .HasColumnName("id_user");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdSecondaryAbilitie" }, "id_secondary_abilitie");

                    b.HasIndex(new[] { "IdUser" }, "id_user1");

                    b.ToTable("Users_Secondary_abilities", (string)null);
                });

            modelBuilder.Entity("SkillSwap.Models.Qualification", b =>
                {
                    b.HasOne("SkillSwap.Models.User", "IdUserNavigation")
                        .WithMany("Qualifications")
                        .HasForeignKey("IdUser")
                        .HasConstraintName("Qualifications_ibfk_1");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("SkillSwap.Models.Report", b =>
                {
                    b.HasOne("SkillSwap.Models.User", "UserReported")
                        .WithMany()
                        .HasForeignKey("IdReportedUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SkillSwap.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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

            modelBuilder.Entity("SkillSwap.Models.SecondaryAbility", b =>
                {
                    b.HasOne("SkillSwap.Models.PrimaryAbility", "IdPrimaryAbilitieNavigation")
                        .WithMany("SecondaryAbilities")
                        .HasForeignKey("IdPrimaryAbilitie")
                        .HasConstraintName("Secondary_abilities_ibfk_1");

                    b.Navigation("IdPrimaryAbilitieNavigation");
                });

            modelBuilder.Entity("SkillSwap.Models.User", b =>
                {
                    b.HasOne("SkillSwap.Models.Role", "IdRolNavigation")
                        .WithMany("Users")
                        .HasForeignKey("IdRol")
                        .HasConstraintName("Users_ibfk_2");

                    b.HasOne("SkillSwap.Models.StateUser", "IdStateNavigation")
                        .WithMany("Users")
                        .HasForeignKey("IdState")
                        .HasConstraintName("Users_ibfk_1");

                    b.Navigation("IdRolNavigation");

                    b.Navigation("IdStateNavigation");
                });

            modelBuilder.Entity("SkillSwap.Models.UsersSecondaryAbility", b =>
                {
                    b.HasOne("SkillSwap.Models.SecondaryAbility", "IdSecondaryAbilitieNavigation")
                        .WithMany("UsersSecondaryAbilities")
                        .HasForeignKey("IdSecondaryAbilitie")
                        .HasConstraintName("Users_Secondary_abilities_ibfk_2");

                    b.HasOne("SkillSwap.Models.User", "IdUserNavigation")
                        .WithMany("UsersSecondaryAbilities")
                        .HasForeignKey("IdUser")
                        .HasConstraintName("Users_Secondary_abilities_ibfk_1");

                    b.Navigation("IdSecondaryAbilitieNavigation");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("SkillSwap.Models.PrimaryAbility", b =>
                {
                    b.Navigation("SecondaryAbilities");
                });

            modelBuilder.Entity("SkillSwap.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("SkillSwap.Models.SecondaryAbility", b =>
                {
                    b.Navigation("UsersSecondaryAbilities");
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
                    b.Navigation("Qualifications");

                    b.Navigation("RequestIdReceivingUserNavigations");

                    b.Navigation("RequestIdRequestingUserNavigations");

                    b.Navigation("UsersSecondaryAbilities");
                });
#pragma warning restore 612, 618
        }
    }
}
