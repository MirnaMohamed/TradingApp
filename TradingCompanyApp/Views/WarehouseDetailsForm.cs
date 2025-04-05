using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Windows.Forms;
using TradingCompanyApp.Models;
using TradingCompanyApp.Models.Reports;
using TradingCompanyApp.Services;

namespace TradingCompanyApp.Views
{
    public partial class WarehouseDetailsForm : Form
    {
        internal WarehouseDetailsForm(bool isUpdateMode, int? id)
        {
            InitializeComponent();
            Button submit = new Button();
            submit.Location = new Point(textBox4.Location.X, textBox4.Location.Y + 50);
            submit.Text = "Submit";
            ApplicationDbContext context = new ApplicationDbContext();
            Warehouse warehouse = context.Warehouses.Find(id);
            if (isUpdateMode)
            {
                this.Controls.Add(submit);
                submit.Click += UpdateWarehouse;
            }
            else // Preview Mode
            {
                List<Warehouse> warehouses = new List<Warehouse>();
                ListViewForm frm = new ListViewForm(ref id );
                if(frm.ShowDialog() == DialogResult.OK)
                {
                    if (id != null)
                    {
                        
                    }
                }
               
            }
            textBox1.Text = id.ToString(); 
            textBox2.Text = warehouse?.Name;
            textBox3.Text = warehouse?.Address;
            textBox4.Text = warehouse?.ManagerId.ToString();
        }

        private void UpdateWarehouse(object sender, EventArgs e)
        {
            try
            {
                int warehouseId = int.Parse(textBox1.Text);
                Dictionary<string, object> options = new Dictionary<string, object>();
                if (textBox2.Text != "")
                    options.Add("Name", textBox2.Text);
                if (textBox3.Text != "")
                    options.Add("Address", textBox3.Text);
                if (textBox4.Text != "")
                    options.Add("Manager ID", int.Parse(textBox4.Text.Trim()));
                WarehouseService.UpdateWarehouseById(warehouseId, options);
                LoginForm.SwitchForm(new HomeForm(), this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
