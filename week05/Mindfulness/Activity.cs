using System;
using System.Threading;

namespace MindfulnessProgram
{
    public abstract class Activity
    {
        private string _name;
        private string _description;
        private int _duration; // seconds

        protected Activity(string name, string description)
        {
            _name = name;
            _description = description;
        }

        public void Start()
        {
            DisplayStartingMessage();
            AskDuration();
            Console.WriteLine("\nGet ready...");
            ShowSpinner(3);
            RunActivity();
            DisplayEndingMessage();
        }

        protected abstract void RunActivity();

        protected void DisplayStartingMessage()
        {
            Console.Clear();
            Console.WriteLine($"=== {_name} ===\n");
            Console.WriteLine(_description);
            Console.WriteLine();
        }

        protected void DisplayEndingMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Well done!");
            ShowSpinner(2);
            Console.WriteLine($"\nYou have completed the {_name} for {_duration} seconds.");
            ShowSpinner(2);
            Console.WriteLine("\nPress Enter to return to the menu...");
            Console.ReadLine();
        }

        private void AskDuration()
        {
            int seconds = 0;
            while (true)
            {
                Console.Write("Enter the duration of the activity in seconds: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out seconds) && seconds > 0)
                {
                    _duration = seconds;
                    break;
                }
                Console.WriteLine("Please enter a valid positive integer.");
            }
        }

        protected int GetDuration() => _duration;

        protected void ShowSpinner(int seconds)
        {
            char[] sequence = new char[] { '|', '/', '-', '\\' };
            DateTime end = DateTime.Now.AddSeconds(seconds);
            int i = 0;

            while (DateTime.Now < end)
            {
                Console.Write(sequence[i % sequence.Length]);
                Thread.Sleep(250);
                Console.Write("\b \b");
                i++;
            }
        }

        protected void ShowCountDown(int seconds)
        {
            for (int i = seconds; i >= 1; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }
    }
}
