using System;

namespace MindfulnessProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();

                Console.WriteLine("Menu Options:");
                Console.WriteLine(" 1. Start breathing activity");
                Console.WriteLine(" 2. Start reflecting activity");
                Console.WriteLine(" 3. Start listing activity");
                Console.WriteLine(" 4. Quit");
                Console.Write("Select a choice from the menu: ");

                string choice = Console.ReadLine()?.Trim();

                switch (choice)
                {
                    case "1":
                        new BreathingActivity().Start();
                        break;

                    case "2":
                        new ReflectingActivity().Start();
                        break;

                    case "3":
                        new ListingActivity().Start();
                        break;

                    case "4":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("\nInvalid choice. Press Enter to continue...");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
