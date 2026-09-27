using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("How to Bake Sourdough Bread", "Chef Mia", 620);
        video1.AddComment(new Comment("Jordan", "This changed my bread game forever!"));
        video1.AddComment(new Comment("Priya", "Can I use whole wheat flour instead?"));
        video1.AddComment(new Comment("Sam", "The crust looks amazing."));
        video1.AddComment(new Comment("Alex", "Finally a recipe that actually works."));

        Video video2 = new Video("Beginner Guitar Lesson", "Marcus Strings", 745);
        video2.AddComment(new Comment("Taylor", "This helped me so much, thank you!"));
        video2.AddComment(new Comment("Devon", "Can you do a follow up on chords?"));
        video2.AddComment(new Comment("Riley", "Great pacing for beginners."));

        Video video3 = new Video("Building a PC in 2026", "TechWithJules", 1130);
        video3.AddComment(new Comment("Casey", "Which motherboard did you use?"));
        video3.AddComment(new Comment("Morgan", "Super clear instructions."));
        video3.AddComment(new Comment("Jamie", "This saved me from so many mistakes."));
        video3.AddComment(new Comment("Pat", "Can you review GPUs next?"));

        Video video4 = new Video("30 Minute Yoga Flow", "Calm With Nina", 1800);
        video4.AddComment(new Comment("Harper", "Perfect for my morning routine."));
        video4.AddComment(new Comment("Quinn", "My back feels so much better."));
        video4.AddComment(new Comment("Skyler", "Loved the music choice."));

        List<Video> videos = new List<Video>();
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);
        videos.Add(video4);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  - {comment.GetName()}: {comment.GetText()}");
            }

            Console.WriteLine();
        }
    }
}