using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var diner = await _repo.Diner.FindDiner(userId);
            return View(diner);
        }

        // GET: Diners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diner = await _repo.Diner.FindDinerByDinerId(id);
            if (diner == null)
            {
                return NotFound();
            }

            return View(diner);
        }

        // GET: Diners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Diners/Create        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Diner diner)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                diner.IdentityUserId = userId;
                _repo.Diner.CreateDiner(diner);
                await _repo.Save();
                return RedirectToAction("index");
            }
            
            return View(diner);
        }

        // GET: Diners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var diner = await _repo.Diner.FindDiner(userId);
            if (diner == null)
            {
                return NotFound();
            }
            return View(diner);
        }

        // POST: Diners/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Diner diner)
        {
            if (id != diner.DinerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repo.Diner.EditDiner(diner);
                    await _repo.Save();
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
            return View(diner);
        }

        // GET: Diners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diner = await _repo.Diner.FindDinerByDinerId(id);                
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
            var diner = await _repo.Diner.FindDinerByDinerId(id);
            _repo.Diner.DeleteDiner(diner);
            await _repo.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool DinerExists(int id)
        {
            try
            {
                _repo.Diner.FindDinerByDinerId(id);
                return true;
            }
            catch
            {
                return false;
            }
            
        }
    }
}
