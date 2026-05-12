using System;
using System.Runtime.Serialization;

namespace Fitness_Tracker
{
    //  This is the Running activity which stores distance (km), time (minutes) and average heart rate.
    [Serializable]
    public class Running : Activity
    {
        public Running()
        {
            // Set the activity name
            activityName = "Running";
            metrics["distance"] = 0;
            metrics["time"] = 0;
            metrics["avgHeartRate"] = 0;
        }

        // here we used the Serialization constructor which calls the base class constructor again.
        protected Running(SerializationInfo info, StreamingContext context) : base(info, context) { }

        // the Calorie formula using all three metrics: distance * 60 + time * 5 + avgHeartRate * 0.2.
        public override int CalculateCalories()
        {
            double distance = metrics["distance"];
            double time = metrics["time"];
            double hr = metrics["avgHeartRate"];
            return (int)((distance * 60) + (time * 5) + (hr * 0.2));
        }
    }
}