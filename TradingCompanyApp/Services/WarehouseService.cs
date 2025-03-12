using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingCompanyApp.Services
{
    internal static class WarehouseService
    {
        static ApplicationDbContext context = ApplicationDbContext.context;
        internal static void UpdateWarehouseById(int id, Dictionary<string, object> options)
        {
            var warehouse = context.Warehouses.Find(id);
            if (warehouse == null)
                MessageBox.Show($"Warehouse with ID {id} is not found");
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
                            warehouse.ManagerId = (int) options.ElementAt(i).Value;
                            break;
                    }
                }
                context.Warehouses.Update(warehouse);
                context.SaveChanges();
            }
        }
    }
}
