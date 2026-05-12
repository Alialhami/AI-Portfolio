using System;
using System.Windows.Forms;

namespace Fitness_Tracker
{
    //  This code shows Main form  which  displays after login. it  allows goal setting also activity recording, and progress tracking.
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            cmbActivity.Items.Add("Walking");
            cmbActivity.Items.Add("Swimming");
            cmbActivity.Items.Add("Running");
            cmbActivity.Items.Add("Cycling");
            cmbActivity.Items.Add("Weightlifting");
            cmbActivity.Items.Add("Yoga");
            cmbActivity.SelectedIndex = 0;

            UpdateMetricLabels();
        }

        // When the user selects a different activity, it update the metric labels accordingly.
        private void cmbActivity_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateMetricLabels();
        }

        // This changes the metric labels (e.g., Steps, Distance, Time) based on the selected activity using a switch statement.
        private void UpdateMetricLabels()
        {
            if (cmbActivity.SelectedItem == null) return;

            string selected = cmbActivity.SelectedItem.ToString();
            switch (selected)
            {
                case "Walking":
                    lblMetric1.Text = "Steps:";
                    lblMetric2.Text = "Distance (km):";
                    lblMetric3.Text = "Time (minutes):";
                    break;
                case "Swimming":
                    lblMetric1.Text = "Laps:";
                    lblMetric2.Text = "Time (minutes):";
                    lblMetric3.Text = "Avg Heart Rate:";
                    break;
                case "Running":
                    lblMetric1.Text = "Distance (km):";
                    lblMetric2.Text = "Time (minutes):";
                    lblMetric3.Text = "Avg Heart Rate:";
                    break;
                case "Cycling":
                    lblMetric1.Text = "Distance (km):";
                    lblMetric2.Text = "Time (minutes):";
                    lblMetric3.Text = "Avg Speed (km/h):";
                    break;
                case "Weightlifting":
                    lblMetric1.Text = "Sets:";
                    lblMetric2.Text = "Reps:";
                    lblMetric3.Text = "Weight (kg):";
                    break;
                case "Yoga":
                    lblMetric1.Text = "Time (minutes):";
                    lblMetric2.Text = "Intensity (1-10):";
                    lblMetric3.Text = "Base Calories:";
                    break;
            }
        }
        // this records a new activity: reads metric values and  creates the appropriate Activity object, calculates calories, saves data, and updates the display.
        private void btnRecord_Click(object sender, EventArgs e)
        {
            // this Convert the three text inputs to numbers  and  throws FormatException if invalid.
            if (FitnessTrackerManager.CurrentUser == null)
            {
                MessageBox.Show("No user logged in.");
                return;
            }

            // This code uses try-catch to handle non-numeric input gracefully.
            try
            {
                double val1 = double.Parse(txtMetric1.Text);
                double val2 = double.Parse(txtMetric2.Text);
                double val3 = double.Parse(txtMetric3.Text);

                string selected = cmbActivity.SelectedItem.ToString();
                Activity newActivity = null;

                // This determine which concrete activity to instantiate based on the combo box selection.
                switch (selected)
                {
                    case "Walking": newActivity = new Walking(); break;
                    case "Swimming": newActivity = new Swimming(); break;
                    case "Running": newActivity = new Running(); break;
                    case "Cycling": newActivity = new Cycling(); break;
                    case "Weightlifting": newActivity = new Weightlifting(); break;
                    case "Yoga": newActivity = new Yoga(); break;
                }


                // this Assign the three metric values to the correct dictionary keys depending on activity type.
                if (newActivity != null)
                {
                    if (selected == "Walking")
                    {
                        newActivity.Metrics["steps"] = val1;
                        newActivity.Metrics["distance"] = val2;
                        newActivity.Metrics["time"] = val3;
                    }
                    else if (selected == "Swimming")
                    {
                        newActivity.Metrics["laps"] = val1;
                        newActivity.Metrics["time"] = val2;
                        newActivity.Metrics["avgHeartRate"] = val3;
                    }
                    else if (selected == "Running")
                    {
                        newActivity.Metrics["distance"] = val1;
                        newActivity.Metrics["time"] = val2;
                        newActivity.Metrics["avgHeartRate"] = val3;
                    }
                    else if (selected == "Cycling")
                    {
                        newActivity.Metrics["distance"] = val1;
                        newActivity.Metrics["time"] = val2;
                        newActivity.Metrics["avgSpeed"] = val3;
                    }
                    else if (selected == "Weightlifting")
                    {
                        newActivity.Metrics["sets"] = val1;
                        newActivity.Metrics["reps"] = val2;
                        newActivity.Metrics["weight"] = val3;
                    }
                    else if (selected == "Yoga")
                    {
                        newActivity.Metrics["time"] = val1;
                        newActivity.Metrics["intensityLevel"] = val2;
                        newActivity.Metrics["caloriesBase"] = val3;
                    }

                    newActivity.DateRecorded = DateTime.Now;
                    FitnessTrackerManager.CurrentUser.Activities.Add(newActivity);
                    FitnessTrackerManager.SaveData();

                    UpdateProgressDisplay();
                    ClearMetricInputs();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numbers for all metrics.", "Input Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // This code Sets the user's calorie goal from the textbox input.
        private void btnSetGoal_Click(object sender, EventArgs e)
        {
            //if (FitnessTrackerManager.CurrentUser == null) return;
            ////string goal = txtGoal.Text;
            //if (int.TryParse(txtGoal.Text, out int gl))
            //{
            //    FitnessTrackerManager.CurrentUser.GoalCalories = gl;
            //    FitnessTrackerManager.SaveData();
            //    UpdateProgressDisplay();
            //}
            //else
            //{
            //    MessageBox.Show("Please enter a valid integer for calorie goal.");
            //}
        }

        //  This Logs out the current user and returns to the login form.
        private void btnLogout_Click(object sender, EventArgs e)
        {
            FitnessTrackerManager.Logout();
            frmLogin loginForm = new frmLogin();
            loginForm.Show();
            this.Close();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // This Updates the total calories label and the goal achievement status.lso it  Uses ternary operator for concise messaging.
            UpdateProgressDisplay();
        }

        private void UpdateProgressDisplay()
        {
            User user = FitnessTrackerManager.CurrentUser;
            if (user != null)
            {
                int total = user.GetTotalCaloriesBurned();
                lblTotalCalories.Text = $"Total Calories Burned: {total}";
                lblGoalDisplay.Text = $"Current Goal: {user.GoalCalories} calories";

                if (user.GoalCalories > 0)
                {
                    lblGoalStatus.Text = user.IsGoalAchieved()
                        ? "Goal Achieved! Congratulations!"
                        : "Goal not yet reached. Keep going!";
                }
                else
                {
                    lblGoalStatus.Text = "Please set a calorie goal.";
                }
            }
        }

        // This clears the three metric input fields after a successful recording.
        private void ClearMetricInputs()
        {
            txtMetric1.Clear();
            txtMetric2.Clear();
            txtMetric3.Clear();
        }

        private void lblGoalDisplay_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnSetGoal_Click_1(object sender, EventArgs e)
        {
            if (FitnessTrackerManager.CurrentUser == null) return;
            //string goal = txtGoal.Text;
            if (int.TryParse(txtGoal.Text, out int gl))
            {
                FitnessTrackerManager.CurrentUser.GoalCalories = gl;
                FitnessTrackerManager.SaveData();
                UpdateProgressDisplay();
            }
            else
            {
                MessageBox.Show("Please enter a valid integer for calorie goal.");
            }
        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            frmLogin loginForm = new frmLogin();
            this.Hide();
            loginForm.Show();
        }
    }
}