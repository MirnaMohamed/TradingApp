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
using TradingCompanyApp.Services;

namespace TradingCompanyApp.Views
{
    public partial class ListViewForm : Form
    {
        internal WarehouseReport warehouseReport;
        public ListViewForm(ref int? selectedId)
        {
            InitializeComponent();

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count == 1)
            {
                int id;
                
                if(int.TryParse(listView1.SelectedItems[0].Text.Substring(4, 2), out id))
                {
                    warehouseReport = WarehouseService.GetWarehouseReport(id, null, null);
                    DialogResult = DialogResult.OK;
                }
            }
        }
    }
}
