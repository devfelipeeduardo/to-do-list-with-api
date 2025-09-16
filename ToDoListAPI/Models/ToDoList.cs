using ToDoListAPI.Interfaces.Models;

namespace ToDoListAPI.Models
{
    public class ToDoList : IToDoList
    {
        public int Id {  get; private set; }
        public string Title { get; private set; } = string.Empty;
        public List<ITaskTD> Tasks { get; private set; } = new();

        public void SetTitle(string title) {
            Title = title;
        }

    }
}
