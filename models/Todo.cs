
namespace todo_app_net_core.model
{
    using System;

    public class Todo
    {
        public int Id { get; set; }

        public string Action { get; set; }

        public bool Completed { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
