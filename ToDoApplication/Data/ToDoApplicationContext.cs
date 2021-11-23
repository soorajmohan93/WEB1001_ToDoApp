using System;
using Microsoft.EntityFrameworkCore;
using ToDoApplication.Models;

// This class is for the DataBase Context. The connection string for DB context is defined in Startup.cs


namespace ToDoApplication.Data
{
    public class ToDoApplicationContext : DbContext
    {
        public DbSet<ToDos> ToDo { get; set; }

        public ToDoApplicationContext(DbContextOptions<ToDoApplicationContext> options)
            : base(options)
        {
        }

    }
}
