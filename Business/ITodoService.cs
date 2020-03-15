using System.Collections.Generic;
using todo_app_net_core.model;

namespace todo_app_net_core.Business
{
    public interface ITodoService 
    {
        List<Todo> GetAll();

        Todo Get(int id);

        void Create(Todo todo);

        Todo Complete(int todoId);
    }
}
