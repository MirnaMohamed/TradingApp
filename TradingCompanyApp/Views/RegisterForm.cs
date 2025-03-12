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
        TextBox textBox4;
        TextBox textBox5;
        TextBox textBox6;
        TextBox textBox7;
        TextBox textBox8;
        ComboBox role;
        ApplicationDbContext _context;
        public RegisterForm()
        {
            InitializeComponent();
            _context = ApplicationDbContext.context;
            textBox4 = new TextBox();
            textBox4.Size = textBox3.Size;
            textBox4.PlaceholderText = "Enter your Full Name";
            textBox4.Location = new Point(textBox3.Location.X, textBox3.Location.Y + 100);
            textBox4.TextAlign = textBox3.TextAlign;
            textBox4.Anchor = textBox3.Anchor;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if(comboBox1.SelectedItem != null)
            {
                this.Controls.Add(textBox4);
                if (comboBox1.SelectedItem.ToString() == "Employee")
                {
                    this.Controls.Remove(textBox5);
                    this.Controls.Remove(textBox6);
                    this.Controls.Remove(textBox7);
                    this.Controls.Remove(textBox8);
                    this.Controls.Add(role);
                }
                else
                {
                    this.Controls.Remove(role);
                    this.Controls.Add(textBox5);
                    this.Controls.Add(textBox6);
                    this.Controls.Add(textBox7);
                    this.Controls.Add(textBox8);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "Employee")
            {
                role = new ComboBox();
                role.DropDownStyle = ComboBoxStyle.DropDownList;
                role.Items.AddRange(Enum.GetNames(typeof(Role)));
                role.Size = new Size(151, 28);
                role.Location = new Point(textBox4.Location.X + 50, textBox4.Location.Y + 50);
                
            }
            else
            {
                textBox5 = new TextBox();
                textBox5.Location = new Point(textBox4.Location.X, textBox4.Location.Y + 50);
                textBox5.PlaceholderText = "Enter your Phone Number";
                textBox6 = new TextBox();
                textBox6.Location = new Point(textBox5.Location.X, textBox5.Location.Y + 50);
                textBox6.PlaceholderText = "Enter your Mobile Number";
                textBox7 = new TextBox();
                textBox7.Location = new Point(textBox6.Location.X, textBox6.Location.Y + 50);
                textBox7.PlaceholderText = "Enter your Fax Number";
                textBox8 = new TextBox();
                textBox8.Location = new Point(textBox7.Location.X, textBox7.Location.Y + 50);
                textBox8.PlaceholderText = "Enter your Website";
                textBox5.Size = textBox6.Size = textBox7.Size = textBox8.Size = textBox4.Size;
                textBox5.TextAlign = textBox6.TextAlign = textBox7.TextAlign = textBox8.TextAlign = textBox4.TextAlign;
                textBox5.Anchor = textBox6.Anchor = textBox7.Anchor = textBox8.Anchor = textBox4.Anchor;
            }
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
                            newUser = new Employee
                            {
                                Username = textBox1.Text,
                                Email = textBox2.Text,
                                Password = textBox3.Text,
                                FullName = textBox4.Text,
                                Role = Enum.Parse<Role>(role.SelectedItem.ToString())
                            };
                            break;
                        case "Supplier":
                            newUser = new Supplier
                            {
                                Username = textBox1.Text,
                                Email = textBox2.Text,
                                Password = textBox3.Text,
                                SupplierName = textBox4.Text,
                                PhoneNumber = textBox5.Text,
                                MobileNumber = textBox6.Text,
                                FaxNumber = textBox7.Text,
                                Website = textBox8.Text
                            };
                            break;
                        case "Customer":
                            newUser = new Customer
                            {
                                Username = textBox1.Text,
                                Email = textBox2.Text,
                                Password = textBox3.Text,
                                CustomerName = textBox4.Text,
                                PhoneNumber = textBox5.Text,
                                MobileNumber = textBox6.Text,
                                FaxNumber = textBox7.Text,
                                Website = textBox8.Text
                            };
                            break;
                        default:
                            newUser = new User
                            {
                                Username = textBox1.Text,
                                Email = textBox2.Text,
                                Password = textBox3.Text
                            };
                            break;
                    }
                    _context.Users.Add(newUser);
                    _context.ActiveUser = newUser;
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
                    MessageBox.Show(ex.Message);
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
