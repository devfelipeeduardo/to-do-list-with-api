using Microsoft.Extensions.Primitives;

namespace ToDoListAPI.Interfaces.Models
{
    public interface IToDoList
    {
        int Id { get; }
        string Title { get; }
        List<ITaskToDo> Tasks { get; }
        void SetTitle(string title);
        void SetTaskDescription(int taskId,  string description);

    }
}
