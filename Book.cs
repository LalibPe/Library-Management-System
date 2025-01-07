namespace LibManSys;

using System;
using System.Collections.Generic;

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string SerialNum { get; set; }
    public bool IsAvailable { get; private set; }

    public Book(string title, string author, string serialNum)
    {
        Title = title;
        Author = author;
        SerialNum = serialNum;
        IsAvailable = true;
    }
    
    public void SetAvailable(bool status)
    {
        IsAvailable = status;
    }
    
    public bool GetAvailability()
    {
        return IsAvailable;
    }
}
