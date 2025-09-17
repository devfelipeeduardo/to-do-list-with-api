using System.Text.Json.Serialization;
using ToDoListAPI.Interfaces.Models;

namespace ToDoListAPI.Models
{
    public class TaskToDo : ITaskToDo
    {
        public int Id { get; set; }
        public bool IsChecked { get; set; } = false;
        public string Description { get; set; } = string.Empty;
        public int ToDoListId { get; set; }

        [JsonIgnore]
        public ToDoList? ToDoList { get; set; }

        public void ToggleChecked() { 
            IsChecked = !IsChecked;
        }

        public void SetTaskDescription(string description)
        {
            Description = description;
        }


    }
}
