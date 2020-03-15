using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todo_app_net_core.Data;
using todo_app_net_core.Data.Model;
using todo_app_net_core.model;

namespace todo_app_net_core.Business
{
    public class TodoService : ITodoService
    {
        private Todo MapTodo(TodoDbModel todo) 
        {
            return new Todo
            {
                Id = todo.Id,
                CreatedOn = todo.CreatedOn,
                Completed = todo.Completed,
                Action = todo.Action
            };
        }

        public Todo Complete(int todoId)
        {
            using (var todoCtxt = new TodoDbContext())
            {
                var matchedTodo = FindTodoDbModel(todoId);
                if (matchedTodo == null) {
                    return null;
                }
                matchedTodo.Completed = true;
                todoCtxt.SaveChanges();
                return MapTodo(matchedTodo);
            }
        }

        public void Create(Todo todo)
        {
            using (var todoCtxt = new TodoDbContext())
            {
                todoCtxt.Todos.Add(new TodoDbModel
                {
                    Action = todo.Action,
                    Completed = false,
                    CreatedOn = DateTime.Now
                });
                todoCtxt.SaveChanges();
            }
        }

        private TodoDbModel FindTodoDbModel(int id) 
        {
            using (var todoCtxt = new TodoDbContext())
            {
                return todoCtxt.Todos.FirstOrDefault(t => t.Id == id);
            }
        }

        public Todo Get(int id)
        {
            var todo = FindTodoDbModel(id);
            return todo == null ? null : MapTodo(todo);
        }

        public List<Todo> GetAll()
        {
            using (var todoCtxt = new TodoDbContext())
            {
                return todoCtxt
                    .Todos
                    .Select(i => MapTodo(i))
                    .ToList();
            }
        }
    }
}
