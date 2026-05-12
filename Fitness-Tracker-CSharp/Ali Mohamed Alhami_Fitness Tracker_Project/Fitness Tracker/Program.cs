using System;
using System.Windows.Forms;

namespace Fitness_Tracker
{
    //This is the  Entry point of the application and  Loads saved user data and opens the login form.
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FitnessTrackerManager.LoadData();
            // This code load the  persisted user data from the file before displaying any forms.
            Application.Run(new frmLogin());
        }
    }
}