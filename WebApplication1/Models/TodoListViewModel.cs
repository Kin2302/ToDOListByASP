using Enities;

namespace ToDoList.Models
{
    public class TodoListViewModel
    {
        public required IEnumerable<Item> Items { get; init; }

    }
}
