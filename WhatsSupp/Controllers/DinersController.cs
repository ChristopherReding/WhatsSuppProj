using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WhatsSupp.Contracts;
using WhatsSupp.Data;
using WhatsSupp.Models;
using WhatsSupp.ViewModels;

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
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var diner = await _repo.Diner.FindDiner(userId);
            if(diner == null)
            {
                return RedirectToAction("Create");
            }
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
        public async Task<IActionResult> Create()
        {
            DinerCuisineVM dinerCuisineVM = new DinerCuisineVM();

            //grab list of all cuisines
            var cuisineIds = await _repo.Cuisine.GetAllCuisineIds();
            dinerCuisineVM.Cuisines = await GetCuisines(cuisineIds);
            return View(dinerCuisineVM);
        }    

        // POST: Diners/Create        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DinerCuisineVM VM)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                VM.Diner.IdentityUserId = userId;
                _repo.Diner.CreateDiner(VM.Diner);
                await _repo.Save();
                await UpdatePreferences(VM.Cuisines, VM.Diner);
                
                return View("index");
            }

            return View();//VM.Diner);
        }

        //gets list of cuisines based on a list of cuisine IDs
        public async Task<List<Cuisine>> GetCuisines(List<int> cuisineIds)
        {
            List<Cuisine> cuisines = new List<Cuisine>();
            foreach (int id in cuisineIds)
            {
                var results = await _repo.Cuisine.FindByCondition(p => p.CuisineId == id);
                cuisines.Add(results.FirstOrDefault());
            }
            return cuisines;
        }

        
        //will update preferences in cuisinejxn db
        public async Task UpdatePreferences(List<Cuisine> cuisines, Diner diner)
        {
            foreach(Cuisine cuisine in cuisines)
            {
                if (cuisine.Selected == true) 
                {
                    if( await _repo.CuisineJxn.PreferenceExists(cuisine, diner) == false)
                    {
                        CuisineJxn preference = new CuisineJxn();
                        preference.CuisineId = cuisine.CuisineId;
                        preference.DinerId = diner.DinerId;
                        _repo.CuisineJxn.CreatePreference(preference);
                        await _repo.Save();
                    }
                }
                else
                {
                    if(await _repo.CuisineJxn.PreferenceExists(cuisine, diner) == true)
                    {
                        var result = await _repo.CuisineJxn.FindByCondition(p => p.CuisineId == cuisine.CuisineId && p.DinerId == diner.DinerId);
                        if(result != null)
                        {
                             CuisineJxn preference = result.SingleOrDefault(); 
                             _repo.CuisineJxn.RemovePreference(preference);
                             await _repo.Save();
                        }
                        
                    }
                }
            }
        }
        
        public async Task<List<Cuisine>> GetAllCuisines(List<int> cuisineIds)
        {
            List<Cuisine> cuisines = new List<Cuisine>();
            foreach (int id in cuisineIds)
            {
                var results = await _repo.Cuisine.FindByCondition(p => p.CuisineId == id);
                cuisines.Add(results.FirstOrDefault());
            }
            return cuisines;

        }

        // GET: Diners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            DinerCuisineVM dinerCuisineVM = new DinerCuisineVM();
            //query for user
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
            dinerCuisineVM.Diner = diner;

            //get all cuisines
            var cuisineIds = await _repo.Cuisine.GetAllCuisineIds();
            var allCuisines = await GetCuisines(cuisineIds);

            //insert method to check change Selected to True for any existing.
            dinerCuisineVM.Cuisines = await _repo.CuisineJxn.ReflectCuisinePreferences(allCuisines, diner);

            return View(dinerCuisineVM);
        }

        // POST: Diners/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DinerCuisineVM VM)
        {
            if (id != VM.Diner.DinerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repo.Diner.EditDiner(VM.Diner);
                    await UpdatePreferences(VM.Cuisines, VM.Diner);
                    await _repo.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DinerExists(VM.Diner.DinerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(VM.Diner);
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
            var preferenceResults = await _repo.CuisineJxn.FindByCondition(p => p.DinerId == id);
            var cuisinePreferences = preferenceResults.ToList();
            foreach (CuisineJxn preference in cuisinePreferences)
            {
                _repo.CuisineJxn.RemovePreference(preference);
            }
            _repo.Diner.DeleteDiner(diner);
            await _repo.Save();
            return RedirectToAction("index", "home");
        }

        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Search(string email)
        {
            var person = await _repo.Diner.FindDinerByEmail(email);
            if(person == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("ConfirmContact", "Diners", new { id = person.DinerId });
            }
        }

        //Get
        public async Task<IActionResult> ConfirmContact(int id)
        {
            var contact = await _repo.Diner.FindDinerByDinerId(id);           
            return View(contact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmContact(int? contactId)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var diner = await _repo.Diner.FindDiner(userId);
            var contact = await _repo.Diner.FindDinerByDinerId(contactId);
            if (await _repo.Contact.ContactExists(diner, contact) == false)
            {
                Contact newContact = new Contact();
                newContact.Diner1Id = diner.DinerId;
                newContact.Diner2Id = contact.DinerId;
                _repo.Contact.CreateContact(newContact);
                await _repo.Save();
                return RedirectToAction("index");
            }
            
            return RedirectToAction("index");
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
