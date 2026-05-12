using System;
using System.Runtime.Serialization;

namespace Fitness_Tracker
{
    // This shows the Cycling activity which  stores distance (km), time (minutes) and average speed (km/h).
    [Serializable]
    public class Cycling : Activity
    {
        public Cycling()
        {
            activityName = "Cycling";
            metrics["distance"] = 0.0;
            metrics["time"] = 0.0;
            metrics["avgSpeed"] = 0.0;
        }

        protected Cycling(SerializationInfo info, StreamingContext context) : base(info, context) { }

        //the  Calorie formula: distance * 40 + time * 5 + avgSpeed * 3.
        public override int CalculateCalories()
        {
            double distance = metrics["distance"];
            double time = metrics["time"];
            double speed = metrics["avgSpeed"];
            return (int)((distance * 40) + (time * 5) + (speed * 3));
        }
    }
}