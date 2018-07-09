using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using TodoAPI.Models;

namespace TodoAPI
{
    public class TodoContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Todo>()
                .ToTable("todos")
                .HasKey(i => i.ID)
                .Property(i => i.Content)
                    .HasColumnName("desc");
        }

        public DbSet<Todo> Todos { get; set; }
    }

    public static class TodoContextConsumer
    {
        public static void Consume()
        {
            using (var db = new TodoContext())
            {
                var allTodo = db.Todos.ToList();
            }
        }
    }
}