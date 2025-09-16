namespace ToDoListAPI.DTOs
{
    public class SetTaskDescriptionDTO
    {
        public int ToDoListId { get; set; }
        public int TaskId { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
