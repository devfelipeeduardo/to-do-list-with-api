using ToDoListAPI.Interfaces.Models;
using System.Linq;

namespace ToDoListAPI.Services
{
    public class ToDoListService : IToDoListService
    {
        public readonly IToDoList _toDoList;

        public ToDoListService(IToDoList toDoList) {
            _toDoList = toDoList;
        }

        public void SetTaskDescription(int id, string description)
        {
            if (_toDoList.Tasks != null) return;

            ITaskTD task = _toDoList.Tasks.FirstOrDefault(t => t.Id == id);

            if (task != null)
            {
                task.SetDescription(description);
            }
        }

        public void SetToDoListTitle(int id, string title)
        {
            if (_toDoList.Id == id)
            {
                _toDoList.SetTitle(title);
            }
        }
    }
}
