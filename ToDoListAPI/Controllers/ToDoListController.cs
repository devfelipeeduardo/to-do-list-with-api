using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.Data;
using ToDoListAPI.Models;
using ToDoListAPI.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using ToDoListAPI.DTOs.ToDoList;
using ToDoListAPI.DTOs.TaskToDo;

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
        public async Task<IActionResult> CreateNewToDoList([FromBody] CreateListDTO request)
        {
            if (request == null) return StatusCode(500, "Ocorreu um erro ao criar uma lista");

            var newList = new ToDoList
            {
                Title = request.Title,
                Tasks = request.Tasks.Select(t => new TaskToDo
                {
                    Description = t.Description,
                    IsChecked = t.IsChecked
                }).ToList()
            };

            _context.ToDoLists.Add(newList);
            await _context.SaveChangesAsync();
            return Ok(request);
        }

        [HttpPost("add-new-task")]
        public async Task<IActionResult> AddNewTask([FromBody] AddNewTaskDTO request)
        {
            if (request == null) return StatusCode(500, "Ocorreu um erro ao adicionar uma tarefa");

            // TODO: mover regra de incremento de TaskNumber para o TaskService.
            var lastTaskNumber = await _context.Tasks
                .Where(t => t.ToDoListId == request.ToDoListId)
                .Select(t => (int?)t.TaskNumber)
                .MaxAsync() ?? 0;


            var taskToDo = new TaskToDo
            {
                ToDoListId = request.ToDoListId,
                TaskNumber = lastTaskNumber +1,
                IsChecked = request.IsChecked,
                Description = request.Description,
            };

            _context.Tasks.Add(taskToDo);
            await _context.SaveChangesAsync();

            return Ok(request);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var toDoLists = await _context.ToDoLists.ToListAsync();

            if (toDoLists == null) return NotFound("Ocorreu um erro ao retornar as listas");

            return Ok(toDoLists);
        }


        [HttpPost("set-todolist-title")]
        public async Task<IActionResult> SetListTitle([FromBody] SetTitleListDTO request)
        {
            try
            {
                var toDoList = _context.ToDoLists.FirstOrDefault(l => l.Id == request.Id);

                if (toDoList == null)
                {
                    return NotFound("Ocorreu um erro ao atualizar o título, a lista não foi encontrada");
                }
                toDoList.Title = request.Title;

                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Ocorreu um erro ao atualizar o título");
            }

            return Ok();
        }

        [HttpPost("set-task-description")]
        public async Task<IActionResult> SetTaskDescription([FromBody] SetTaskDescriptionDTO request)
        {
            try
            {
                var task = _context.Tasks.FirstOrDefault(t => t.ToDoListId == request.ToDoListId && t.TaskNumber == request.TaskNumber);

                if (task == null) return NotFound("Ocorreu um erro ao atualizar a descrição, a tarefa não foi encontrada");

                await _context.SaveChangesAsync();

                return Ok(request);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Ocorreu um erro ao atualizar a descrição.");
            }
        }

    }
}
