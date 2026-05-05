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

        // GET: PackingLists
        public async Task<IActionResult> Index()
        {
            return View(await _context.PackingList.ToListAsync());
        }

        // GET: PackingLists/Details/5
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

        // GET: PackingLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PackingLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PackingListId,ListName")] PackingList packingList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(packingList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(packingList);
        }

        // GET: PackingLists/Edit/5
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

        // POST: PackingLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PackingListId,ListName")] PackingList packingList)
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

        // GET: PackingLists/Delete/5
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

        // POST: PackingLists/Delete/5
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
