using ToDoListAPI.Interfaces.Models;

namespace ToDoListAPI.Models
{
    public class ToDoList : IToDoList
    {
        public int Id {  get; set; }
        public string Title { get; set; } = string.Empty;
        public List<TaskToDo> Tasks { get; set; } = [];

        IReadOnlyList<TaskToDo> IToDoList.Tasks => Tasks.AsReadOnly();

        public void SetTaskDescription(int taskNumber, string description)
        {

            ITaskToDo task = Tasks.FirstOrDefault(t => t.TaskNumber == taskNumber);

            if (task != null)
            {
                task.SetTaskDescription(description);
            }
        }

        public void SetTitle(string title)
        {
            Title = title;
        }

    }
}
