﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ORTSocial.Context;

#nullable disable

namespace ORTSocial.Migrations
{
    [DbContext(typeof(ORTSocialContext))]
    [Migration("20231117200733_2")]
    partial class _2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ORTSocial.Models.Cartilla", b =>
                {
                    b.Property<int>("IdCartilla")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCartilla"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCartilla");

                    b.ToTable("Cartillas");
                });

            modelBuilder.Entity("ORTSocial.Models.CartillaMedico", b =>
                {
                    b.Property<int>("idCartillaMedico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idCartillaMedico"));

                    b.Property<int>("IdCartilla")
                        .HasColumnType("int");

                    b.Property<int>("IdMedico")
                        .HasColumnType("int");

                    b.HasKey("idCartillaMedico");

                    b.HasIndex("IdCartilla");

                    b.HasIndex("IdMedico");

                    b.ToTable("CartillasMedicos");
                });

            modelBuilder.Entity("ORTSocial.Models.Familiar", b =>
                {
                    b.Property<int>("IdFamiliar")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdFamiliar"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Dni")
                        .HasColumnType("int");

                    b.Property<int>("IdGrupoFamiliar")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdFamiliar");

                    b.HasIndex("IdGrupoFamiliar");

                    b.ToTable("Familiares");
                });

            modelBuilder.Entity("ORTSocial.Models.GrupoFamiliar", b =>
                {
                    b.Property<int>("IdGrupoFamiliar")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdGrupoFamiliar"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdGrupoFamiliar");

                    b.ToTable("GruposFamiliares");
                });

            modelBuilder.Entity("ORTSocial.Models.Medico", b =>
                {
                    b.Property<int>("IdMedico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMedico"));

                    b.Property<string>("Dni")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Especialidad")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdMedico");

                    b.ToTable("Medicos");
                });

            modelBuilder.Entity("ORTSocial.Models.Plan", b =>
                {
                    b.Property<int>("IdPlan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPlan"));

                    b.Property<int>("CantFamiliares")
                        .HasColumnType("int");

                    b.Property<float>("Costo")
                        .HasColumnType("real");

                    b.Property<int>("IdCartilla")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPlan");

                    b.HasIndex("IdCartilla");

                    b.ToTable("Planes");
                });

            modelBuilder.Entity("ORTSocial.Models.Socio", b =>
                {
                    b.Property<int>("IdSocio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSocio"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Dni")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdGrupoFamiliar")
                        .HasColumnType("int");

                    b.Property<int>("IdPlan")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Provincia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.HasKey("IdSocio");

                    b.HasIndex("IdGrupoFamiliar");

                    b.HasIndex("IdPlan");

                    b.ToTable("Socios");
                });

            modelBuilder.Entity("ORTSocial.Models.TurnoMedico", b =>
                {
                    b.Property<int>("idTurno")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idTurno"));

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdMedico")
                        .HasColumnType("int");

                    b.Property<int>("IdSocio")
                        .HasColumnType("int");

                    b.HasKey("idTurno");

                    b.HasIndex("IdMedico");

                    b.HasIndex("IdSocio");

                    b.ToTable("TurnosMedicos");
                });

            modelBuilder.Entity("ORTSocial.Models.CartillaMedico", b =>
                {
                    b.HasOne("ORTSocial.Models.Cartilla", "Cartilla")
                        .WithMany()
                        .HasForeignKey("IdCartilla")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ORTSocial.Models.Medico", "Medico")
                        .WithMany()
                        .HasForeignKey("IdMedico")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cartilla");

                    b.Navigation("Medico");
                });

            modelBuilder.Entity("ORTSocial.Models.Familiar", b =>
                {
                    b.HasOne("ORTSocial.Models.GrupoFamiliar", "GrupoFamiliar")
                        .WithMany("Familiares")
                        .HasForeignKey("IdGrupoFamiliar")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GrupoFamiliar");
                });

            modelBuilder.Entity("ORTSocial.Models.Plan", b =>
                {
                    b.HasOne("ORTSocial.Models.Cartilla", "Cartilla")
                        .WithMany()
                        .HasForeignKey("IdCartilla")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cartilla");
                });

            modelBuilder.Entity("ORTSocial.Models.Socio", b =>
                {
                    b.HasOne("ORTSocial.Models.GrupoFamiliar", "GrupoFamiliar")
                        .WithMany()
                        .HasForeignKey("IdGrupoFamiliar")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ORTSocial.Models.Plan", "Plan")
                        .WithMany()
                        .HasForeignKey("IdPlan")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GrupoFamiliar");

                    b.Navigation("Plan");
                });

            modelBuilder.Entity("ORTSocial.Models.TurnoMedico", b =>
                {
                    b.HasOne("ORTSocial.Models.Medico", "Medico")
                        .WithMany("TurnosMedicos")
                        .HasForeignKey("IdMedico")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ORTSocial.Models.Socio", "Socio")
                        .WithMany("TurnosMedicos")
                        .HasForeignKey("IdSocio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medico");

                    b.Navigation("Socio");
                });

            modelBuilder.Entity("ORTSocial.Models.GrupoFamiliar", b =>
                {
                    b.Navigation("Familiares");
                });

            modelBuilder.Entity("ORTSocial.Models.Medico", b =>
                {
                    b.Navigation("TurnosMedicos");
                });

            modelBuilder.Entity("ORTSocial.Models.Socio", b =>
                {
                    b.Navigation("TurnosMedicos");
                });
#pragma warning restore 612, 618
        }
    }
}