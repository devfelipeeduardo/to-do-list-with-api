using ToDoListAPI.Interfaces.Models;

namespace ToDoListAPI.Models
{
    public class TaskToDo : ITaskToDo
    {
        public int Id { get; private set; }
        public bool IsChecked { get; private set; } = false;
        public string Description { get; private set; } = string.Empty;
        public TaskToDo() {}

        public void ToggleChecked() { 
            IsChecked = !IsChecked;
        }

        public void SetTaskDescription(string description)
        {
            Description = description;
        }


    }
}
