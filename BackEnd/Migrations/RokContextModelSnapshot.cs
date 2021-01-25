﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjekatBackend.Models;

namespace Projekat.Migrations
{
    [DbContext(typeof(RokContext))]
    partial class RokContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("ProjekatBackend.Models.Amfiteatar", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .UseIdentityColumn();

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Color");

                    b.Property<int?>("IspitSifra")
                        .HasColumnType("int");

                    b.Property<int>("Kapacitet")
                        .HasColumnType("int")
                        .HasColumnName("Kapacitet");

                    b.Property<string>("Naziv")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Naziv");

                    b.HasKey("ID");

                    b.HasIndex("IspitSifra");

                    b.ToTable("Amfiteatar");
                });

            modelBuilder.Entity("ProjekatBackend.Models.Ispit", b =>
                {
                    b.Property<int>("Sifra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Sifra")
                        .UseIdentityColumn();

                    b.Property<int?>("IspitniRokID")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Naziv");

                    b.HasKey("Sifra");

                    b.HasIndex("IspitniRokID");

                    b.ToTable("Ispit");
                });

            modelBuilder.Entity("ProjekatBackend.Models.IspitniRok", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .UseIdentityColumn();

                    b.Property<string>("Naziv")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Naziv");

                    b.HasKey("ID");

                    b.ToTable("Ispitni rok");
                });

            modelBuilder.Entity("ProjekatBackend.Models.Student", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .UseIdentityColumn();

                    b.Property<int>("BrojIndeksa")
                        .HasColumnType("int")
                        .HasColumnName("BrojIndeksa");

                    b.Property<int>("GodinaStudija")
                        .HasColumnType("int")
                        .HasColumnName("Godina studija");

                    b.Property<string>("Ime")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Ime");

                    b.Property<int?>("IspitSifra")
                        .HasColumnType("int");

                    b.Property<string>("Prezime")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Prezime");

                    b.HasKey("ID");

                    b.HasIndex("IspitSifra");

                    b.ToTable("Studenti");
                });

            modelBuilder.Entity("ProjekatBackend.Models.Amfiteatar", b =>
                {
                    b.HasOne("ProjekatBackend.Models.Ispit", "Ispit")
                        .WithMany("Amfiteatri")
                        .HasForeignKey("IspitSifra");

                    b.Navigation("Ispit");
                });

            modelBuilder.Entity("ProjekatBackend.Models.Ispit", b =>
                {
                    b.HasOne("ProjekatBackend.Models.IspitniRok", "IspitniRok")
                        .WithMany("listaIspita")
                        .HasForeignKey("IspitniRokID");

                    b.Navigation("IspitniRok");
                });

            modelBuilder.Entity("ProjekatBackend.Models.Student", b =>
                {
                    b.HasOne("ProjekatBackend.Models.Ispit", "Ispit")
                        .WithMany("listaStudenata")
                        .HasForeignKey("IspitSifra");

                    b.Navigation("Ispit");
                });

            modelBuilder.Entity("ProjekatBackend.Models.Ispit", b =>
                {
                    b.Navigation("Amfiteatri");

                    b.Navigation("listaStudenata");
                });

            modelBuilder.Entity("ProjekatBackend.Models.IspitniRok", b =>
                {
                    b.Navigation("listaIspita");
                });
#pragma warning restore 612, 618
        }
    }
}
