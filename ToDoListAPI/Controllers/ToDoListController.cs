using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.Data;
using ToDoListAPI.DTOs;
using Microsoft.AspNetCore.Http.Json;
using ToDoListAPI.Services;

namespace ToDoListAPI.Controllers
{
    [ApiController]
    [Route("/api")]
    public class ToDoListController : ControllerBase
    {
        private ToDoListService _toDoListService;
        private readonly AppDbContext _context;

        public ToDoListController(AppDbContext context, ToDoListService toDoListService) {
            _context = context;
            _toDoListService = toDoListService;
        }

        [HttpPost("set-todolist-title")]
        public IActionResult SetTitle([FromBody] SetTitleRequestDTO request)
        {
            try
            {
                _toDoListService.SetToDoListTitle(request.ToDoListId, request.Title);
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Ocorreu um erro ao atualizar o título");
            }

            return Ok();
        }

        //[Route("set-list-state")]
        //public IActionResult SetListState(ToDoList list ) {
        //    return Ok();
        //}

        //[Route("state")]
        //public IActionResult GetState ()
        //{
        //    return Ok();
        //}
    }
}
