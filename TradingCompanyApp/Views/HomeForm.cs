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
using TradingCompanyApp.Models.Reports;
using TradingCompanyApp.Services;

namespace TradingCompanyApp.Views
{
    public partial class HomeForm : Form
    {
        User currentUser;
        bool isFormUpdated = false;
        object _lockObj;
        public HomeForm()
        {
            InitializeComponent();
            currentUser = ApplicationDbContext.ActiveUser;
            welcomeLabel.Text += currentUser.Username + ", what do you like to do ?";
            _lockObj = new object();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            lock(_lockObj)
            {
                if (!isFormUpdated)
                {
                    isFormUpdated = true;

                    //customize the menu for each user
                    if (currentUser is not Customer) //employee or supplier
                    {
                        if (currentUser is Employee emp)
                        {
                            if (emp.Role == Role.ADMIN) 
                            {
                                toolStripMenuItem2.Text = "Product";
                                warehouseSubItem1.Text = "Create";
                                menuItem2SubItem1.Text = "Create";
                                ToolStripMenuItem users = new ToolStripMenuItem();
                                users.Text = "User";
                                users.DropDownItems.Add("Create");
                                users.DropDownItems.Add("Edit");
                                users.DropDownItems.Add("View");
                                users.DropDownItems[2].Tag = "User";
                                menuStrip1.Items.Add(users);
                                users.DropDownItemClicked += Users_DropDownItemClicked;
                            }
                            else //if it's a manager
                            {
                                warehouseSubItem1.Text = "Make a Report";
                                warehouseSubItem3.Visible = false;
                            }
                            warehouseSubItem2.Text = "View";
                            warehouseSubItem2.Tag = "Warehouse";
                            menuItem2SubItem2.Text = "View";
                            menuItem2SubItem2.Tag = "Product";
                        }
                        else //if it's a supplier or customer
                        {


                            addSupplyRequestBtn.Text = "Add Supply Request";
                            addReleaseRequestBtn.Text = "Add Release Request";
                        }
                    }
                    else
                    {
                        addSupplyRequestBtn.Text = "Buy a Product";
                    }

                }
            }
        }

        private void Users_DropDownItemClicked(object? sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender!;
            isFormUpdated = false;
            switch (e.ClickedItem?.Text)
            {
                case "Create":
                    ViewDialogBox(item.Text);
                    break;
                case "View":
                    ViewList(e.ClickedItem?.Tag?.ToString()!);
                    break;
            }
        }

        private void toolStripMenuItem1_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            //_context.Warehouses.Load();
            //_context.Users.Load();
            switch (e.ClickedItem?.Text)
            {
                case "Create":
                    ViewDialogBox(item.Text);
                    break;
                case "View":
                    ViewList(e.ClickedItem.Tag.ToString());
                    break;
            //    case "Make a Report":
            //        if (currentUser.AccessibleWarehouses.Count == 0)
            //        {
            //            MessageBox.Show("You don't manage any warehouse.");
            //        }
            //        else if(currentUser.AccessibleWarehouses.Count == 1)
            //        {
            //            WarehouseReport report = WarehouseService
            //                .GetWarehouseReport(currentUser.AccessibleWarehouses.First().WarehouseId, null, null);
            //            ReportForm form = new ReportForm(report);
            //            form.ShowDialog();
            //        }
            //        else
            //        {
            //            WarehouseDetailsForm frm = new WarehouseDetailsForm(false, null);
            //        }
            //        break;
            }
        }
        private void ViewDialogBox(string type)
        {
            var frm = new ModelCreationForm(type);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Created");
            //    _context.SaveChangesAsync();
            }

        }

        private void ViewList(string menuItem)
        {
            if(menuItem == "Warehouse")
            {
                List<Warehouse> warehouses = WarehouseService.GetWarehouses();
            //    _context.WarehouseItem.Load();
                listView1.Items.Clear();
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

                    Label textLabel = new Label() { Left = 20, Top = 20, Text = "Select a Warehouse:", 
                                                    Size = new Size(300, 30) };
                    ComboBox warehouseList = new ComboBox();
                    warehouseList.Location = new Point(textLabel.Location.X +50, textLabel.Location.Y + 50);
                    warehouseList.DataSource = warehouses;
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
            //    else
            //    {
            //        var warehouse = _context.Warehouses.FirstOrDefault(w => w.ManagerId == currentUser.UserId);
            //        if(warehouse == null)
            //        {
            //            MessageBox.Show("You don't manage any warehouse");
            //        }
            //        else
            //        {
            //            listView1.Items.Add(new ListViewItem(warehouse.ToString()));
            //        }
            //    }
            }
            //else
            //{
            //    listView1.Items.Clear();
            //    List<Employee> employees = EmployeeService.ViewEmployees();
            //    foreach (Employee employee in employees)
            //        listView1.Items.Add(new ListViewItem(employee.ToString()));
            //}
        }
        private void AddSupplyRequest_Click(object sender, EventArgs e)
        {
            RequestsForm frm = new RequestsForm(RequestType.SUPPLY);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Supply Request added successfully");
            }
        }
        private void addReleaseRequest_Click(object sender, EventArgs e)
        {
            RequestsForm frm = new RequestsForm(RequestType.RELEASE);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Release Request added successfully");
            }
        }

        private void AddTransferRequest_Click(object sender, EventArgs e)
        {
            RequestsForm frm = new RequestsForm(RequestType.TRANSFER);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Transfer Request added successfully");
            }
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            LoginForm frm = new LoginForm();
            LoginForm.SwitchForm(frm, this);
        }

    }
}
