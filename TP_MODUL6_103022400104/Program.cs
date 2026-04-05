using System;
using System.Diagnostics;

class SayaMusicTrack
{
    private int id;
    private int playCount;
    private string title;

    public SayaMusicTrack(string title)
    {

        this.title = title;
        this.playCount = 0;

        Random rand = new Random();
        this.id = rand.Next(10000, 99999);
    }

    public void IncreasePlayCount(int count)

            {
                playCount += count;
            }
       

    public void PrintTrackDetails()
    {
        Console.WriteLine("=== Track Details ===");
        Console.WriteLine("ID        : " + id);
        Console.WriteLine("Title     : " + title);
        Console.WriteLine("PlayCount : " + playCount);
    }
}

class Program
{
    static void Main(string[] args)
    {
        SayaMusicTrack track = new SayaMusicTrack("Lagu Favorit");

        track.IncreasePlayCount(5);
        track.PrintTrackDetails();

        track.IncreasePlayCount(20000000);
    }
        
}
            