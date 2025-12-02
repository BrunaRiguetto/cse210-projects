using System;

namespace MindfulnessProgram
{
    public class BreathingActivity : Activity
    {
        public BreathingActivity() :
            base("Breathing Activity",
                 "This activity will help you relax by guiding you to breathe in and out slowly.")
        {
        }

        protected override void RunActivity()
        {
            int duration = GetDuration();
            DateTime end = DateTime.Now.AddSeconds(duration);

            int inhaleSeconds = 4;
            int exhaleSeconds = 6;

            while (DateTime.Now < end)
            {
                Console.WriteLine("\nBreathe in...");
                ShowCountDown(inhaleSeconds);
                if (DateTime.Now >= end) break;

                Console.WriteLine("\nBreathe out...");
                ShowCountDown(exhaleSeconds);
            }
        }
    }
}
