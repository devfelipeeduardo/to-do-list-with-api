using ToDoListAPI.Interfaces.Models;

namespace ToDoListAPI.Models
{
    public class ToDoList : IToDoList
    {
        public int Id {  get; private set; }
        public string Title { get; private set; } = string.Empty;
        public List<ITaskToDo> Tasks { get; private set; } = [];

        public void SetTaskDescription(int taskId, string description)
        {

            ITaskToDo task = Tasks.FirstOrDefault(t => t.Id == taskId);

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
