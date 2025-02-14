﻿// <auto-generated />
using System;
using HospitalAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HospitalAPI.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210625225650_PostgresInitial")]
    partial class PostgresInitial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("HospitalAPI.Entities.Employee", b =>
                {
                    b.Property<string>("Login")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PersonalId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Profession")
                        .HasColumnType("integer");

                    b.Property<string>("RtPPNumber")
                        .HasColumnType("text");

                    b.Property<int>("Specialization")
                        .HasColumnType("integer");

                    b.HasKey("Login");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("HospitalAPI.Entities.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("EmployeeLogin")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Month")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeLogin");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("HospitalAPI.Entities.Schedule", b =>
                {
                    b.HasOne("HospitalAPI.Entities.Employee", "Employee")
                        .WithMany("Schedules")
                        .HasForeignKey("EmployeeLogin")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("HospitalAPI.Entities.Employee", b =>
                {
                    b.Navigation("Schedules");
                });
#pragma warning restore 612, 618
        }
    }
}
