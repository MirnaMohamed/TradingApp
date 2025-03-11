using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TradingCompanyApp.Models;
using TradingCompanyApp.Models.Enums;

namespace TradingCompanyApp.Views
{
    public partial class HomeForm : Form
    {
        ApplicationDbContext _context;
        User currentUser;

        TextBox name, address;
        public HomeForm()
        {
            InitializeComponent();
            _context = ApplicationDbContext.context;
            currentUser = _context.ActiveUser;
            welcomeLabel.Text = currentUser.Username;
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            if (currentUser is Employee emp)
            {
                toolStripMenuItem1.Text = "Warehouse";
                toolStripMenuItem2.Text = "Product";
                if (emp.Role == Role.ADMIN)
                {
                    menuItem1SubItem1.Text = "Create one";
                    menuItem1SubItem2.Text = "Edit a warehouse";
                    menuItem1SubItem3.Text = "View Warehouses";

                    menuItem2SubItem1.Text = "Create one";
                    menuItem2SubItem2.Text = "Edit a product";
                    menuItem2SubItem3.Text = "View Products";
                }
                else
                {

                }
            }
        }

        private void menuItem1SubItem1_Click(object sender, EventArgs e)
        {
            if (currentUser is Employee emp)
            {
                Warehouse warehouse = new Warehouse
                {
                    Name = "Warehouse 1",
                    Address = "Address 1"
                };
            }
        }
    }
}
