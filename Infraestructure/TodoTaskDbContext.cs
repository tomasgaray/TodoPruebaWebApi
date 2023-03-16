using Microsoft.EntityFrameworkCore;
using TodoPruebaWebApi.Feature.Entities;

namespace TodoPruebaWebApi.Infraestructure{
    public class TodoTaskDbContext : DbContext
    {
        public TodoTaskDbContext(DbContextOptions<TodoTaskDbContext> options) : base(options) { }
        public DbSet<TodoTask> TodoTask { get; set; }
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new TodoTask.Map(modelBuilder.Entity<TodoTask>());
            base.OnModelCreating(modelBuilder);
        }
    }
}