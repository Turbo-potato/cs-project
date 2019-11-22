﻿// <auto-generated />
using System;
using DiasApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DiasApp.Migrations
{
    [DbContext(typeof(PharmacyContext))]
    [Migration("20191116035853_first")]
    partial class first
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099");

            modelBuilder.Entity("DiasApp.Models.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Certificate")
                        .IsRequired();

                    b.Property<string>("Firstname")
                        .IsRequired();

                    b.Property<string>("Lastname")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Doctor");
                });

            modelBuilder.Entity("DiasApp.Models.Drug", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<double>("Dosage");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Type")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Drug");
                });

            modelBuilder.Entity("DiasApp.Models.DrugManufacturer", b =>
                {
                    b.Property<int>("DrugId");

                    b.Property<int>("ManufacturerId");

                    b.HasKey("DrugId", "ManufacturerId");

                    b.HasIndex("ManufacturerId");

                    b.ToTable("DrugManufacturer");
                });

            modelBuilder.Entity("DiasApp.Models.Manufacturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Manufacturer");
                });

            modelBuilder.Entity("DiasApp.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EndTime");

                    b.Property<DateTime>("StartTime");

                    b.HasKey("Id");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("DiasApp.Models.Organization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<int>("DoctorForeignKey");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("DoctorForeignKey")
                        .IsUnique();

                    b.ToTable("Organization");
                });

            modelBuilder.Entity("DiasApp.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DoctorId");

                    b.Property<string>("Firstname")
                        .IsRequired();

                    b.Property<string>("Lastname")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("DiasApp.Models.Prescription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EndTime");

                    b.Property<string>("Frequency")
                        .IsRequired();

                    b.Property<string>("Instruction")
                        .IsRequired();

                    b.Property<string>("PatientName")
                        .IsRequired();

                    b.Property<int>("Quantity");

                    b.Property<DateTime>("StartTime");

                    b.HasKey("Id");

                    b.ToTable("Prescription");
                });

            modelBuilder.Entity("DiasApp.Models.DrugManufacturer", b =>
                {
                    b.HasOne("DiasApp.Models.Drug", "Drug")
                        .WithMany("DrugManufacturers")
                        .HasForeignKey("DrugId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DiasApp.Models.Manufacturer", "Manufacturer")
                        .WithMany("DrugManufacturers")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DiasApp.Models.Organization", b =>
                {
                    b.HasOne("DiasApp.Models.Doctor", "Doctor")
                        .WithOne("Organization")
                        .HasForeignKey("DiasApp.Models.Organization", "DoctorForeignKey")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DiasApp.Models.Patient", b =>
                {
                    b.HasOne("DiasApp.Models.Doctor", "Doctor")
                        .WithMany("Patients")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}