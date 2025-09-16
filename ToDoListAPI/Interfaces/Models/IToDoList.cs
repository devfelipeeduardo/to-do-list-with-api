using Microsoft.Extensions.Primitives;

namespace ToDoListAPI.Interfaces.Models
{
    public interface IToDoList
    {
        int Id { get; }
        string Title { get; }
        List<ITaskTD> Tasks { get; }
        void SetTitle(string title);

    }
}
