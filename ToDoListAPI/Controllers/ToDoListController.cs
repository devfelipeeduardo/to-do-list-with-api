using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.Models;

namespace ToDoListAPI.Controllers
{
    [ApiController]
    [Route("/api")]
    public class ToDoListController : ControllerBase
    {
        public ToDoListController() { }

        [Route("state")]
        public IActionResult GetState ()
        {
            return Ok();
        }

        [Route("set-list-state")]
        public IActionResult SetListState(ToDoList list ) {
            return Ok();
        }

        public IActionResult Index()
        {
            return Ok();
        }
    }
}
