using Microsoft.Extensions.Primitives;
using ToDoListAPI.Models;

namespace ToDoListAPI.Interfaces.Models
{
    public interface IToDoList
    {
        int Id { get; }
        string Title { get; }
        IReadOnlyList<TaskToDo> Tasks { get; }
        void SetTitle(string title);
        void SetTaskDescription(int taskId,  string description);

    }
}
