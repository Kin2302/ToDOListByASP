using Enities;
using System;
using System.Collections.Generic;
using System.Text;

namespace UseCases
{
    public interface IToDoItemRepository
    {
        void Add(ToDoItem item);
        void Delete(int id);
        ToDoItem GetById(int id);
        IEnumerable<ToDoItem> GetItem();
        void Update(ToDoItem? item);
    }
}
