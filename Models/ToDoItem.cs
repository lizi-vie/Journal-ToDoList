using System;
using System.ComponentModel.DataAnnotations;

namespace JournalToDoApp.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }

        [Required]
        public string Task { get; set; } = string.Empty;

        public bool IsCompleted { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string UserId { get; set; } = string.Empty;
        
        public ApplicationUser User { get; set; } = new ApplicationUser();
    }
}
