using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreManagement.Data;
using StoreManagement.Models;
using StoreManagement.Services;
using StoreManagement.ViewModels;


namespace StoreManagement.Controllers
{
    [Authorize]
    public class StoreController : Controller
    {

        private IStoreService _storeService;
        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }
        [AllowAnonymous]
        public IActionResult All()
        {
            return View(_storeService.GetAllStores());
        }
        public IActionResult CreateStore() => View();
        public IActionResult StoreCreated(Store store)
        {

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Something went wrong!");
                return View("CreateStore");
            }
            _storeService.AddStore(store);
            return View();
        }


        public IActionResult EditStore(int id) => View(_storeService.GetSingleStoreById(id));


        public IActionResult StoreEdited(Store newStore)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Something went wrong!");
                return View("EditStore", newStore);
            }
            _storeService.UpdateStore(newStore);

            return View();

        }

        public IActionResult DeleteStore(int id) => View(_storeService.StoreDeletionConfirmation(id));


        public IActionResult StoreDeleted(int id)
        {
            _storeService.DeleteStore(id);
            return View();
        }

        public IActionResult StoreDetails(int id)
        {

            return View(_storeService.StoreDetails(id));
        }

        [Route("/search/{name}")]
        public IActionResult Search(string name)
        {
            string searchName = name;
            return View();
        }
    }
}
