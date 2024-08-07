using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using JournalToDoApp.Data;
using JournalToDoApp.Models;
using Microsoft.AspNetCore.Identity;

namespace JournalToDoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> Main()
        {
            var userId = _userManager.GetUserId(User);
            var journalEntries = _context.JournalEntries.Where(e => e.UserId == userId).ToList();
            var toDoItems = _context.ToDoItems.Where(t => t.UserId == userId).ToList();

            var model = new MainPageViewModel
            {
                JournalEntries = journalEntries,
                ToDoItems = toDoItems
            };

            return View(model);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
