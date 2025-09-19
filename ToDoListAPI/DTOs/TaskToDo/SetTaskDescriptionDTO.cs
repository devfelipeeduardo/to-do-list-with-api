namespace ToDoListAPI.DTOs.TaskToDo
{
    public class AddNewTaskDTO
    {
        public bool IsChecked { get; set; } = false;
        public string Description { get; set; } = string.Empty;
        public int ToDoListId { get; set; }
    }
}
