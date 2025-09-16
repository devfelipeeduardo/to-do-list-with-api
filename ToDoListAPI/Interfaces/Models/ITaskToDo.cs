namespace ToDoListAPI.Interfaces.Models
{
    public interface ITaskToDo
    {
        int Id { get;}
        bool IsChecked { get; }
        string Description { get; }

        void ToggleChecked();

        void SetTaskDescription(string description);
    }
}
