using System.Collections.Generic;

namespace JournalToDoApp.Models
{
    public class MainPageViewModel
    {
        public List<JournalEntry> JournalEntries { get; set; }
        public List<ToDoItem> ToDoItems { get; set; }
    }
}
