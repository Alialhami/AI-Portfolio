using System;
using System.Windows.Forms;

namespace Fitness_Tracker
{
    // This is the  Registration form which allows new users to create an account with validation, that is it.
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }

        // This as you see it handles the Register button click. Checks password match and calls the manager to register.
        private void btnRegister_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text;
            string pass = txtPassword.Text;
            string confirm = txtConfirm.Text;

            if (pass != confirm)
            {
                lblError.Text = "Passwords do not match.";
                return;
            }

            string errorMsg;
            if (FitnessTrackerManager.RegisterUser(user, pass, out errorMsg))
            {
                MessageBox.Show("Registration successful! You can now log in.", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                lblError.Text = errorMsg;
            }
        }

        // this Closes the registration form without registering.
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}