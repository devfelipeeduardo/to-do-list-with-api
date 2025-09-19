namespace ToDoListAPI.DTOs.TaskToDo
{
    public class SetTaskDescriptionDTO
    {
        public int TaskNumber { get; set; }
        public int ToDoListId { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
