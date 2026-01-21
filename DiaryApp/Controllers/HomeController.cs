using DiaryApp.Data;
using DiaryApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
namespace DiaryApp.Controllers
{

    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            if (!User.Identity?.IsAuthenticated ?? true)
            {
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }
            var totalEntries = await _context.DiaryEntries.CountAsync();

            var now = DateTime.Now;
            var startOfMonth = new DateTime(now.Year, now.Month, 1);
            var thisMonth = await _context.DiaryEntries
                .Where(e => e.Created >= startOfMonth)
                .CountAsync();

            var startOfWeek = now.AddDays(-(int)now.DayOfWeek);
            var thisWeek = await _context.DiaryEntries
                .Where(e => e.Created >= startOfWeek)
                .CountAsync();

            ViewBag.TotalEntries = totalEntries;
            ViewBag.ThisMonth = thisMonth;
            ViewBag.ThisWeek = thisWeek;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult MyPage()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}