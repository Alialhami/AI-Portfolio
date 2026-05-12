using System;
using System.Runtime.Serialization;

namespace Fitness_Tracker
{
    //  as you see the Weightlifting activity which stores number of sets, reps, and weight (kg).

    [Serializable]
    public class Weightlifting : Activity
    {
        public Weightlifting()
        {
            activityName = "Weightlifting";
            metrics["sets"] = 0.0;
            metrics["reps"] = 0.0;
            metrics["weight"] = 0.0;
        }

        protected Weightlifting(SerializationInfo info, StreamingContext context) : base(info, context) { }

        //  the Calorie calculation we used is based on total volume: sets * reps * weight * 0.1.
        public override int CalculateCalories()
        {
            double sets = metrics["sets"];
            double reps = metrics["reps"];
            double weight = metrics["weight"];
            double totalVolume = sets * reps * weight;
            return (int)(totalVolume * 0.1);
        }
    }
}