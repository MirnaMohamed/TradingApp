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

namespace TradingCompanyApp.Views
{
    public partial class RegisterForm : Form
    {
        ComboBox role;
        ApplicationDbContext _context;
        bool formUpdated = false;
        public RegisterForm()
        {
            InitializeComponent();
            _context = new ApplicationDbContext();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if(!formUpdated)
            {
                formUpdated = true;
                if (comboBox1.SelectedItem != null)
                {
                    if (comboBox1.SelectedItem.ToString() == "Employee")
                    {
                        EmployeeForm employeeForm = new EmployeeForm();
                        //employeeForm.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                        //employeeForm.Location = new Point(label1.Location.X, label1.Location.Y + 25);
                        ComboBox roleList = (ComboBox)employeeForm.Controls["comboBox1"];
                        roleList.DataSource = Enum.GetValues(typeof(Role));
                        roleList.DisplayMember = "Name";
                        groupBox1.Controls.Clear();
                        groupBox1.Controls.Add(employeeForm);
                        groupBox1.Text = "Employee";
                    }
                    else
                    {
                        groupBox1.Controls.Clear();
                        FillCustomerControl customerControl = new FillCustomerControl();
                        groupBox1.Controls.Add(customerControl);
                    }
                }
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "Employee")
            {
                EmployeeForm employeeForm = new EmployeeForm();
                ComboBox roleList = (ComboBox) employeeForm.Controls["comboBox1"];
                roleList.DataSource = Enum.GetValues(typeof(Role));
                roleList.DisplayMember = "Name";
                groupBox1.Controls.Clear();
                groupBox1.Controls.Add(employeeForm);
            }
            else
            {
                groupBox1.Controls.Clear();
                FillCustomerControl customerControl = new FillCustomerControl();
                groupBox1.Controls.Add(customerControl);
            }
            formUpdated = false;
            Invalidate();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex != -1)
            {
                string userType = comboBox1.SelectedItem.ToString();

                try
                {
                    User newUser;
                    switch (userType)
                    {
                        case "Employee":
                            ComboBox roleList = (ComboBox)groupBox1.Controls["employeeForm"].Controls["comboBox1"];
                            newUser = new Employee
                            {
                                Username = groupBox1.Controls["employeeForm"].Controls["textBox1"].Text,
                                Email = groupBox1.Controls["employeeForm"].Controls["textBox2"].Text,
                                Password = groupBox1.Controls["employeeForm"].Controls["textBox3"].Text,
                                FullName = groupBox1.Controls["employeeForm"].Controls["textBox4"].Text,
                                Role = Enum.Parse<Role>(roleList.SelectedItem.ToString())
                            };
                            break;
                        case "Supplier":
                            newUser = new Supplier
                            {
                                Username = groupBox1.Controls["FillCustomerControl"].Controls["textBox1"].Text,
                                Email = groupBox1.Controls["FillCustomerControl"].Controls["textBox2"].Text,
                                Password = groupBox1.Controls["FillCustomerControl"].Controls["textBox3"].Text,
                                SupplierName = groupBox1.Controls["FillCustomerControl"].Controls["textBox4"].Text,
                                PhoneNumber = groupBox1.Controls["FillCustomerControl"].Controls["textBox5"].Text,
                                FaxNumber = groupBox1.Controls["FillCustomerControl"].Controls["textBox6"].Text,
                                Website = groupBox1.Controls["FillCustomerControl"].Controls["textBox7"].Text

                                //MobileNumber = textBox6.Text,
                            };
                            break;
                        case "Customer":
                            newUser = new Customer
                            {
                                Username = groupBox1.Controls["FillCustomerControl"].Controls["textBox1"].Text,
                                Email = groupBox1.Controls["FillCustomerControl"].Controls["textBox2"].Text,
                                Password = groupBox1.Controls["FillCustomerControl"].Controls["textBox3"].Text,
                                CustomerName = groupBox1.Controls["FillCustomerControl"].Controls["textBox4"].Text,
                                PhoneNumber = groupBox1.Controls["FillCustomerControl"].Controls["textBox5"].Text,
                                FaxNumber = groupBox1.Controls["FillCustomerControl"].Controls["textBox6"].Text,
                                Website = groupBox1.Controls["FillCustomerControl"].Controls["textBox7"].Text
                            };
                            break;
                        default:
                            throw new InvalidEnumArgumentException("Please select a user type");
                            break;
                    }
                    _context.Users.Add(newUser);
                    ApplicationDbContext.ActiveUser = newUser;
                    await _context.SaveChangesAsync();
                    HomeForm form = new HomeForm();
                    LoginForm.SwitchForm(form, this);
                }
                catch(ArgumentException ae)
                {
                    MessageBox.Show(ae.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.InnerException.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select a user type");
                return;
            }
        }
    }
}
