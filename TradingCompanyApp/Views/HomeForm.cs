using Microsoft.EntityFrameworkCore;
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
using TradingCompanyApp.Services;

namespace TradingCompanyApp.Views
{
    public partial class HomeForm : Form
    {
        ApplicationDbContext _context;
        User currentUser;
        bool isFormUpdated = false;
        public HomeForm()
        {
            InitializeComponent();
            _context = ApplicationDbContext.context;
            currentUser = _context.ActiveUser;
            welcomeLabel.Text += currentUser.Username + ", what do you like to do ?";
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (!isFormUpdated)
            {
                isFormUpdated = true;
                if (currentUser is not Customer)
                {
                    toolStripMenuItem2.Text = "Product";
                    if (currentUser is Employee emp)
                    {
                        if (emp.Role == Role.ADMIN)
                        {
                            menuItem1SubItem1.Text = "Create";
                            menuItem2SubItem1.Text = "Create";
                            ToolStripMenuItem users = new ToolStripMenuItem();
                            users.Text = "User";
                            users.DropDownItems.Add("Create");
                            users.DropDownItems.Add("Edit");
                            users.DropDownItems.Add("View");
                            menuStrip1.Items.Add(users);
                            users.DropDownItemClicked += Users_DropDownItemClicked;
                        }
                        else
                        {
                            menuItem1SubItem1.Text = "Make a Report on the warehouse";
                            menuItem1SubItem3.Visible = false;
                        }
                        menuItem1SubItem2.Text = "View";
                        menuItem1SubItem2.Tag = "Warehouse";
                        menuItem2SubItem2.Text = "View";
                        menuItem2SubItem2.Tag = "Product";
                    }
                    else
                    {

                        button1.Text = "Add Supply Request";
                        button2.Text = "Add Release Request";
                    }
                }
                else
                {
                    button1.Text = "Buy a Product";
                }

            }

        }

        private void Users_DropDownItemClicked(object? sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            isFormUpdated = false;
            switch (e.ClickedItem.Text)
            {
                case "Create":
                    ViewDialogBox(item.Text);
                    break;
                case "View":
                    ViewList(e.ClickedItem.Tag.ToString());
                    break;
            }
        }

        private void toolStripMenuItem1_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            switch (e.ClickedItem.Text)
            {
                case "Create":
                    ViewDialogBox(item.Text);
                    break;
                case "View":
                    ViewList(e.ClickedItem.Tag.ToString());
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

        private void ViewList(string menuItem)
        {
            if(menuItem == "Warehouse")
            {
                _context.WarehouseItem.Load();
                listBox1.Items.Clear();
                if(currentUser is Employee emp && emp.Role == Role.ADMIN)
                {
                    Form dialog = new Form()
                    {
                        Width = 500,
                        Height = 350,
                        FormBorderStyle = FormBorderStyle.FixedDialog,
                        Text = "Select Warehouse",
                        StartPosition = FormStartPosition.CenterScreen
                    };

                    Label textLabel = new Label() { Left = 20, Top = 20, Text = "Enter Warehouse ID:" };
                    //TextBox inputBox = new TextBox() { Left = 20, Top = 50, Width = 240 };
                    ComboBox warehouseList = new ComboBox();
                    warehouseList.Location = new Point(textLabel.Location.X +50, textLabel.Location.Y + 50);
                    warehouseList.DataSource = _context.Warehouses.ToList();
                    warehouseList.ValueMember = "WarehouseId";
                    warehouseList.DisplayMember = "Name";
                    warehouseList.DropDownStyle = ComboBoxStyle.DropDownList;
                    Button okBtn = new Button() { Text = "OK", Left = 200, Width = 80, Top = 120, DialogResult = DialogResult.OK };

                    dialog.Controls.Add(textLabel);
                    dialog.Controls.Add(warehouseList);
                    dialog.Controls.Add(okBtn);
                    dialog.AcceptButton = okBtn;

                    int warehouseID = dialog.ShowDialog() == DialogResult.OK ? (int) warehouseList.SelectedValue: -1;
                    if(warehouseID != -1)
                    {
                        WarehouseDetailsForm frm = new WarehouseDetailsForm(true, warehouseID);
                        LoginForm.SwitchForm(frm, this);
                    }
                }
                else
                {
                    var warehouse = _context.Warehouses.FirstOrDefault(w => w.ManagerId == currentUser.UserId);
                    if(warehouse == null)
                    {
                        MessageBox.Show("You don't manage any warehouse");
                    }
                    else
                    {
                        listBox1.Items.Add(warehouse);
                    }
                }
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

        private void button4_Click(object sender, EventArgs e)
        {
            RequestsForm frm = new RequestsForm(RequestType.TRANSFER);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Transfer Request added/updated successfully");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoginForm frm = new LoginForm();
            LoginForm.SwitchForm(frm, this);
        }
    }
}
