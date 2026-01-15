namespace ToDoList.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public bool isCompleted { get; set; }
    }
}
