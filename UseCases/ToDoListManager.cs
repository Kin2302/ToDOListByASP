using Enities;

namespace UseCases
{
    public class ToDoListManager
    {
        private readonly IToDoItemRepository repository;


        public ToDoListManager(IToDoItemRepository repository)
        {
            this.repository = repository;
        }



        public IEnumerable<ToDoItem> getToDoItem()
        {
            return repository.GetItem();
        }

        public void AddTodoItem(ToDoItem item)
        {
            repository.Add(item);
        }

        public void MarkComplete(int id ) {
            var item =  repository.GetById(id);
            if (item != null)
            {
                item.isCompleted = true;


            }

            repository.Update(item);

                
        
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }



    }
}
