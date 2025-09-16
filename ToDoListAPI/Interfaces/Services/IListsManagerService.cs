using ToDoListAPI.Interfaces.Models;

namespace ToDoListAPI.Interfaces.Services
{
    public interface IListsManagerService
    {
        void AddToDoListAsync(IToDoList toDoList);
        void SetTaskDescriptionAsync(int toDoListId, int taskId, string description);
        void SetToDoListTitleAsync(int id, string title);
    }
}
