using System;
using System.Runtime.Serialization;

namespace Fitness_Tracker
{
    // here the  Yoga activity which stores time (minutes), intensity level (1-10) and base calories per minute.
    [Serializable]
    public class Yoga : Activity
    {
        public Yoga()
        {
            activityName = "Yoga";
            metrics["time"] = 0.0;
            metrics["intensityLevel"] = 0.0;
            metrics["caloriesBase"] = 0.0;
        }

        protected Yoga(SerializationInfo info, StreamingContext context) : base(info, context) { }

        // this is calculated by  Calories = time * baseCalories * (intensityLevel / 10).
        public override int CalculateCalories()
        {
            double time = metrics["time"];
            double intensity = metrics["intensityLevel"];
            double baseCals = metrics["caloriesBase"];
            return (int)(time * baseCals * (intensity / 10.0));
        }
    }
}