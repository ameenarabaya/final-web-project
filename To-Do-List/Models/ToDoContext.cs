using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using To_Do_List.Models;

namespace To_Do_List.Models
{
    public class ToDoContext : DbContext
    {

        public ToDoContext(DbContextOptions<ToDoContext> options)
        : base(options)
        { }
        public DbSet<User> User { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<SubTask> SubTask { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                Name = "Moshera",
                Password = "2021",
                Email = "moshera@gmail.com",
            },
            new User
            {
                Id = 2,
                Name = "Ameena",
                Password = "2020",
                Email = "ameena@gmail.com",
            },
            new User
            {
                Id = 3,
                Name = "a",
                Password = "0000",
                Email = "a@a.a",
            }
            );

            modelBuilder.Entity<TaskModel>().HasData(
            new TaskModel
            {
                Id = 11,
                Title = "Travel to Abu Dhabi",
                Complete = true,
                UserId = 1,
            },
                new TaskModel
                {
                    Id = 22,
                    Title = "Midterm Exam",
                    Complete = false,
                    UserId = 2,
                },
                new TaskModel
                {
                    Id = 33,
                    Title = "Ai project",
                    Complete = true,
                    UserId = 3,
                },
                new TaskModel
                {
                    Id = 44,
                    Title = "Shooping",
                    Complete = false,
                    UserId = 3,
                }
            );

            modelBuilder.Entity<SubTask>().HasData(
           new SubTask
           {
               Id = 50,
               Title = "Clothing",
               Done = true,
               TaskModelId = 11,
           },
               new SubTask
               {
                   Id = 51,
                   Title = "Lab Linux Mid",
                   Done = false,
                   TaskModelId = 22,
               },
               new SubTask
               {
                   Id = 52,
                   Title = "Software Mid",
                   Done = true,
                   TaskModelId = 22,
               },
                new SubTask
                {
                    Id = 53,
                    Title = "Accessories",
                    Done = false,
                    TaskModelId = 11,
                },
                new SubTask
                {
                    Id = 54,
                    Title = "Ai project part1",
                    Done = true,
                    TaskModelId = 33,
                },
               new SubTask
               {
                   Id = 55,
                   Title = "Perfumes",
                   Done = false,
                   TaskModelId = 44,
               }
           );
        }

        }
}
