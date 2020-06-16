using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreManagement.Data;
using StoreManagement.Models;
using StoreManagement.ViewModels;

namespace StoreManagement.Services
{
    public class BranchService : IBranchService
    {
        private AppDbContext _context;
        public BranchService(AppDbContext context)
        {
            _context = context;
        }
        public void AddBranch(Branch branch)
        {
            _context.Branches.Add(branch);
            _context.SaveChanges();
        }

        public void DeleteBranch(int id)
        {
            Branch branchToBeDeleted = GetSingleBranchById(id);
            _context.Branches.Remove(branchToBeDeleted);
            _context.SaveChanges();
        }

        public List<Branch> GetAllBranches()
        {
            List<Branch> branches = _context.Branches.Include(n => n.Store).ToList();
            return branches;
        }

        public Branch GetSingleBranchById(int id) => _context.Branches.Where(n => n.Id == id).FirstOrDefault();

        public List<Employee> GetEmployeesByBranchId(int branchId) => _context.Employees.Where(n => n.BranchId == branchId).ToList();
        

        public void UpdateBranch(Branch newBranch)
        {
            Branch oldBranch = GetSingleBranchById(newBranch.Id);
            oldBranch.Location = newBranch.Location;
            oldBranch.OwnerAge = newBranch.OwnerAge;
            oldBranch.PhoneNumber = newBranch.PhoneNumber;
            oldBranch.YearsOfOperation = newBranch.YearsOfOperation;
            oldBranch.StoreId = newBranch.StoreId;
            _context.SaveChanges();
        }

        public BranchViewModel BranchDeletionConfirmation(int id)
        {

            Branch branch = GetSingleBranchById(id);
            BranchViewModel branchVM = new BranchViewModel()
            {
                Id = branch.Id,
                BranchName = branch.Location
            };

            return branchVM;

        }

        public BranchViewModel BranchDetails(int id)
        {
            Branch branch = GetSingleBranchById(id);
            BranchViewModel branchVM = new BranchViewModel()
            {
                BranchName = branch.Location,
                Employees = GetEmployeesByBranchId(id)
            };
            return branchVM;

        }
    }
}
