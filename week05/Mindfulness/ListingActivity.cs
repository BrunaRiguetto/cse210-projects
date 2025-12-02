using System;
using System.Collections.Generic;

namespace MindfulnessProgram
{
    public class ListingActivity : Activity
    {
        private List<string> _prompts;
        private Random _random;

        public ListingActivity() :
            base("Listing Activity",
                 "This activity helps you reflect on good things by listing as many items as you can.")
        {
            _random = new Random();
            _prompts = new List<string>()
            {
                "Who are people that you appreciate?",
                "What are your personal strengths?",
                "Who have you helped recently?",
                "When have you felt peace this month?",
                "Who are your heroes?"
            };
        }

        protected override void RunActivity()
        {
            int duration = GetDuration();
            DateTime end = DateTime.Now.AddSeconds(duration);

            Console.WriteLine("\n--- Prompt ---");
            Console.WriteLine(GetRandomPrompt());
            Console.WriteLine();

            Console.WriteLine("You may begin listing items after the countdown:");
            ShowCountDown(5);

            int count = 0;

            while (DateTime.Now < end)
            {
                Console.Write("> ");
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    count++;
                }
            }

            Console.WriteLine($"\nYou listed {count} items.");
        }

        private string GetRandomPrompt() => _prompts[_random.Next(_prompts.Count)];
    }
}
