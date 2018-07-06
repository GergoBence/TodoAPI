using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TodoAPI.Models;

namespace TodoAPI
{
    public class TodoContext : DbContext
    {
        public TodoContext(string connectionString = ":memory:")
        //public TodoContext(string connectionString = "Data Source=(LocalDb)\\LocalDBDemo;Integrated Security=SSPI;")
            : base(connectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Todo>()
                .HasKey(i => i.ID);
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