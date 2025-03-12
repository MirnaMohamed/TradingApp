using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
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
            welcomeLabel.Text += currentUser.Username + ", what do you like to do ?";
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            if (currentUser is Employee emp)
            {
                toolStripMenuItem1.Text = "Warehouse";
                toolStripMenuItem2.Text = "Product";
                button1.Text = "Add/Update Supply Request";
                button2.Text = "Add/Update Release Request";
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
                    button1.Text = "Add/Update Supply Request";
                    button2.Text = "Add/Update Release Request";
                }
            }
            else if (currentUser is Supplier supp)
            {

            }
        }

        private void menuItem1SubItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            switch (e.ClickedItem.Text)
            {
                case "Create one":
                    ViewDialogBox(item.Text);
                    break;
            }
        }
        private void ViewDialogBox(string type)
        {
            var frm = new ModelCreationForm(type);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Created");
                _context.SaveChangesAsync();
            }
        }

        private void toolStripMenuItem2_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            switch (e.ClickedItem.Text)
            {
                case "Create one":
                    ViewDialogBox(item.Text);
                    break;
            }
        }

        private void ModifySupplyRequest(object sender, EventArgs e)
        {
            RequestsForm frm = new RequestsForm(RequestType.SUPPLY);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Supply Request added/updated successfully");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RequestsForm frm = new RequestsForm(RequestType.RELEASE);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Release Request added/updated successfully");
            }
        }
    }
}
