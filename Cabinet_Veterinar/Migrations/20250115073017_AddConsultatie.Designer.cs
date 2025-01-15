﻿// <auto-generated />
using System;
using Cabinet_Veterinar.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cabinet_Veterinar.Migrations
{
    [DbContext(typeof(Cabinet_VeterinarContext))]
    [Migration("20250115073017_AddConsultatie")]
    partial class AddConsultatie
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Cabinet_Veterinar.Models.Consultatie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("Data_Consultatie")
                        .HasColumnType("datetime2");

                    b.Property<string>("Diagnostic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pret")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Consultatie");
                });

            modelBuilder.Entity("Cabinet_Veterinar.Models.Pacient", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("ConsultatieID")
                        .HasColumnType("int");

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProprietarID")
                        .HasColumnType("int");

                    b.Property<string>("Specie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Varsta")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ConsultatieID");

                    b.HasIndex("ProprietarID");

                    b.ToTable("Pacient");
                });

            modelBuilder.Entity("Cabinet_Veterinar.Models.Proprietar", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Proprietar");
                });

            modelBuilder.Entity("Cabinet_Veterinar.Models.Pacient", b =>
                {
                    b.HasOne("Cabinet_Veterinar.Models.Consultatie", "Consultatie")
                        .WithMany("Pacienti")
                        .HasForeignKey("ConsultatieID");

                    b.HasOne("Cabinet_Veterinar.Models.Proprietar", "Proprietar")
                        .WithMany("Pacienti")
                        .HasForeignKey("ProprietarID");

                    b.Navigation("Consultatie");

                    b.Navigation("Proprietar");
                });

            modelBuilder.Entity("Cabinet_Veterinar.Models.Consultatie", b =>
                {
                    b.Navigation("Pacienti");
                });

            modelBuilder.Entity("Cabinet_Veterinar.Models.Proprietar", b =>
                {
                    b.Navigation("Pacienti");
                });
#pragma warning restore 612, 618
        }
    }
}
