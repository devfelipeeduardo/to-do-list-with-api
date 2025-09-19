using ToDoListAPI.Models;

namespace ToDoListAPI.Interfaces.Models
{
    public interface ITaskToDo
    {
        int Id { get; }
        int TaskNumber { get;}
        bool IsChecked { get; }
        string Description { get; }

        int ToDoListId { get;} // FK
        ToDoList ToDoList { get;} // referência para navegação

        void ToggleChecked();

        void SetTaskDescription(string description);
    }
}
