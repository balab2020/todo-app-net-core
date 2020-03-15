namespace todo_app_net_core.Data
{
    using Microsoft.EntityFrameworkCore;
    using todo_app_net_core.Data.Model;

    public class TodoDbContext : DbContext
    {
        public DbSet<TodoDbModel> Todos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=IE4LLT7GSL2Z2;Database=Todo;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            TodoDbModel.OnModelCreating(modelBuilder);
        }
    }
}
