using System;
using System.Runtime.Serialization;

namespace Fitness_Tracker
{
    //  this provides the Swimming activity which  stores the number of laps, time (minutes) and average heart rate.
    [Serializable]
    public class Swimming : Activity
    {
        // here we set the activity name.
        public Swimming()
        {
            activityName = "Swimming";
            metrics["laps"] = 0;
            metrics["time"] = 0;
            metrics["avgHeartRate"] = 0;
        }


        // Here we used the Serialization constructor  to calls the base class constructor as usual.
        protected Swimming(SerializationInfo info, StreamingContext context) : base(info, context) { }

        // here the Calorie formula using all three metrics: laps * 15 + time * 7 + avgHeartRate * 0.1.
        public override int CalculateCalories()
        {
            double laps = metrics["laps"];
            double time = metrics["time"];
            double hr = metrics["avgHeartRate"];
            return (int)((laps * 15) + (time * 7) + (hr * 0.1));
        }
    }
}