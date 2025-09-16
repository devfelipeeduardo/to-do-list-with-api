using System.Threading.Tasks;
using ToDoListAPI.Interfaces.Models;
using ToDoListAPI.Interfaces.Services;
using ToDoListAPI.Models;
using static ToDoListAPI.Services.ListsManagerService;

namespace ToDoListAPI.Services
{
    public class ListsManagerService : IListsManagerService
    {
        private readonly IListsManager _listsManager;

        public ListsManagerService(IListsManager listsManager)
        {
            _listsManager = listsManager;
        }

        //Controller Not OK
        public void AddToDoListAsync(IToDoList toDoList)
        {
            _listsManager.AddToDoList(toDoList);
        }

        //Controller OK
        public void SetTaskDescriptionAsync(int toDoListId, int taskId, string description)
        {
            foreach (var toDoList in _listsManager.ToDoLists)
            {
                if (toDoList.Id == toDoListId)
                {
                    toDoList.SetTaskDescription(taskId, description);
                }
            }
        }

        //Controller OK
        public void SetToDoListTitleAsync(int toDoListId, string title)
        {
            foreach (var toDoList in _listsManager.ToDoLists)
            {
                if (toDoList.Id == toDoListId)
                {
                    toDoList.SetTitle(title);
                }
            }
        }
    }
}
