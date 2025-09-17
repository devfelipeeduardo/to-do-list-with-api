using ToDoListAPI.Interfaces.Models;

namespace ToDoListAPI.Models
{
    public class ListsManager : IListsManager
    {
        public List<IToDoList> ToDoLists { get; set; } = [];

        public void AddToDoList(IToDoList toDoList)
        {
            ToDoLists.Add(toDoList);
        }
    }
}
