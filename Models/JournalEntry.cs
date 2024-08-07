using System;
using System.ComponentModel.DataAnnotations;

namespace JournalToDoApp.Models
{
    public class JournalEntry
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Content { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string UserId { get; set; } = string.Empty;
        
        public ApplicationUser User { get; set; } = new ApplicationUser();
    }
}
