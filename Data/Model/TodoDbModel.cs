namespace todo_app_net_core.Data.Model
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class TodoDbModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Action { get; set; }

        public bool Completed { get; set; }

        public DateTime CreatedOn { get; set; }

        public static void OnModelCreating(ModelBuilder modelBuilder) 
        {
            var todoEntity = modelBuilder.Entity<TodoDbModel>();

            todoEntity.Property(b => b.Id)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

            todoEntity.Property(b => b.Completed)
               .HasDefaultValue(false);

            todoEntity.Property(b => b.CreatedOn)
                .HasDefaultValue(DateTime.Now);
        }
    }
}
