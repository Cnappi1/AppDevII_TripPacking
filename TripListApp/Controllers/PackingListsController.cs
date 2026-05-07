using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TripListApp.Data;
using TripListApp.Models;

namespace TripListApp.Controllers
{
    public class PackingListsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PackingListsController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            var lists = await _context.PackingList
                .Include(p => p.Items)
                .ToListAsync();

            decimal yearlyBudget = 0;
            int selectedYear = DateTime.Now.Year;

            if (TempData["YearlyBudget"] != null)
            {
                yearlyBudget = Convert.ToDecimal(TempData["YearlyBudget"]);
                TempData.Keep("YearlyBudget");
            }

            if (TempData["SelectedYear"] != null)
            {
                selectedYear = Convert.ToInt32(TempData["SelectedYear"]);
                TempData.Keep("SelectedYear");
            }

            List<PackingList> listsToShow;

            if (selectedYear == 0)
            {
                listsToShow = lists;
            }
            else
            {
                listsToShow = lists.Where(list => list.TripYear == selectedYear).ToList();
            }

            var manager = new ListManager(listsToShow, yearlyBudget);

            ViewBag.SelectedYear = selectedYear;
            ViewBag.YearlyTravelBudget = manager.YearlyTravelBudget;
            ViewBag.TotalTripBudgets = listsToShow.Sum(list => list.TripBudget);
            ViewBag.RemainingYearlyBudget = yearlyBudget - listsToShow.Sum(list => list.TripBudget);

            return View(listsToShow);
        }

       
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var packingList = await _context.PackingList
                .Include(p => p.Items)
                .FirstOrDefaultAsync(m => m.PackingListId == id);
            if (packingList == null)
            {
                return NotFound();
            }

            return View(packingList);
        }

        
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PackingListId,ListName,TripBudget,TripYear")] PackingList packingList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(packingList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(packingList);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var packingList = await _context.PackingList.FindAsync(id);
            if (packingList == null)
            {
                return NotFound();
            }
            return View(packingList);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PackingListId,ListName,TripBudget,TripYear")] PackingList packingList)
        {
            if (id != packingList.PackingListId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(packingList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PackingListExists(packingList.PackingListId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(packingList);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var packingList = await _context.PackingList
                .FirstOrDefaultAsync(m => m.PackingListId == id);
            if (packingList == null)
            {
                return NotFound();
            }

            return View(packingList);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var packingList = await _context.PackingList.FindAsync(id);
            if (packingList != null)
            {
                _context.PackingList.Remove(packingList);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PackingListExists(int id)
        {
            return _context.PackingList.Any(e => e.PackingListId == id);
        }
    }
}
