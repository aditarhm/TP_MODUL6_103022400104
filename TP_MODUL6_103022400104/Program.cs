using System;
using System.Diagnostics;

class SayaMusicTrack
{
    private int id;
    private int playCount;
    private string title;

    public SayaMusicTrack(string title)
    {
        Debug.Assert(title != null, "Title tidak boleh null");
        Debug.Assert(title.Length <= 100, "Title maksimal 100 karakter");

        if (title == null)
            throw new ArgumentNullException("Title tidak boleh null");

        if (title.Length > 100)
            throw new ArgumentException("Title maksimal 100 karakter");

        this.title = title;
        this.playCount = 0;

        Random rand = new Random();
        this.id = rand.Next(10000, 99999);
    }

    public void IncreasePlayCount(int count)
    {
        Debug.Assert(count <= 10000000, "Maksimal penambahan 10.000.000");

        if (count > 10000000)
            throw new ArgumentException("Maksimal penambahan 10.000.000");

        try
        {
            checked
            {
                playCount += count;
            }
        }
        catch (OverflowException)
        {
            Console.WriteLine("ERROR: Terjadi overflow pada playCount!");
        }
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
        try
        {
            SayaMusicTrack track = new SayaMusicTrack("Lagu Santai");

            track.IncreasePlayCount(1000);
            track.PrintTrackDetails();

            track.IncreasePlayCount(20000000);
        }
        catch (Exception ex)
        {
            Console.WriteLine("EXCEPTION: " + ex.Message);
        }

        try
        {
            SayaMusicTrack track2 = new SayaMusicTrack("Overflow Test");

            for (int i = 0; i < 100; i++)
            {
                track2.IncreasePlayCount(int.MaxValue);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("EXCEPTION LOOP: " + ex.Message);
        }
    }
}