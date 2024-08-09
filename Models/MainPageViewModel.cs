using System;
using System.Collections.Generic;

namespace JournalToDoApp.Models
{
    public class MainPageViewModel
    {
        public DateTime SelectedDate { get; set; } = DateTime.Today;
        public List<JournalEntry> JournalEntries { get; set; } = new List<JournalEntry>();
        public List<ToDoItem> ToDoItems { get; set; } = new List<ToDoItem>();
    }
}
