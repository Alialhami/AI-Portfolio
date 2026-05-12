using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Fitness_Tracker
{
    // This is the User Class that we have started with it.  it stores the account details. In addition, fitness goal and a list of activities, which Implements ISerializable for saving/loading data .
    
    [Serializable]
    public class User : ISerializable
    {
        // this is the Private fields  which encapsulates data and it can accesse only through properties.
        private string username;
        private string password;
        private int goalCalories;
        private List<Activity> activities;

        // this shows the Public properties which allows controlled access to the private fields.
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public int GoalCalories { get => goalCalories; set => goalCalories = value; }
        public List<Activity> Activities { get => activities; set => activities = value; }

        public User()
        {
            activities = new List<Activity>();
        }
        // this code  Initialize an empty activity list so it is never will be null.
        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
            this.goalCalories = 0;
            this.activities = new List<Activity>();
        }

        protected User(SerializationInfo info, StreamingContext context)
        {
            username = info.GetString("Username");
            password = info.GetString("Password");
            goalCalories = info.GetInt32("GoalCalories");
            activities = (List<Activity>)info.GetValue("Activities", typeof(List<Activity>));
        }

        // Here we used the Serialization method , which writes the object's data into the SerializationInfo for storage.
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Username", username);
            info.AddValue("Password", password);
            info.AddValue("GoalCalories", goalCalories);
            info.AddValue("Activities", activities, typeof(List<Activity>));
        }
        // This Calculates the total calories from all recorded activities using a foreach loop.
        public int GetTotalCaloriesBurned()
        {
            int total = 0;
            foreach (Activity act in activities)
            {
                total += act.CalculateCalories();
            }
            return total;
        }
        //This will  Returns true if the total calories burned meets or exceeds the set goal
        public bool IsGoalAchieved()
        {
            return GetTotalCaloriesBurned() >= goalCalories;
        }
    }
}