using Microsoft.EntityFrameworkCore;
using todo_app_net_core.model;

namespace todo_app_net_core.Data
{
    public interface ITodoDbContext
    {
        DbSet<Todo> Todos { get; set; }
    }
}