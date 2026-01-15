using Enities;
using UseCases;

namespace Infrastructor
{
    public class InMemoryToDoItemRepository : IToDoItemRepository
    {
        private readonly List<ToDoItem> _items;

        public InMemoryToDoItemRepository() => _items = [];


        public void Add(ToDoItem item)
        {
            if (_items.Count == 0)
            {
                item.Id = 1;
            }
            else
            {
                item.Id = _items.Max(i => i.Id) + 1;
            }

            _items.Add(item);
        }

        public void Delete(int id)
        {
            var item = _items.First(x => x.Id == id);
            if (item != null)
            {
                _items.Remove(item);
            }

        }

        public ToDoItem GetById(int id)
        {
            return _items.FirstOrDefault(item => item.Id == id);
        }

        public IEnumerable<ToDoItem> GetItem()
        {
            return _items;
        }

        public void Update(ToDoItem? item)
        {
            if (item == null)
                return;

            var existingItem = _items.FirstOrDefault(i => i.Id == item.Id);
            if (existingItem != null)
            {
                existingItem.Text = item.Text;
                existingItem.isCompleted = item.isCompleted;
            }
        }
    }
}
