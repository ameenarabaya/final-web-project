﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using To_Do_List.Models;

#nullable disable

namespace To_Do_List.Migrations
{
    [DbContext(typeof(ToDoContext))]
    partial class ToDoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("To_Do_List.Models.SubTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Done")
                        .HasColumnType("bit");

                    b.Property<int>("TaskModelId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TaskModelId");

                    b.ToTable("SubTask");

                    b.HasData(
                        new
                        {
                            Id = 50,
                            Done = true,
                            TaskModelId = 11,
                            Title = "Clothing"
                        },
                        new
                        {
                            Id = 51,
                            Done = false,
                            TaskModelId = 22,
                            Title = "Lab Linux Mid"
                        },
                        new
                        {
                            Id = 52,
                            Done = true,
                            TaskModelId = 22,
                            Title = "Software Mid"
                        },
                        new
                        {
                            Id = 53,
                            Done = false,
                            TaskModelId = 11,
                            Title = "Accessories"
                        },
                        new
                        {
                            Id = 54,
                            Done = true,
                            TaskModelId = 33,
                            Title = "Ai project part1"
                        },
                        new
                        {
                            Id = 55,
                            Done = false,
                            TaskModelId = 44,
                            Title = "Perfumes"
                        });
                });

            modelBuilder.Entity("To_Do_List.Models.TaskModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Complete")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Tasks");

                    b.HasData(
                        new
                        {
                            Id = 11,
                            Complete = true,
                            Title = "Travel to Abu Dhabi",
                            UserId = 1
                        },
                        new
                        {
                            Id = 22,
                            Complete = false,
                            Title = "Midterm Exam",
                            UserId = 2
                        },
                        new
                        {
                            Id = 33,
                            Complete = true,
                            Title = "Ai project",
                            UserId = 3
                        },
                        new
                        {
                            Id = 44,
                            Complete = false,
                            Title = "Shooping",
                            UserId = 3
                        });
                });

            modelBuilder.Entity("To_Do_List.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "moshera@gmail.com",
                            Name = "Moshera",
                            Password = "2021"
                        },
                        new
                        {
                            Id = 2,
                            Email = "ameena@gmail.com",
                            Name = "Ameena",
                            Password = "2020"
                        },
                        new
                        {
                            Id = 3,
                            Email = "a@a.a",
                            Name = "a",
                            Password = "0000"
                        });
                });

            modelBuilder.Entity("To_Do_List.Models.SubTask", b =>
                {
                    b.HasOne("To_Do_List.Models.TaskModel", "TaskModel")
                        .WithMany("SubTasks")
                        .HasForeignKey("TaskModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TaskModel");
                });

            modelBuilder.Entity("To_Do_List.Models.TaskModel", b =>
                {
                    b.HasOne("To_Do_List.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("To_Do_List.Models.TaskModel", b =>
                {
                    b.Navigation("SubTasks");
                });
#pragma warning restore 612, 618
        }
    }
}
