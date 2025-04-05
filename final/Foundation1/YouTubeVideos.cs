// Program 1: Abstraction (YouTube Videos)
// This program will:
    // Store multiple videos.
    // Allow adding comments to each video.
    // Display each videos details along with its comments.

using System;
using System.Collections.Generic;

// The Comment class represents individual comments on a video
class Comment
{
    // Private fields
    private string _commenterName;
    private string _text;

    // Constructor to initialize the comment
    public Comment(string commenterName, string text)
    {
        _commenterName = commenterName;
        _text = text;
    }

    // Method to display the comment as a string
    public override string ToString()
    {
        return $"{_commenterName}: {_text}";
    }
}

// The Video class represents a YouTube video and its associated comments
class Video
{
    // Private fields
    private string _title;
    private string _author;
    private int _lengthInSeconds;
    private List<Comment> _comments;

    // Constructor to initialize video details
    public Video(string title, string author, int lengthInSeconds)
    {
        _title = title;
        _author = author;
        _lengthInSeconds = lengthInSeconds;
        _comments = new List<Comment>();
    }

    // Method to add a comment to the video
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    // Method to display video information and comments
    public void DisplayVideoInfo()
    {
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length: {_lengthInSeconds} seconds");
        Console.WriteLine("Comments:");
        foreach (var comment in _comments)
        {
            Console.WriteLine($"- {comment}");
        }
        Console.WriteLine();
    }
}

// The main program to test the Video and Comment classes
class Program
{
    static void Main()
    {
        // Create a list to hold videos
        List<Video> videos = new List<Video>();

        // Create a video and add comments to it
        Video video1 = new Video("C# Tutorial", "John Doe", 600);
        video1.AddComment(new Comment("Alice", "Great tutorial!"));
        video1.AddComment(new Comment("Bob", "Very helpful, thanks!"));
        videos.Add(video1);

        // Create another video and add comments to it
        Video video2 = new Video("Understanding OOP", "Jane Smith", 900);
        video2.AddComment(new Comment("Charlie", "Amazing explanation!"));
        videos.Add(video2);

        // Display information for each video
        foreach (var video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}
