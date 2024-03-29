﻿// <auto-generated />
using System;
using AirFranceDI22Model.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AirFranceDI22Model.Migrations
{
    [DbContext(typeof(AirFranceDI22Context))]
    [Migration("20231123125438_AddDateReservation")]
    partial class AddDateReservation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AirFranceDI22Model.Dao.Aeroport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)")
                        .HasColumnName("nom");

                    b.Property<int>("VilleId")
                        .HasColumnType("int")
                        .HasColumnName("villeId");

                    b.HasKey("Id");

                    b.HasIndex("VilleId");

                    b.ToTable("Aeroports");
                });

            modelBuilder.Entity("AirFranceDI22Model.Dao.Compagnie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)")
                        .HasColumnName("nom");

                    b.HasKey("Id");

                    b.ToTable("Compagnies");
                });

            modelBuilder.Entity("AirFranceDI22Model.Dao.Personne", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("varchar(8)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)")
                        .HasColumnName("nom");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)")
                        .HasColumnName("prenom");

                    b.HasKey("Id");

                    b.ToTable("Personnes");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Personne");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("AirFranceDI22Model.Dao.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("ClientId")
                        .HasColumnType("int")
                        .HasColumnName("clientId");

                    b.Property<DateTime>("DateReservation")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("dateReservation");

                    b.Property<int>("Etat")
                        .HasColumnType("int")
                        .HasColumnName("etat");

                    b.Property<int>("PassagerId")
                        .HasColumnType("int")
                        .HasColumnName("passagerId");

                    b.Property<string>("Reference")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)")
                        .HasColumnName("reference");

                    b.Property<int>("VolId")
                        .HasColumnType("int")
                        .HasColumnName("volId");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("PassagerId");

                    b.HasIndex("VolId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("AirFranceDI22Model.Dao.Ville", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)")
                        .HasColumnName("nom");

                    b.HasKey("Id");

                    b.ToTable("Villes");
                });

            modelBuilder.Entity("AirFranceDI22Model.Dao.Vol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("AeroportArriveeId")
                        .HasColumnType("int")
                        .HasColumnName("aeroportArriveeId");

                    b.Property<int>("AeroportDepartId")
                        .HasColumnType("int")
                        .HasColumnName("aeroportDepartId");

                    b.Property<int>("CompagnieId")
                        .HasColumnType("int")
                        .HasColumnName("compagnieId");

                    b.Property<DateTime>("DateHeureArrivee")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("dateHeureArrivee");

                    b.Property<DateTime>("DateHeureDepart")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("dateHeureDepart");

                    b.Property<string>("NumeroVol")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("numeroVol");

                    b.Property<bool>("OuvertResa")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("ouvertResa");

                    b.Property<int?>("VolId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AeroportArriveeId");

                    b.HasIndex("AeroportDepartId");

                    b.HasIndex("CompagnieId");

                    b.HasIndex("VolId");

                    b.ToTable("Vols");
                });

            modelBuilder.Entity("AirFranceDI22Model.Dao.Client", b =>
                {
                    b.HasBaseType("AirFranceDI22Model.Dao.Personne");

                    b.Property<string>("CodeClient")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)")
                        .HasColumnName("codeClient");

                    b.HasDiscriminator().HasValue("Client");
                });

            modelBuilder.Entity("AirFranceDI22Model.Dao.Passager", b =>
                {
                    b.HasBaseType("AirFranceDI22Model.Dao.Personne");

                    b.Property<string>("PieceIdentite")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)")
                        .HasColumnName("pieceIdentite");

                    b.HasDiscriminator().HasValue("Passager");
                });

            modelBuilder.Entity("AirFranceDI22Model.Dao.Aeroport", b =>
                {
                    b.HasOne("AirFranceDI22Model.Dao.Ville", "Ville")
                        .WithMany()
                        .HasForeignKey("VilleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ville");
                });

            modelBuilder.Entity("AirFranceDI22Model.Dao.Reservation", b =>
                {
                    b.HasOne("AirFranceDI22Model.Dao.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AirFranceDI22Model.Dao.Passager", "Passager")
                        .WithMany("Reservations")
                        .HasForeignKey("PassagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AirFranceDI22Model.Dao.Vol", "Vol")
                        .WithMany()
                        .HasForeignKey("VolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Passager");

                    b.Navigation("Vol");
                });

            modelBuilder.Entity("AirFranceDI22Model.Dao.Vol", b =>
                {
                    b.HasOne("AirFranceDI22Model.Dao.Aeroport", "AeroportArrivee")
                        .WithMany()
                        .HasForeignKey("AeroportArriveeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AirFranceDI22Model.Dao.Aeroport", "AeroportDepart")
                        .WithMany()
                        .HasForeignKey("AeroportDepartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AirFranceDI22Model.Dao.Compagnie", "Compagnie")
                        .WithMany()
                        .HasForeignKey("CompagnieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AirFranceDI22Model.Dao.Vol", null)
                        .WithMany("Escales")
                        .HasForeignKey("VolId");

                    b.Navigation("AeroportArrivee");

                    b.Navigation("AeroportDepart");

                    b.Navigation("Compagnie");
                });

            modelBuilder.Entity("AirFranceDI22Model.Dao.Vol", b =>
                {
                    b.Navigation("Escales");
                });

            modelBuilder.Entity("AirFranceDI22Model.Dao.Passager", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
