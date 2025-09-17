using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.Data;
using ToDoListAPI.DTOs;
using ToDoListAPI.Models;
using ToDoListAPI.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

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

        [HttpPost("create-todolist")]
        public async Task<IActionResult> CreateNewToDoList([FromBody] ToDoList request)
        {
            if (request == null) return StatusCode(500, "Ocorreu um erro ao atualizar o título");

            request.Id = 0;

            _context.ToDoLists.Add(request);
            await _context.SaveChangesAsync();
            return Ok(request);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var toDoLists = await _context.ToDoLists.ToListAsync();
            return Ok(toDoLists);
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
