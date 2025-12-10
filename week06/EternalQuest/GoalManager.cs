using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void Start()
    {
        int choice = 0;

        while (choice != 6)
        {
            Console.WriteLine("\n--- Eternal Quest ---");
            Console.WriteLine($"Your score: {_score}");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Choose an option: ");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: CreateGoal(); break;
                case 2: ListGoalDetails(); break;
                case 3: SaveGoals(); break;
                case 4: LoadGoals(); break;
                case 5: RecordEvent(); break;
            }
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("\nWhat type of goal do you want to create?");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Select: ");

        int type = int.Parse(Console.ReadLine());

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Description: ");
        string desc = Console.ReadLine();

        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        if (type == 1)
        {
            _goals.Add(new SimpleGoal(name, desc, points));
        }
        else if (type == 2)
        {
            _goals.Add(new EternalGoal(name, desc, points));
        }
        else if (type == 3)
        {
            Console.Write("Target times: ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("Bonus points: ");
            int bonus = int.Parse(Console.ReadLine());

            _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
        }

        Console.WriteLine("Goal created!");
    }

    private void ListGoalDetails()
    {
        Console.WriteLine("\n--- Goals ---");

        int index = 1;
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{index}. {goal.GetDetailsString()}");
            index++;
        }
    }

    private void RecordEvent()
    {
        Console.WriteLine("\nWhich goal did you accomplish?");
        ListGoalDetails();

        Console.Write("Select goal number: ");
        int choice = int.Parse(Console.ReadLine()) - 1;

        if (choice >= 0 && choice < _goals.Count)
        {
            int earned = _goals[choice].RecordEvent();
            _score += earned;
            Console.WriteLine($"You earned {earned} points! New score: {_score}");
        }
    }

    private void SaveGoals()
    {
        Console.Write("File name: ");
        string file = Console.ReadLine();

        using (StreamWriter output = new StreamWriter(file))
        {
            output.WriteLine(_score);

            foreach (Goal g in _goals)
            {
                output.WriteLine(g.GetStringRepresentation());
            }
        }

        Console.WriteLine("Saved!");
    }

    private void LoadGoals()
    {
        Console.Write("File name: ");
        string file = Console.ReadLine();

        string[] lines = File.ReadAllLines(file);
        _score = int.Parse(lines[0]);

        _goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(":");
            string type = parts[0];
            string data = parts[1];

            string[] values = data.Split(",");

            if (type == "SimpleGoal")
            {
                SimpleGoal g = new SimpleGoal(values[0], values[1], int.Parse(values[2]));
                g.SetComplete(bool.Parse(values[3]));
                _goals.Add(g);
            }
            else if (type == "EternalGoal")
            {
                _goals.Add(new EternalGoal(values[0], values[1], int.Parse(values[2])));
            }
            else if (type == "ChecklistGoal")
            {
                ChecklistGoal g = new ChecklistGoal(
                    values[0], values[1], int.Parse(values[2]),
                    int.Parse(values[3]), int.Parse(values[5])
                );
                g.SetAmountCompleted(int.Parse(values[4]));
                _goals.Add(g);
            }
        }

        Console.WriteLine("Loaded!");
    }
}
