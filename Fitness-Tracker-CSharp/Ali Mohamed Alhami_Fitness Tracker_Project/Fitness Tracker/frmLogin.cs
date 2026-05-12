using System;
using System.Windows.Forms;

namespace Fitness_Tracker
{
    // This show  Login form  which  allows the existing users to log in or navigate to the registration form.
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        // This handles the Login button click.Also it  validates credentials via FitnessTrackerManager.
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (FitnessTrackerManager.Login(username, password))
            {
                frmMain mainForm = new frmMain();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                lblMessage.Text = "Invalid username or password.";
            }
        }

        // This opens the registration form as a modal dialog.
        private void btnRegister_Click(object sender, EventArgs e)
        {
            frmRegister regForm = new frmRegister();
            regForm.ShowDialog();
        }

        private void lblMessage_Click(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}