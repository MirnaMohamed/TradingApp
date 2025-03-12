using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TradingCompanyApp.Models.Reports;

namespace TradingCompanyApp.Views
{
    public partial class ReportForm : Form
    {
        internal ReportForm(WarehouseReport report)
        {
            InitializeComponent();
            ListView listBox1 = new ListView();
            listBox1.Size = this.ClientSize;
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
            this.Controls.Add(listBox1);
        }
    }
}
