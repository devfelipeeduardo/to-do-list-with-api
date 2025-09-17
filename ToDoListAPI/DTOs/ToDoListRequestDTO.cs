using ToDoListAPI.Models;

namespace ToDoListAPI.DTOs
{
    public class ToDoListRequestDTO
    {
        public string Title { get; private set; } = string.Empty;
        public List<TaskToDo> Tasks { get; private set; } = [];
    }
}
