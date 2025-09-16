namespace ToDoListAPI.Interfaces.Models
{
    public interface ITaskTD
    {
        int Id { get;}
        bool IsChecked { get; }
        string Description { get; }

        void ToggleChecked();

        void SetDescription(string description);
    }
}
