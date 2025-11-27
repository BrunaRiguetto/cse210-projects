using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create the list of videos
        List<Video> videos = new List<Video>();

        // ---------- Video 1 ----------
        Video v1 = new Video
        {
            Title = "How to Bake Bread",
            Author = "Cooking With Love",
            LengthSeconds = 540
        };
        v1.AddComment(new Comment("Ana", "Amazing recipe!"));
        v1.AddComment(new Comment("Carlos", "Mine didn't rise, help!"));
        v1.AddComment(new Comment("Julia", "Turned out perfect."));
        videos.Add(v1);

        // ---------- Video 2 ----------
        Video v2 = new Video
        {
            Title = "10 Tips for Productivity",
            Author = "SmartLife",
            LengthSeconds = 670
        };
        v2.AddComment(new Comment("Bruno", "Tip #3 changed my life!"));
        v2.AddComment(new Comment("Marina", "I needed this today."));
        v2.AddComment(new Comment("Leo", "Short and useful."));
        videos.Add(v2);

        // ---------- Video 3 ----------
        Video v3 = new Video
        {
            Title = "Travel Guide: Rome",
            Author = "WanderWorld",
            LengthSeconds = 845
        };
        v3.AddComment(new Comment("Paulo", "Rome is my dream!"));
        v3.AddComment(new Comment("Sara", "Great tips for families."));
        v3.AddComment(new Comment("Mia", "Saving this for my trip!"));
        videos.Add(v3);

        // ---------- Display ----------
        foreach (Video video in videos)
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthSeconds} seconds");
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (Comment c in video.GetComments())
            {
                Console.WriteLine($" - {c.CommenterName}: {c.Text}");
            }

            Console.WriteLine(); // blank line between videos
        }
    }
}
