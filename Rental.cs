using System;
using LibManSys;

public class Rental
{
    public Book Book { get; set; }
    public Member Member { get; set; }
    public DateTime RentalDate { get; set; }
    public DateTime DueDate { get; set; }

    public Rental(Book book, Member member)
    {
        Book = book;
        Member = member;
        RentalDate = DateTime.Now;
        DueDate = RentalDate.AddDays(14); 
    }

    public bool IsOverdue()
    {
        return DateTime.Now > DueDate;
    }
}