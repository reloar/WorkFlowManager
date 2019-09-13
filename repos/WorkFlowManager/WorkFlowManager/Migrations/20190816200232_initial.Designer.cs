﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WorkFlowManager.Data;

namespace WorkFlowManager.Migrations
{
    [DbContext(typeof(WorkFlowManagerContext))]
    [Migration("20190816200232_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WorkFlowManager.Models.Courses", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CourseCode");

                    b.Property<string>("CourseDescription");

                    b.Property<int>("CourseUnit");

                    b.Property<int?>("LecturerId");

                    b.Property<int?>("StudentId");

                    b.HasKey("Id");

                    b.HasIndex("LecturerId");

                    b.HasIndex("StudentId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("WorkFlowManager.Models.Lecturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LecturerImage");

                    b.Property<string>("LecturerName");

                    b.Property<string>("Position");

                    b.HasKey("Id");

                    b.ToTable("Lecturers");
                });

            modelBuilder.Entity("WorkFlowManager.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("LecturerId");

                    b.Property<string>("MatricNumber");

                    b.Property<string>("StudentName");

                    b.HasKey("Id");

                    b.HasIndex("LecturerId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("WorkFlowManager.Models.Test", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Option");

                    b.Property<string>("TestQuestion");

                    b.HasKey("Id");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("WorkFlowManager.Models.Courses", b =>
                {
                    b.HasOne("WorkFlowManager.Models.Lecturer")
                        .WithMany("Courses")
                        .HasForeignKey("LecturerId");

                    b.HasOne("WorkFlowManager.Models.Student")
                        .WithMany("Courses")
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("WorkFlowManager.Models.Student", b =>
                {
                    b.HasOne("WorkFlowManager.Models.Lecturer")
                        .WithMany("Students")
                        .HasForeignKey("LecturerId");
                });
#pragma warning restore 612, 618
        }
    }
}
