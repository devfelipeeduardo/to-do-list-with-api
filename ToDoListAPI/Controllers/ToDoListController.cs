using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.Data;
using ToDoListAPI.DTOs;
using Microsoft.AspNetCore.Http.Json;
using ToDoListAPI.Services;
using ToDoListAPI.Interfaces.Services;

namespace ToDoListAPI.Controllers
{
    [ApiController]
    [Route("/api")]
    public class ToDoListController : ControllerBase
    {
        private IListsManagerService _listsManagerService;
        private readonly AppDbContext _context;

        public ToDoListController(AppDbContext context, IListsManagerService listsManagerService)
        {
            _context = context;
            _listsManagerService = listsManagerService;
        }


        [HttpPost("set-todolist-title")]
        public IActionResult SetTitle([FromBody] SetTitleRequestDTO request)
        {
            try
            {
                _listsManagerService.SetToDoListTitleAsync(request.ToDoListId, request.Title);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Ocorreu um erro ao atualizar o título");
            }

            return Ok();
        }

        [HttpPost("set-task-description")]
        public IActionResult SetTaskDescription([FromBody] SetTaskDescriptionDTO request) {

            try
            {
                _listsManagerService.SetTaskDescriptionAsync(request.ToDoListId, request.TaskId, request.Description);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Ocorreu um erro ao atualizar a descrição.");
            }

            return Ok();
        }

    }
}
