﻿// <auto-generated />
using System;
using HospitalAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HospitalAPI.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("HospitalAPI.Entities.Employee", b =>
                {
                    b.Property<string>("Login")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PersonalId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Profession")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RtPPNumber")
                        .HasColumnType("TEXT");

                    b.Property<int>("Specialization")
                        .HasColumnType("INTEGER");

                    b.HasKey("Login");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("HospitalAPI.Entities.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmployeeLogin")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Month")
                        .HasColumnType("INTEGER");

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
