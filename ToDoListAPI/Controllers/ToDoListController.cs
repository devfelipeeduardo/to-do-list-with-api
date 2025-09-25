using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.Data;
using ToDoListAPI.Models;
using ToDoListAPI.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using ToDoListAPI.DTOs.ToDoList;
using ToDoListAPI.DTOs.TaskToDo;
using Azure.Core;
using ToDoListAPI.Interfaces.Models;

namespace ToDoListAPI.Controllers
{
    [ApiController]
    [Route("/api")]
    public class ToDoListController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ToDoListController(AppDbContext context)
        {
            _context = context;
        }

        // TODO: depois que ajustar o programa, mover regras de negócio para as services

        [HttpPost("create-todo-list")]
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

        [HttpPost("set-todo-list-title")]
        public async Task<IActionResult> SetListTitle([FromBody] SetTitleListDTO request)
        {
            try
            {
                var toDoList = await _context.ToDoLists.FirstOrDefaultAsync(l => l.Id == request.Id);

                if (toDoList == null)
                {
                    return NotFound("Lista não encontrada");
                }

                toDoList.Title = request.Title;

                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Ocorreu um erro ao atualizar o título");
            }
        }
        [HttpDelete("delete-todo-list/{id}")]
        public async Task<IActionResult> DeleteToDoList(int id)
        {
            try
            {
                var toDoList = await _context.ToDoLists.FirstOrDefaultAsync(l => l.Id == id);

                if (toDoList == null)
                {
                    return NotFound("Lista não encontrada");
                }

                _context.ToDoLists.Remove(toDoList);

                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Ocorreu um erro ao deletar a lista");
            }
        }

        [HttpGet("get-all-todo-lists")]
        public async Task<IActionResult> GetAllToDoLists()
        {
            var toDoLists = await _context.ToDoLists.ToListAsync();
            if (toDoLists == null) return NotFound("Ocorreu um erro ao retornar as listas");

            return Ok(toDoLists);
        }

        [HttpGet("get-task-by-todo-list-id/{toDoListId}")]
        public async Task <IActionResult> GetTasksByListId(int toDoListId)
        {

            var toDoList = await _context.ToDoLists.Include(l => l.Tasks).FirstOrDefaultAsync(l => l.Id == toDoListId);

            if (toDoList == null) return NotFound();

            var tasks = toDoList.Tasks;

            return Ok(tasks);
        }


        [HttpPost("add-new-task")]
        public async Task<IActionResult> AddNewTask([FromBody] AddNewTaskDTO request)
        {
            if (request == null) return StatusCode(500, "Ocorreu um erro ao adicionar uma tarefa");
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

        [HttpDelete("delete-task")]
        public async Task<IActionResult> DeleteTask([FromBody] DeleteTaskDTO request)
        {
            try
            {
                var task = await _context.Tasks.FirstOrDefaultAsync(t => t.ToDoListId == request.ToDoListId && t.TaskNumber == request.TaskNumber);

                if (task == null) return NotFound("Ocorreu um erro ao deletar a tarefa, a tarefa não foi encontrada");

                _context.Tasks.Remove(task);

                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Ocorreu um erro ao excluir a tarefa.");
            };
        }

        [HttpPost("update-task-description")]
        public async Task<IActionResult> SetTaskDescription([FromBody] SetTaskDescriptionDTO request)
        {
            try
            {
                var task = await _context.Tasks.FirstOrDefaultAsync(t => t.ToDoListId == request.ToDoListId && t.TaskNumber == request.TaskNumber);

                if (task == null) return NotFound("Ocorreu um erro ao atualizar a descrição, a tarefa não foi encontrada");

                task.Description = request.Description;

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