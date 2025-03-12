using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingCompanyApp.Models;

namespace TradingCompanyApp.Services
{
    internal static class EmployeeService
    {
        static ApplicationDbContext context = ApplicationDbContext.context;
        internal static void AddEmployee(Employee emp)
        {
            context.Users.Add(emp);
            context.SaveChanges();
        }

        internal static List<Employee> ViewEmployees()
        {
            context.Users.Load();
            List<Employee> employees = context.Users.Where(u => u is Employee).Cast<Employee>().ToList();
            return employees;
        }
    }
}
