using ToDoListAPI.Interfaces.Models;

namespace ToDoListAPI.Models
{
    public class TaskTD : ITaskTD
    {
        public readonly int Id;
        public bool IsChecked { get; private set; }
        public string Description { get; private set; } = string.Empty;
        public TaskTD() { }

        public void ToggleChecked() { 
            IsChecked = !IsChecked;
        }

        public void SetDescription(string description)
        {
            Description = description;
        }
    }
}
