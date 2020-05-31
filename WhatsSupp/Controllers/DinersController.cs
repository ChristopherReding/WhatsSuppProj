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
using WhatsSupp.RootObjects;
using WhatsSupp.Services;
using WhatsSupp.ViewModels;

namespace WhatsSupp.Controllers
{
    public class DinersController : Controller
    {
        private readonly IRepositoryWrapper _repo;
        private readonly IGoogleAPIRepository _googleAPI;
        private readonly IRapidAPIRepository _rapidAPI;


        public DinersController(IRepositoryWrapper repo, IGoogleAPIRepository googleAPI, IRapidAPIRepository rapidAPI)
        {
            _repo = repo;
            _googleAPI = googleAPI;
            _rapidAPI = rapidAPI;
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
            var allContactIds = await _repo.Contact.GetContactIds(diner.DinerId);
            List<Diner> contacts = new List<Diner>();
            foreach (int contactId in allContactIds)
            {
                var contact = await _repo.Diner.FindDinerByDinerId(contactId);
                contacts.Add(contact);
            }
            diner.Contacts = contacts;
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
                
                return RedirectToAction("index");
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
            var contactResults = await _repo.Contact.FindByCondition(p => p.Diner1Id == id || p.Diner2Id == id);
            var contactsToRemove = contactResults.ToList();
            foreach (Contact contact in contactsToRemove)
            {
                _repo.Contact.RemoveContact(contact);
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

        public async Task<IActionResult> SetupWhatsSupp()
        {
            SetUpViewModel setUpViewModel = new SetUpViewModel();
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            setUpViewModel.Diner = await _repo.Diner.FindDiner(userId);

            var contactIds = await _repo.Contact.GetContactIds(setUpViewModel.Diner.DinerId);
            List<SelectListItem> contacts = new List<SelectListItem>();
            foreach(int id in contactIds)
            {
                var result = await _repo.Diner.FindDinerByDinerId(id);
                SelectListItem selectListItem = new SelectListItem
                {
                    Text = result.FirstName + " " + result.LastName,
                    Value = result.DinerId.ToString()
                };
                contacts.Add(selectListItem);
            }
            ViewData["Contacts"] = contacts;

            
            
            return View(setUpViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SetUpWhatsSupp(SetUpViewModel setUpViewModel)
        {
            await ClearPreviousWhatsSupp(setUpViewModel.Diner.DinerId);
            //get geo coordinates to base search
            Geolocation coordinates = await _googleAPI.GetGeolocation();
            //get preferences as a string to insert in the search criteria
            var cuisineIds = await _repo.Cuisine.GetAllCuisineIds();
            var allCuisines = await GetCuisines(cuisineIds);
            var preferedCuisines = await _repo.CuisineJxn.GetListOfCuisinePreferences(allCuisines, setUpViewModel.Diner);
            var preferedCuisineString = _repo.CuisineJxn.preferencesAsString(preferedCuisines);

            double searchRadius = setUpViewModel.searchRadius;
            //run API call for nearby restaurants
            setUpViewModel.nearbyRestaurants = await _rapidAPI.GetNearbyRestaurants(coordinates, searchRadius, preferedCuisineString);

            await AddSearchToDb(setUpViewModel.nearbyRestaurants, setUpViewModel.Diner.DinerId, setUpViewModel.Diner2.DinerId);
            return RedirectToAction("MyWhatsSuppTonight");

        }

        public async Task AddSearchToDb(NearbyRestaurants nearbyRestaurants, int diner1Id, int diner2Id)
        {
            for (int i = 0; i < nearbyRestaurants.result.data.Length; i++)
            {
                PotentialMatch potentialMatch = new PotentialMatch();
                potentialMatch.Diner1Id = diner1Id;
                potentialMatch.Diner2Id = diner2Id;
                potentialMatch.RestaurantName = nearbyRestaurants.result.data[i].restaurant_name;
                potentialMatch.RestaurantAddress = nearbyRestaurants.result.data[i].address.formatted;
                potentialMatch.RestaurantId = nearbyRestaurants.result.data[i].restaurant_id;
                potentialMatch.PriceRange = nearbyRestaurants.result.data[i].price_range;
                potentialMatch.PhoneNumber = nearbyRestaurants.result.data[i].restaurant_phone;

                string cuisines = "";
                for (int j = 0; j < nearbyRestaurants.result.data[i].cuisines.Length; j++)
                {
                    cuisines += $"{nearbyRestaurants.result.data[i].cuisines[j]} ";
                }

                potentialMatch.Cuisines = cuisines;
                potentialMatch.TimeStamp = DateTime.Now;
                _repo.PotentialMatch.CreateMatch(potentialMatch);
                await _repo.Save();
            }
        }
        public async Task ClearPreviousWhatsSupp(int? dinerId)
        {
            var result = await _repo.PotentialMatch.GetAllPriorPotentialMatches(dinerId);
            if(result.Count > 0)
            {
                foreach(PotentialMatch potentialMatch in result)
                {
                    _repo.PotentialMatch.DeleteMatch(potentialMatch);
                    await _repo.Save();
                }

            }
            
        } 
        public async Task<IActionResult> MyWhatsSuppTonight()
        {
            SeeWhatsSuppVM seeWhatsSuppVM = new SeeWhatsSuppVM();
            //get diner1
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            seeWhatsSuppVM.Diner = await _repo.Diner.FindDiner(userId);
            //get an option to display
            seeWhatsSuppVM.PotentialMatch = await _repo.PotentialMatch.GetOneToMatch(seeWhatsSuppVM.Diner.DinerId);
            if(seeWhatsSuppVM.PotentialMatch == null)
            {
                return RedirectToAction("index");
            };

            //get diner2
            seeWhatsSuppVM.Diner2 = await _repo.Diner.FindDinerByDinerId(seeWhatsSuppVM.PotentialMatch.Diner2Id);

            var results = await _repo.PotentialMatch.GetAllMatches(seeWhatsSuppVM.Diner.DinerId, seeWhatsSuppVM.Diner2.DinerId);
            seeWhatsSuppVM.Matches = results.ToList();
            //return view with VM
            return View(seeWhatsSuppVM);
        }

        [HttpPost]
        public async Task<IActionResult> MyWhatsSuppTonight(int? matchId, bool chosen)
        {
            var potentialMatch = await _repo.PotentialMatch.FindPotentialMatchByMatchId(matchId);

            if (chosen == false)
            {
                _repo.PotentialMatch.DeleteMatch(potentialMatch);
                await _repo.Save();
            }
            else if (chosen == true)
            {
                potentialMatch.Diner1Approved = true;
                _repo.PotentialMatch.UpdateMatch(potentialMatch);
                await _repo.Save();
            }
            return RedirectToAction("MyWhatsSuppTonight");

        }

        public async Task<IActionResult> ElseWhatsSuppTonight(int? dinerId)
        {
            SeeWhatsSuppVM seeWhatsSuppVM = new SeeWhatsSuppVM();
            //get diner2 (user)
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            seeWhatsSuppVM.Diner2 = await _repo.Diner.FindDiner(userId);
            //get diner1 (who started the WhatsSupp)
            seeWhatsSuppVM.Diner = await _repo.Diner.FindDinerByDinerId(dinerId);                      
            //get a match to display
            seeWhatsSuppVM.PotentialMatch = await _repo.PotentialMatch.GetOneToMatch(seeWhatsSuppVM.Diner.DinerId, seeWhatsSuppVM.Diner2.DinerId);
            if(seeWhatsSuppVM.PotentialMatch == null)
            {
                return RedirectToAction("index");
            };
            var results = await _repo.PotentialMatch.GetAllMatches(seeWhatsSuppVM.Diner.DinerId, seeWhatsSuppVM.Diner2.DinerId);
            seeWhatsSuppVM.Matches = results.ToList();

            return View(seeWhatsSuppVM);
        }
        [HttpPost]
        public async Task<IActionResult> ElseWhatsSuppTonight(int? matchId, bool chosen)
        {
            var potentialMatch = await _repo.PotentialMatch.FindPotentialMatchByMatchId(matchId);

            if (chosen == false)
            {
                _repo.PotentialMatch.DeleteMatch(potentialMatch);
                await _repo.Save();
            }
            else if (chosen == true)
            {
                potentialMatch.Diner2Approved = true;
                _repo.PotentialMatch.UpdateMatch(potentialMatch);
                await _repo.Save();
            }
            return RedirectToAction("ElseWhatsSuppTonight", "Diners", new { dinerId = potentialMatch.Diner1Id });

        }

        [HttpGet]
        public async Task<IActionResult> RestaurantDetails(int restaurantId)
        {
            var restaurant = await _repo.PotentialMatch.FindPotentialMatchByRestaurantId(restaurantId);            
            return View(restaurant);
        }

        [HttpGet]
        public async Task<IActionResult> Menu(int restaurantId)
        {
            FullMenuVM fullMenuVM = new FullMenuVM();
            fullMenuVM.AllMenuPages = new List<Menu>();
            int i = 1;
            bool morePages;
            do
            {               
                var result = await _rapidAPI.GetMenu(restaurantId, i);                
                fullMenuVM.AllMenuPages.Add(result);
                morePages = result.result.morePages;
                i++;
            }
            while (morePages);

            if(fullMenuVM.AllMenuPages[0].result.totalResults > 0)
            {
                return View(fullMenuVM);
            }
            else
            {
                return RedirectToAction("NoMenu", "diners", new { id = restaurantId });
            }
            
        }
        [HttpGet]
        public async Task<IActionResult> NoMenu(int? id)
        {
            var potentialMatch = await _repo.PotentialMatch.FindPotentialMatchByRestaurantId(id);
            return View(potentialMatch);
        }

        public async Task<IActionResult> ChooseAWhatsSupp()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var diner = await _repo.Diner.FindDiner(userId);

            var contactIds = await _repo.Contact.GetContactIds(diner.DinerId);
            List<Diner> contacts = new List<Diner>();
            foreach (int id in contactIds)
            {
                var result = await _repo.Diner.FindDinerByDinerId(id);
                contacts.Add(result);
            }
            diner.Contacts = contacts;
            return View(diner);
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
