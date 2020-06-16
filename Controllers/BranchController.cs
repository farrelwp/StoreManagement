using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreManagement.Models;
using StoreManagement.Data;
using StoreManagement.ViewModels;
using Microsoft.EntityFrameworkCore;
using StoreManagement.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace StoreManagement.Controllers
{
    [Authorize]
    public class BranchController : Controller
    {
        private IBranchService _branchService;
        private IStoreService _storeService;
        public BranchController(IBranchService branchService, IStoreService storeService)
        {
            _branchService = branchService;
            _storeService = storeService;

        }

        [AllowAnonymous]
        public IActionResult AllBranches()
        {
            return View(_branchService.GetAllBranches());
        }
        public IActionResult CreateBranch()
        {
            ViewBag.Stores = _storeService.GetAllStores();
            return View();
        }
        public IActionResult BranchCreated(Branch branch)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Something went wrong");
                ViewBag.Stores = _storeService.GetAllStores();
                return View("CreateBranch");
            }
            _branchService.AddBranch(branch);
            return View();
        }
        public IActionResult EditBranch(int id)
        {
            ViewBag.Stores = _storeService.GetAllStores();
            return View(_branchService.GetSingleBranchById(id));
        }
        public IActionResult BranchEdited(Branch newBranch)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Something went wrong");
                ViewBag.Stores = _storeService.GetAllStores();
                return View("EditBranch", newBranch);
            }
            _branchService.UpdateBranch(newBranch);
            return View();

        }

        public IActionResult DeleteBranch(int id) => View(_branchService.BranchDeletionConfirmation(id));

        public IActionResult BranchDeleted(int id)
        {
            _branchService.DeleteBranch(id);

            return View();
        }
        public IActionResult BranchDetails(int id)
        {
            return View(_branchService.BranchDetails(id));
        }
    }
}