using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WhatsSupp.Contracts;
using WhatsSupp.Data;
using WhatsSupp.Models;

namespace WhatsSupp.Controllers
{
    public class DinersController : Controller
    {
        private readonly IRepositoryWrapper _repo;

        public DinersController(IRepositoryWrapper repo)
        {
            _repo = repo;
        }

        // GET: Diners
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _repo.Diner.Include(d => d.IdentityUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Diners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diner = await _repo.Diner
                .Include(d => d.IdentityUser)
                .FirstOrDefaultAsync(m => m.DinerId == id);
            if (diner == null)
            {
                return NotFound();
            }

            return View(diner);
        }

        // GET: Diners/Create
        public IActionResult Create()
        {
            ViewData["IdentityUserId"] = new SelectList(_repo.Users, "Id", "Id");
            return View();
        }

        // POST: Diners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DinerId,FirstName,LastName,IdentityUserId")] Diner diner)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(diner);
                await _repo.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserId"] = new SelectList(_repo.Users, "Id", "Id", diner.IdentityUserId);
            return View(diner);
        }

        // GET: Diners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diner = await _repo.Diners.FindAsync(id);
            if (diner == null)
            {
                return NotFound();
            }
            ViewData["IdentityUserId"] = new SelectList(_repo.Users, "Id", "Id", diner.IdentityUserId);
            return View(diner);
        }

        // POST: Diners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DinerId,FirstName,LastName,IdentityUserId")] Diner diner)
        {
            if (id != diner.DinerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repo.Update(diner);
                    await _repo.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DinerExists(diner.DinerId))
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
            ViewData["IdentityUserId"] = new SelectList(_repo.Users, "Id", "Id", diner.IdentityUserId);
            return View(diner);
        }

        // GET: Diners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diner = await _repo.Diner
                .Include(d => d.IdentityUser)
                .FirstOrDefaultAsync(m => m.DinerId == id);
            if (diner == null)
            {
                return NotFound();
            }

            return View(diner);
        }

        // POST: Diners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var diner = await _repo.Diner.FindAsync(id);
            _repo.Diner.Remove(diner);
            await _repo.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool DinerExists(int id)
        {
            return _repo.Diners.Any(e => e.DinerId == id);
        }
    }
}
