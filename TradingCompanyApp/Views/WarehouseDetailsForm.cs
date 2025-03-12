using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;
using TradingCompanyApp.Models;
using TradingCompanyApp.Models.Reports;
using TradingCompanyApp.Services;

namespace TradingCompanyApp.Views
{
    public partial class WarehouseDetailsForm : Form
    {
        internal WarehouseDetailsForm(bool isUpdateMode, int? id, WarehouseReport? report = null)
        {
            InitializeComponent();
            Button submit = new Button();
            submit.Location = new Point(textBox4.Location.X, textBox4.Location.Y + 50);
            submit.Text = "Submit";
            ApplicationDbContext context = ApplicationDbContext.context;
            Warehouse warehouse = context.Warehouses.Find(id);
            if (isUpdateMode)
            {
                this.Controls.Add(submit);
                submit.Click += UpdateWarehouse;
            }
            else // Preview Mode
            {
                ListBox listBox1 = new ListBox();
                this.Controls.Remove(textBox1);
                this.Controls.Remove(textBox2);
                this.Controls.Remove(textBox3);
                this.Controls.Remove(textBox4);
                this.Controls.Remove(label1);
                this.Controls.Remove(label2);
                this.Controls.Remove(label3);
                this.Controls.Remove(label4);
                listBox1.Items.Add($"Warehouse: {report.WarehouseName}");
                listBox1.Items.Add($"Period: {report.StartDate?.ToShortDateString()} - {report.EndDate?.ToShortDateString()}");
               // listBox1.Items.Add($"---------------------------------------------------");

                listBox1.Items.Add("Initial Stock:");
                foreach (var item in report.InitialStock)
                    listBox1.Items.Add($"Item: {item.ItemCode} - Quantity: {item.Quantity}");

                listBox1.Items.Add("Supplied Items:");
                foreach (var item in report.SupplyRequests)
                    listBox1.Items.Add($"Supply Request ID: {item.SupplyRequestId} - Quantity: {item.Items.Count}");

                listBox1.Items.Add("Released Items:");
                foreach (var item in report.ReleaseRequests)
                    listBox1.Items.Add($"Item: {item.ReleaseRequestId} - Quantity: {item.Items.Count}");

                listBox1.Items.Add("Transferred Items:");
                foreach (var item in report.TransferRequests)
                    listBox1.Items.Add($"Item: {item.RequestId} - Quantity: {item.Items.Count}");

                listBox1.Items.Add("Final Stock:");
                foreach (var item in report.CurrentStock)
                    listBox1.Items.Add($"Item: {item.ItemCode} - Quantity: {item.Quantity}");
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
