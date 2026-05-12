using System;
using System.Runtime.Serialization;

namespace Fitness_Tracker
{
    [Serializable]

    // This shows the Walking activity which as you see it stores steps, distance (km) and time (minutes).
    public class Walking : Activity
    {
        public Walking()
        {
            activityName = "Walking";
            //here we  set the activity name.
            //This code will  Initialize the three required metrics with keys and default values.
            
            metrics["steps"] = 0;
            metrics["distance"] = 0.0;
            metrics["time"] = 0;
        }

        // here we used the Serialization constructor which calls the base class constructor.
        protected Walking(SerializationInfo info, StreamingContext context) : base(info, context) { }

        // this is the Calorie formula using all three metrics: steps * 0.04 + distance * 50 + time * 3.5.
        public override int CalculateCalories()
        {
            double steps = metrics["steps"];
            double distance = metrics["distance"];
            double time = metrics["time"];
            return (int)((steps * 0.04) + (distance * 50) + (time * 3.5));
        }
    }
}