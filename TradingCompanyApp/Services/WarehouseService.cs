using Microsoft.EntityFrameworkCore;
using TradingCompanyApp.Models;
using TradingCompanyApp.Models.Reports;

namespace TradingCompanyApp.Services
{
    public static class WarehouseService
    {
        static ApplicationDbContext context = new ApplicationDbContext();
        public static void AddWarehouse(Warehouse warehouse)
        {
            warehouse.AuthorizedUsers.Add(ApplicationDbContext.ActiveUser); //add the current user to the authorized users
            ApplicationDbContext.ActiveUser.AccessibleWarehouses.Add(warehouse); //add the warehouse to accessible warehouses
            context.Warehouses.Add(warehouse);

            Employee manager = (Employee)context.Users.Find(warehouse.ManagerId)!;
            if (manager != ApplicationDbContext.ActiveUser && manager != null)
            {
                manager.AccessibleWarehouses.Add(warehouse);
                warehouse.AuthorizedUsers.Add(manager);
            }
            else if (manager is null)
            {
                throw new ArgumentException("Invalid Manager ID");
            }
            context.SaveChanges();
        }
        internal static void UpdateWarehouseById(int id, Dictionary<string, object> options)
        {
            var warehouse = context.Warehouses.Find(id);
            if (warehouse == null)
                throw new ArgumentException($"Warehouse with ID {id} is not found");
            else
            {
                for (int i = 0; i < options.Count; i++)
                {
                    switch (options.ElementAt(i).Key)
                    {
                        case "Name":
                            warehouse.Name = options.ElementAt(i).Value.ToString();
                            break;
                        case "Address":
                            warehouse.Address = options.ElementAt(i).Value.ToString();
                            break;
                        case "Manager ID":
                            warehouse.ManagerId = (int)options.ElementAt(i).Value;
                            break;
                    }
                }
                context.Warehouses.Update(warehouse);
                context.SaveChanges();
            }
        }
        internal static List<Warehouse> GetWarehousesByCurrentManagerId(int id)
        {
            Employee emp = (Employee)context.Users.Include(s => s.AccessibleWarehouses).SingleOrDefault(e => e.UserId == id)!;
            return context.Warehouses.Where(w => w.ManagerId == emp.UserId).ToList();
        }
        public static List<Warehouse> GetWarehouses()
        {
            return context.Warehouses.Include(w => w.AuthorizedUsers).ToList();
        }

        public static Warehouse GetWarehouseById(int id)
        {
            var warehouse = context.Warehouses.Find(id);
            if (warehouse == null)
                throw new ArgumentException($"Warehouse with ID {id} is not found");
            else
                return warehouse;
        }

        public static bool DeleteWarehouseById(int id)
        {
            var warehouse = context.Warehouses.Find(id);
            if (warehouse == null)
                throw new ArgumentException($"Warehouse with ID {id} is not found");
            else
            {
                context.Warehouses.Remove(warehouse);
                context.SaveChanges();
                return true;
            }
        }
    }
}
