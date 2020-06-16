using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreManagement.Models;
using StoreManagement.ViewModels;

namespace StoreManagement.Services
{
    public interface IEmployeeService
    {
        List<Employee> GetAllEmployees();
        void AddEmployee(Employee employee);
        Employee GetSingleEmployeeById(int id);
        void UpdateEmployee(Employee newEmployee);
        void DeleteEmployee(int id);
        EmployeeViewModel EmployeeDeletionConfirmation(int id);
    }
}
