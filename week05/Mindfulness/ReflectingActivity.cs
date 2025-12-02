using System;
using System.Collections.Generic;

namespace MindfulnessProgram
{
    public class ReflectingActivity : Activity
    {
        private List<string> _prompts;
        private List<string> _questions;
        private Random _random;

        public ReflectingActivity() :
            base("Reflecting Activity",
                 "This activity will help you reflect on times when you have shown strength and resilience.")
        {
            _random = new Random();
            _prompts = new List<string>()
            {
                "Think of a time when you stood up for someone else.",
                "Think of a time when you did something really difficult.",
                "Think of a time when you helped someone in need.",
                "Think of a time when you did something truly selfless."
            };

            _questions = new List<string>()
            {
                "Why was this meaningful to you?",
                "How did you get started?",
                "How did you feel afterward?",
                "What did you learn about yourself?",
                "How can this experience help you in the future?"
            };
        }

        protected override void RunActivity()
        {
            int duration = GetDuration();
            DateTime end = DateTime.Now.AddSeconds(duration);

            Console.WriteLine("\n--- Prompt ---");
            Console.WriteLine(GetRandomPrompt());
            Console.WriteLine("\nReflect on these questions:");

            while (DateTime.Now < end)
            {
                Console.WriteLine("> " + GetRandomQuestion());
                ShowSpinner(8);
                Console.WriteLine();
            }
        }

        private string GetRandomPrompt() => _prompts[_random.Next(_prompts.Count)];
        private string GetRandomQuestion() => _questions[_random.Next(_questions.Count)];
    }
}
