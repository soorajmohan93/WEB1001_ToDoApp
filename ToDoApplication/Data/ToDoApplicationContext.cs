using System;
using Microsoft.EntityFrameworkCore;
using ToDoApplication.Models;




namespace ToDoApplication.Data
{
    public class ToDoApplicationContext : DbContext
    {
        public DbSet<ToDos> ToDo { get; set; }

        public ToDoApplicationContext(DbContextOptions<ToDoApplicationContext> options)
            : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite(@"Data Source=/Users/soorajmohan/Desktop/sql.db;");
        //}
    }
}
