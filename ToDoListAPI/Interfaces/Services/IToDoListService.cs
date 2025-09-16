namespace ToDoListAPI.Services
{
    public interface IToDoListService
    {
        void SetTaskDescription(int id, string description);
        void SetToDoListTitle (int id, string title);
    }
}
