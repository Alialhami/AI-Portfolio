using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Fitness_Tracker
{
    // This is the abstract base class for all the  fitness activities  which defines common structure and forces subclasses to implement CalculateCalories(). More over, it Implements ISerializable.
    [Serializable]
    public abstract class Activity : ISerializable
    {
        // This shows the Protected fields which is  accessible by subclasses (Walking, Swimming, etc.).
        protected string activityName;
        protected DateTime dateRecorded;
        protected Dictionary<string, double> metrics;

        // This is Public properties to access the protected fields.
        public string ActivityName { get => activityName; }
        public DateTime DateRecorded { get => dateRecorded; set => dateRecorded = value; }
        public Dictionary<string, double> Metrics { get => metrics; set => metrics = value; }

        public Activity()
        {
            metrics = new Dictionary<string, double>();
            dateRecorded = DateTime.Now;
        }

        public abstract int CalculateCalories();

        //  here we used the Serialization constructor whic is  used when loading from a file.  
        protected Activity(SerializationInfo info, StreamingContext context)
        {
            activityName = info.GetString("ActivityName");
            dateRecorded = info.GetDateTime("DateRecorded");
            metrics = (Dictionary<string, double>)info.GetValue("Metrics", typeof(Dictionary<string, double>));
        }

        // here we used the Serialization method which as you see it saves the activity’s data to a file.
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ActivityName", activityName);
            info.AddValue("DateRecorded", dateRecorded);
            info.AddValue("Metrics", metrics, typeof(Dictionary<string, double>));
        }
    }
}