// Program 1: Abstraction (YouTube Videos)
// This program will:
    // Store multiple videos.
    // Allow adding comments to each video.
    // Display each videos details along with its comments.

using System;
using System.Collections.Generic;

class Comment
{
    public string CommenterName { get; private set; }
    public string Text { get; private set; }

    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }

    public override string ToString()
    {
        return $"{CommenterName}: {Text}";
    }
}

class Video
{
    public string Title { get; private set; }
    public string Author { get; private set; }
    public int LengthInSeconds { get; private set; }
    private List<Comment> comments;

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        LengthInSeconds = length;
        comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public void DisplayVideoInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {LengthInSeconds} seconds");
        Console.WriteLine("Comments:");
        foreach (var comment in comments)
        {
            Console.WriteLine($"- {comment}");
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("C# Tutorial", "John Doe", 600);
        video1.AddComment(new Comment("Alice", "Great tutorial!"));
        video1.AddComment(new Comment("Bob", "Very helpful, thanks!"));
        videos.Add(video1);

        Video video2 = new Video("Understanding OOP", "Jane Smith", 900);
        video2.AddComment(new Comment("Charlie", "Amazing explanation!"));
        videos.Add(video2);

        foreach (var video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}