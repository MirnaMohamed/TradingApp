using System.Windows.Forms;
using TradingCompanyApp.Models;
using TradingCompanyApp.Views;

namespace TradingCompanyApp
{
    public partial class LoginForm : Form
    {
        private ApplicationDbContext _context;
        public LoginForm()
        {
            InitializeComponent();
            _context = new ApplicationDbContext();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var x = _context.Users.ToList();
            User? user = _context.Users.ToList()
                .FirstOrDefault(u => u.Username == textBox1.Text || u.Email == textBox1.Text);
            if (user is { })
            {
                if (textBox2.Text == user?.Password)
                {
                    ApplicationDbContext.ActiveUser = user;
                    HomeForm form = new HomeForm();
                    form.Location = this.Location;
                    form.Opacity = 0;
                    form.Show();
                    this.Hide();
                    System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                    timer.Interval = 30;
                    timer.Tick += (s, e) =>
                    {
                        if (form.Opacity >= 1)
                            timer.Stop();
                        else
                            form.Opacity += 0.05;
                    };
                    timer.Start();
                    form.FormClosed += (_, _) => this.Close();
                }
                else
                {
                    MessageBox.Show("Incorrect Password");
                }
            }
            else
            {
                MessageBox.Show("Username or email does't exist.");
            }
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            RegisterForm form = new RegisterForm();
            SwitchForm(form, this);
            
        }
        public static void SwitchForm(Form newForm, Form oldForm)
        {
            newForm.Location = oldForm.Location;
            newForm.Opacity = 0;
            newForm.Show();
            oldForm.Hide();
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 15;
            timer.Tick += (s, e) =>
            {
                if (newForm.Opacity >= 1)
                    timer.Stop();
                else
                    newForm.Opacity += 0.05;
            };
            timer.Start();
            newForm.FormClosed += (_, _) => oldForm.Close();
        }
    }
}
