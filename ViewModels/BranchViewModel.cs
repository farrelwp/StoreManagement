using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreManagement.Models;

namespace StoreManagement.ViewModels
{
    public class BranchViewModel
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public List<Employee> Employees { get; set; }
        public object BranchName { get; internal set; }
    }
}
