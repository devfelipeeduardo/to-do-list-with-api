namespace ToDoListAPI.DTOs
{
    //Talvez não precise.
    public class SetTitleRequestDTO
    {
        public int ToDoListId { get; set; }
        public string Title { get; set; } = string.Empty;
    }
}
