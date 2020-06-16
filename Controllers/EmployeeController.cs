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

namespace CrudCoreMVC.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {

        private IEmployeeService _employeeService;
        private IBranchService _branchService;
        public EmployeeController(IEmployeeService employeeService, IBranchService branchService)
        {
            _employeeService = employeeService;
            _branchService = branchService;
        }
        [AllowAnonymous]
        public IActionResult AllEmployees()
        {
                return View(_employeeService.GetAllEmployees());
        }

            public IActionResult CreateEmployee()
        {
            ViewBag.Branches = _branchService.GetAllBranches();
            return View();
        }
        public IActionResult EmployeeCreated(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Branches = _branchService.GetAllBranches();
                ModelState.AddModelError(string.Empty, "Something went wrong");
                return View("CreateEmployee");
            }
            _employeeService.AddEmployee(employee);
            return View();
        }
        public IActionResult EditEmployee(int id)
        {
            ViewBag.Branches = _branchService.GetAllBranches();
            return View(_employeeService.GetSingleEmployeeById(id));
        }
        public IActionResult EmployeeEdited(Employee newEmployee)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Something went wrong");
                ViewBag.Branches = _branchService.GetAllBranches();
                return View("EditEmployee", newEmployee);
            }
            _employeeService.UpdateEmployee(newEmployee);
            return View();

        }

        public IActionResult DeleteEmployee(int id) => View(_employeeService.EmployeeDeletionConfirmation(id));


        public IActionResult EmployeeDeleted(int id)
        {
            _employeeService.DeleteEmployee(id);
            return View();

        }
    }
}