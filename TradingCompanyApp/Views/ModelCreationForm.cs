using Microsoft.EntityFrameworkCore;
using StaticControls;
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
using TradingCompanyApp.Services;

namespace TradingCompanyApp.Views
{
    public partial class ModelCreationForm : Form
    {
        ComboBox measuringUnit;
        string objType;
        ApplicationDbContext context;
        bool isChanged = false; 
        TextBox textBox4; 
        ComboBox comboBox;
        public ModelCreationForm(string _type)
        {
            InitializeComponent();
            groupBox1.Text = _type;
            button1.Text = $"Create {_type}";
            objType = _type;

            textBox4 = new TextBox();
            textBox4.PlaceholderText = "Enter Full Name";
            textBox4.Location = new Point(textBox3.Location.X, textBox3.Location.Y + 50);
            textBox4.Size = textBox3.Size;
            textBox4.Anchor = textBox3.Anchor;
            context = new ApplicationDbContext();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (!isChanged)
            {
                isChanged = true;
                switch (objType)
                {
                    case "Warehouse":
                        groupBox1.Controls.Clear();
                        groupBox1.Controls.Add(button1);
                        WarehouseCreationForm warehouseForm = new WarehouseCreationForm();
                        ComboBox managerList = (ComboBox) warehouseForm.Controls.Find("comboBox1", true).First();
                        managerList.DataSource = EmployeeService.ViewEmployees();
                        managerList.ValueMember = "UserId";
                        managerList.DisplayMember = "FullName";
                        groupBox1.Controls.Add(warehouseForm);
                        break;
                    case "Product":
                        textBox1.PlaceholderText = "Enter Item Code";
                        textBox2.PlaceholderText = "Enter Item Name";
                        groupBox1.Controls.Remove(textBox3);
                        measuringUnit = new System.Windows.Forms.ComboBox();
                        measuringUnit.DropDownStyle = ComboBoxStyle.DropDownList;
                        measuringUnit.Items.AddRange(Enum.GetNames(typeof(MeasurementUnit)));
                        measuringUnit.Location = textBox3.Location;
                        groupBox1.Controls.Add(measuringUnit);
                        break;
                    case "User":
                        textBox1.PlaceholderText = "Enter Username";
                        textBox2.PlaceholderText = "Enter Email";
                        textBox3.PlaceholderText = "Enter Password";
                        comboBox = new ComboBox();
                        comboBox.Location = new Point(textBox4.Location.X + 50, textBox4.Location.Y + 25);
                        comboBox.Items.AddRange(["MANAGER", "ADMIN"]);
                        comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                        groupBox1.Controls.AddRange([textBox4, comboBox]);
                        break;
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                switch (objType)
                {
                    case "Warehouse":
                        Warehouse warehouse = new Warehouse
                        {
                            Name = textBox1.Text,
                            Address = textBox2.Text,
                            ManagerId = int.Parse(textBox3.Text)
                        };
                        WarehouseService.AddWarehouse(warehouse);
                        break;
                    case "Product":
                        Item item = new Item
                        {
                            ItemCode = textBox1.Text,
                            Name = textBox2.Text,
                            Unit = Enum.Parse<MeasurementUnit>(measuringUnit.SelectedItem.ToString())
                        };
                        context.Items.Add(item);
                        break;
                    case "User":
                        Employee emp = new Employee
                        {
                            Username = textBox1.Text,
                            Email = textBox2.Text,
                            Password = textBox3.Text,
                            FullName = textBox4.Text,
                            Role = comboBox.SelectedItem is not null ?
                                Enum.Parse<Role>(comboBox.SelectedItem.ToString()) : Role.MANAGER
                        };
                        EmployeeService.AddEmployee(emp);

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
