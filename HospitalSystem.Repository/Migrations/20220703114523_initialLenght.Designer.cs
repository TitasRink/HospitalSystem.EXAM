﻿// <auto-generated />
using System;
using HospitalSystem.Repository.ContextDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HospitalSystem.Repository.Migrations
{
    [DbContext(typeof(DataDB))]
    [Migration("20220703114523_initialLenght")]
    partial class initialLenght
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DoctorModelPatientModel", b =>
                {
                    b.Property<int>("doctorsId")
                        .HasColumnType("int");

                    b.Property<int>("patientsId")
                        .HasColumnType("int");

                    b.HasKey("doctorsId", "patientsId");

                    b.HasIndex("patientsId");

                    b.ToTable("DoctorModelPatientModel");
                });

            modelBuilder.Entity("HospitalSystem.Repository.Entities.DepartmentModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("HospitalSystem.Repository.Entities.DoctorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentModelId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Speciality")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentModelId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("HospitalSystem.Repository.Entities.PatientModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("DepartmentModelId")
                        .HasColumnType("int");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentModelId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("DoctorModelPatientModel", b =>
                {
                    b.HasOne("HospitalSystem.Repository.Entities.DoctorModel", null)
                        .WithMany()
                        .HasForeignKey("doctorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalSystem.Repository.Entities.PatientModel", null)
                        .WithMany()
                        .HasForeignKey("patientsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HospitalSystem.Repository.Entities.DoctorModel", b =>
                {
                    b.HasOne("HospitalSystem.Repository.Entities.DepartmentModel", null)
                        .WithMany("doctors")
                        .HasForeignKey("DepartmentModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HospitalSystem.Repository.Entities.PatientModel", b =>
                {
                    b.HasOne("HospitalSystem.Repository.Entities.DepartmentModel", null)
                        .WithMany("patients")
                        .HasForeignKey("DepartmentModelId");
                });

            modelBuilder.Entity("HospitalSystem.Repository.Entities.DepartmentModel", b =>
                {
                    b.Navigation("doctors");

                    b.Navigation("patients");
                });
#pragma warning restore 612, 618
        }
    }
}
