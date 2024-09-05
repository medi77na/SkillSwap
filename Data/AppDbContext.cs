using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using SkillSwap.Models;

namespace SkillSwap.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Credential> Credentials { get; set; }

    public virtual DbSet<PrimaryAbility> PrimaryAbilities { get; set; }

    public virtual DbSet<Qualification> Qualifications { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<SecondaryAbility> SecondaryAbilities { get; set; }

    public virtual DbSet<StateRequest> StateRequests { get; set; }

    public virtual DbSet<StateUser> StateUsers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UsersSecondaryAbility> UsersSecondaryAbilities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<Credential>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
        });

        modelBuilder.Entity<PrimaryAbility>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Primary_abilities");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Qualification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.IdUser, "id_user");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.AccumulatorAdition)
                .HasColumnType("int(11)")
                .HasColumnName("accumulator_adition");
            entity.Property(e => e.Count)
                .HasColumnType("int(11)")
                .HasColumnName("count");
            entity.Property(e => e.IdUser)
                .HasColumnType("int(11)")
                .HasColumnName("id_user");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Qualifications)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("Qualifications_ibfk_1");
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.IdReceivingUser, "id_receiving_user");

            entity.HasIndex(e => e.IdRequestingUser, "id_requesting_user");

            entity.HasIndex(e => e.IdStateRequest, "id_state_request");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.DisponibilitySchedule)
                .HasMaxLength(255)
                .HasColumnName("disponibility_schedule");
            entity.Property(e => e.IdReceivingUser)
                .HasColumnType("int(11)")
                .HasColumnName("id_receiving_user");
            entity.Property(e => e.IdRequestingUser)
                .HasColumnType("int(11)")
                .HasColumnName("id_requesting_user");
            entity.Property(e => e.IdStateRequest)
                .HasColumnType("int(11)")
                .HasColumnName("id_state_request");

            entity.HasOne(d => d.IdReceivingUserNavigation).WithMany(p => p.RequestIdReceivingUserNavigations)
                .HasForeignKey(d => d.IdReceivingUser)
                .HasConstraintName("Requests_ibfk_2");

            entity.HasOne(d => d.IdRequestingUserNavigation).WithMany(p => p.RequestIdRequestingUserNavigations)
                .HasForeignKey(d => d.IdRequestingUser)
                .HasConstraintName("Requests_ibfk_3");

            entity.HasOne(d => d.IdStateRequestNavigation).WithMany(p => p.Requests)
                .HasForeignKey(d => d.IdStateRequest)
                .HasConstraintName("Requests_ibfk_1");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<SecondaryAbility>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Secondary_abilities");

            entity.HasIndex(e => e.IdPrimaryAbilitie, "id_primary_abilitie");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.IdPrimaryAbilitie)
                .HasColumnType("int(11)")
                .HasColumnName("id_primary_abilitie");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");

            entity.HasOne(d => d.IdPrimaryAbilitieNavigation).WithMany(p => p.SecondaryAbilities)
                .HasForeignKey(d => d.IdPrimaryAbilitie)
                .HasConstraintName("Secondary_abilities_ibfk_1");
        });

        modelBuilder.Entity<StateRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("state_requests");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<StateUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("State_users");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.DurationSuspension)
                .HasColumnType("int(11)")
                .HasColumnName("duration_suspension");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.IdCredential, "id_credential");

            entity.HasIndex(e => e.IdRol, "id_rol");

            entity.HasIndex(e => e.IdState, "id_state");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Birthdate).HasColumnName("birthdate");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.IdCredential)
                .HasColumnType("int(11)")
                .HasColumnName("id_credential");
            entity.Property(e => e.IdQualification)
                .HasColumnType("int(11)")
                .HasColumnName("id_qualification");
            entity.Property(e => e.IdRol)
                .HasColumnType("int(11)")
                .HasColumnName("id_rol");
            entity.Property(e => e.IdState)
                .HasColumnType("int(11)")
                .HasColumnName("id_state");
            entity.Property(e => e.JobTitle)
                .HasMaxLength(100)
                .HasColumnName("job_title");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(30)
                .HasColumnName("phone_number");
            entity.Property(e => e.UrlImage)
                .HasMaxLength(100)
                .HasColumnName("url_image");
            entity.Property(e => e.UrlLinkedin)
                .HasMaxLength(100)
                .HasColumnName("url_linkedin");

            entity.HasOne(d => d.IdCredentialNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdCredential)
                .HasConstraintName("Users_ibfk_3");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("Users_ibfk_2");

            entity.HasOne(d => d.IdStateNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdState)
                .HasConstraintName("Users_ibfk_1");
        });

        modelBuilder.Entity<UsersSecondaryAbility>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Users_Secondary_abilities");

            entity.HasIndex(e => e.IdSecondaryAbilitie, "id_secondary_abilitie");

            entity.HasIndex(e => e.IdUser, "id_user");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.IdSecondaryAbilitie)
                .HasColumnType("int(11)")
                .HasColumnName("id_secondary_abilitie");
            entity.Property(e => e.IdUser)
                .HasColumnType("int(11)")
                .HasColumnName("id_user");

            entity.HasOne(d => d.IdSecondaryAbilitieNavigation).WithMany(p => p.UsersSecondaryAbilities)
                .HasForeignKey(d => d.IdSecondaryAbilitie)
                .HasConstraintName("Users_Secondary_abilities_ibfk_2");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.UsersSecondaryAbilities)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("Users_Secondary_abilities_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
