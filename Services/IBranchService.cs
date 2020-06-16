using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreManagement.Models;
using StoreManagement.ViewModels;

namespace StoreManagement.Services
{
    public interface IBranchService
    {
        List<Branch> GetAllBranches();
        void AddBranch(Branch branch);
        Branch GetSingleBranchById(int id);
        void UpdateBranch(Branch newBranch);
        void DeleteBranch(int id);
        List<Employee> GetEmployeesByBranchId(int branchId);
        BranchViewModel BranchDeletionConfirmation(int id);
        BranchViewModel BranchDetails(int id);
        
    }
}
