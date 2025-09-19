using ToDoListAPI.Models;

namespace ToDoListAPI.DTOs.ToDoList
{
    public class SetTitleListDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
    }
}
