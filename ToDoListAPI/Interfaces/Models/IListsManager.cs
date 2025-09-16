using ToDoListAPI.Interfaces.Models;

namespace ToDoListAPI.Models
{
    public interface IListsManager
    {
        List<IToDoList> ToDoLists { get; }

        void AddToDoList(IToDoList toDoList);
    }
}
