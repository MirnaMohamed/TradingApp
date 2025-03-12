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
    public partial class ModelCreationForm : Form
    {
        string objType;
        ApplicationDbContext context;
        ComboBox measuringUnit;
        public ModelCreationForm(string _type)
        {
            InitializeComponent();
            groupBox1.Text = _type;
            button1.Text = $"Create {_type}";
            objType = _type;

            context = ApplicationDbContext.context;
            InitializeView();
        }

        private void InitializeView()
        {

            switch (objType)
            {
                case "Warehouse":
                    textBox1.PlaceholderText = "Enter Warehouse Name";
                    textBox2.PlaceholderText = "Enter Warehouse Address";
                    textBox3.PlaceholderText = "Enter Responsible Person ID";
                    break;
                case "Product":
                    textBox1.PlaceholderText = "Enter Item Code";
                    textBox2.PlaceholderText = "Enter Item Name";
                    groupBox1.Controls.Remove(textBox3);
                    measuringUnit = new ComboBox();
                    measuringUnit.DropDownStyle = ComboBoxStyle.DropDownList;
                    measuringUnit.Items.AddRange(Enum.GetNames(typeof(MeasurementUnit)));
                    measuringUnit.Location = textBox3.Location;
                    groupBox1.Controls.Add(measuringUnit);
                    break;
                case "Employee":
                    break;
            }

        }

        private void button1_Click(object sender, EventArgs e)
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
                    context.Warehouses.Add(warehouse);
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
                case "Employee":
                    break;
            }
            context.SaveChangesAsync();
        }
    }
}
