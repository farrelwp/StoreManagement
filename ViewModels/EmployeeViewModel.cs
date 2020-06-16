using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string EmployeeFullName { get; set; }
        public object EmployeeName { get; internal set; }
    }
}
