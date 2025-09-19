using ToDoListAPI.DTOs.TaskToDo;
using ToDoListAPI.Models;

namespace ToDoListAPI.DTOs.ToDoList
{
    public class CreateListDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public List<AddNewTaskDTO> Tasks { get; set; } = new();
    }
}
