using System;

public class Resume
{
    public string _name;
    public List<Job> _jobs = new List<Job>();

    // Method to display the resume
    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");

        // Display each job in the resume (loop)
        foreach (Job job in _jobs)
        {
            job.Display();
        }
    }
}