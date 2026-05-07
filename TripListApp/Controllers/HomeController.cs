using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TripListApp.Models;
using TripListApp.Data;
using System.Linq;

namespace TripListApp.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var lists = _context.PackingList.ToList(); 
            return View(lists);
        }

        [HttpPost]
        public IActionResult Create(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                if (_context != null)
                {
                    _context.PackingList.Add(new PackingList { ListName = name });
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var list = _context.PackingList.Find(id);
            if (list != null)
            {
                _context.PackingList.Remove(list);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult SetYearlyBudget(decimal budget, int year)
        {
            TempData["YearlyBudget"] = budget.ToString();
            TempData["SelectedYear"] = year.ToString();

            return RedirectToAction("Index", "PackingLists");
        }
    }
}
