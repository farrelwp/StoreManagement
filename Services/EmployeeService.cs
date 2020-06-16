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
    public class EmployeeService : IEmployeeService
    {
        private AppDbContext _context;
        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }
        public void AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            Employee employeeToBeDeleted = GetSingleEmployeeById(id);
            _context.Employees.Remove(employeeToBeDeleted);
            _context.SaveChanges();
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = _context.Employees.Include(n => n.Branch).ToList();
            return employees;
        }

        public Employee GetSingleEmployeeById(int id) => _context.Employees.Where(n => n.Id == id).FirstOrDefault();

        

        public void UpdateEmployee(Employee newEmployee)
        {
            Employee oldEmployee = GetSingleEmployeeById(newEmployee.Id);
            oldEmployee.FullName = newEmployee.FullName;
            oldEmployee.NickName = newEmployee.NickName;
            oldEmployee.EmailAddress = newEmployee.EmailAddress;
            oldEmployee.Age = newEmployee.Age;
            oldEmployee.Birthday = newEmployee.Birthday;
            oldEmployee.Role = newEmployee.Role;
            oldEmployee.BranchId = newEmployee.BranchId;
            _context.SaveChanges();
        }

        public EmployeeViewModel EmployeeDeletionConfirmation(int id)
        {

            Employee employee = GetSingleEmployeeById(id);
            EmployeeViewModel employeeVM = new EmployeeViewModel()
            {
                Id = employee.Id,
                EmployeeName = employee.FullName
            };

            return employeeVM;

        }
    }
}
