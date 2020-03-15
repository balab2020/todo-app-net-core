using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using todo_app_net_core.model;

namespace todo_app_net_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {

        private static readonly List<Todo> _todos = new List<Todo>
        {
            new Todo { Action = "Call Mom",Id=1, Completed=false, CreatedOn= DateTime.Now, Guid=Guid.NewGuid()}
        };

        private readonly ILogger<TodoController> _logger;

        public TodoController(ILogger<TodoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<Todo[]> GetAll()
        {
            _logger.LogInformation("Get All Todos");
            return Ok(_todos);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var todo = _todos.FirstOrDefault(t => t.Id == id);
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }
    }
}