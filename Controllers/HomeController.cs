using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using JournalToDoApp.Data;
using JournalToDoApp.Models;
using Microsoft.EntityFrameworkCore;

namespace JournalToDoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Main(DateTime? date)
        {
            var selectedDate = date ?? DateTime.Today;

            var journalEntries = await _context.JournalEntries
                                                .Where(e => e.Date == selectedDate)
                                                .ToListAsync();

            var toDoItems = await _context.ToDoItems
                                          .Where(t => t.Date == selectedDate)
                                          .ToListAsync();

            var model = new MainPageViewModel
            {
                SelectedDate = selectedDate,
                JournalEntries = journalEntries,
                ToDoItems = toDoItems
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddToDoItem(string task, DateTime date)
        {
            if (!string.IsNullOrEmpty(task))
            {
                var toDoItem = new ToDoItem { Task = task, Date = date };
                _context.ToDoItems.Add(toDoItem);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Main", new { date });
        }

        [HttpPost]
        public async Task<IActionResult> AddJournalEntry(string title, string content, DateTime date)
        {
            if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(content))
            {
                var journalEntry = new JournalEntry { Title = title, Content = content, Date = date };
                _context.JournalEntries.Add(journalEntry);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Main", new { date });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteToDoItem(int id, DateTime date)
        {
            var toDoItem = await _context.ToDoItems.FindAsync(id);
            if (toDoItem != null)
            {
                _context.ToDoItems.Remove(toDoItem);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Main", new { date });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteJournalEntry(int id, DateTime date)
        {
            var journalEntry = await _context.JournalEntries.FindAsync(id);
            if (journalEntry != null)
            {
                _context.JournalEntries.Remove(journalEntry);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Main", new { date });
        }

        public IActionResult Index()
        {
            return RedirectToAction("Main");
        }

        public IActionResult NextDay(DateTime date)
        {
            var nextDay = date.AddDays(1);
            return RedirectToAction("Main", new { date = nextDay });
        }

        public IActionResult PreviousDay(DateTime date)
        {
            var previousDay = date.AddDays(-1);
            return RedirectToAction("Main", new { date = previousDay });
        }
    }
}
