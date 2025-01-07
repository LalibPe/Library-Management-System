using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using LibManSys;
using static System.Linq.Expressions.MemberAssignment;
using static LibManSys.Book;


public class Library
{
    private List<Book> Books { get; set; }
    private List<Member> Members { get; set; }
    private List<Rental> Rentals { get; set; }
    private int MemberIDCounter { get; set; }

    public Library()
    {
        Books = new List<Book>();
        Members = new List<Member>();
        Rentals = new List<Rental>();
        MemberIDCounter = 100;
    }


    public void AddBook(string title, string author, string serialNum)
    {
        Book newBook = new Book(title, author, serialNum);
        Books.Add(newBook);
        Console.WriteLine($"Book \"{title}\" added to the library.");
    }

    public void RemoveBook(string serialNum)
    {
        Book bookToRemove = Books.FirstOrDefault(b => b.SerialNum == serialNum);
        if (bookToRemove != null)
        {
            Books.Remove(bookToRemove);
            Console.WriteLine($"Book \"{bookToRemove.Title}\" removed from the library.");
        }
        else
        {
            Console.WriteLine($"No book found with Serial Number \"{serialNum}\".");
        }
    }

    public void DisplayBooks()
    {
        Console.WriteLine("--- All Books in the Library ---");
        foreach (var book in Books)
        {
            Console.WriteLine(
                $"ID: {book.SerialNum}, Title: \"{book.Title}\", Author: \"{book.Author}\", Available: {book.IsAvailable}");
        }
    }

    public void AddMember(string name, string address, string phone, string email)
    {
        Member newMember = new Member(MemberIDCounter++, name, address, phone, email);
        Members.Add(newMember);
        Console.WriteLine($"Member \"{name}\" added to the library with ID {newMember.Id}.");
    }

    public void RemoveMember(int memberId)
    {
        Member memberToRemove = Members.FirstOrDefault(m => m.Id == memberId);
        if (memberToRemove != null)
        {
            Members.Remove(memberToRemove);
            Console.WriteLine($"Member \"{memberToRemove.Name}\" removed from the library.");
        }
        else
        {
            Console.WriteLine($"No member found with ID \"{memberId}\".");
        }
    }

    public void DisplayMembers()
    {
        Console.WriteLine("--- All Members in the Library ---");
        foreach (var member in Members)
        {
            Console.WriteLine($"ID: {member.Id}, Name: \"{member.Name}\", Fine: {member.Fine}");
        }
    }


    public void RentBook(string bookTitle, int memberId)
    {
        var book = Books.FirstOrDefault(b => b.Title.Equals(bookTitle, StringComparison.OrdinalIgnoreCase));
        if (book == null)
        {
            Console.WriteLine($"Book \"{bookTitle}\" not found in the library.");
            return;
        }

        var member = Members.FirstOrDefault(m => m.Id == memberId);
        if (member == null)
        {
            Console.WriteLine($"Member with ID \"{memberId}\" not found.");
            return;
        }

        if (!book.GetAvailability())
        {
            Console.WriteLine($"The book \"{book.Title}\" is currently unavailable.");
            return;
        }

        member.RentBook(book);
        Rental rental = new Rental(book, member);
        Rentals.Add(rental);

        Console.WriteLine($"Book \"{book.Title}\" rented to member \"{member.Name}\".");
    }

    public void ReturnBook(string bookTitle, int memberId)
    {
        var book = Books.FirstOrDefault(b => b.Title.Equals(bookTitle, StringComparison.OrdinalIgnoreCase));
        if (book == null)
        {
            Console.WriteLine($"Book \"{bookTitle}\" not found in the library.");
            return;
        }

        var member = Members.FirstOrDefault(m => m.Id == memberId);
        if (member == null)
        {
            Console.WriteLine($"Member with ID \"{memberId}\" not found.");
            return;
        }

        member.ReturnBook(book);

        var rental = Rentals.FirstOrDefault(r => r.Book == book && r.Member == member);
        if (rental != null)
        {
            Rentals.Remove(rental);
        }

        Console.WriteLine($"The book \"{book.Title}\" has been returned by member \"{member.Name}\".");
    }

    public void CheckOverdueRentals()
    {
        Console.WriteLine("--- Overdue Rentals ---");
        bool foundOverdue = false;

        foreach (var rental in Rentals)
        {
            if (rental.IsOverdue())
            {
                Console.WriteLine(
                    $"Overdue: \"{rental.Book.Title}\" rented by {rental.Member.Name} (Due: {rental.DueDate.ToShortDateString()})");
                foundOverdue = true;
            }
        }

        if (!foundOverdue)
        {
            Console.WriteLine("No overdue rentals.");
        }
    }

    public void SaveMembers()
    {
        try
        {
            string filePath = "members.json";
            string jsonData = JsonSerializer.Serialize(Members, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, jsonData);
            Console.WriteLine("Members data saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving members: {ex.Message}");
        }
    }
    
    public void SaveBooks()
    {
        try
        {
            string filePath = "books.json";
            string jsonData = JsonSerializer.Serialize(Books, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, jsonData);
            Console.WriteLine("Books data saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving books: {ex.Message}");
        }
    }
    
    public void SaveRentals()
    {
        try
        {
            string filePath = "rentals.json";
            var rentalData = Rentals.Select(r => new
            {
                BookSerialNum = r.Book.SerialNum,
                MemberId = r.Member.Id
            });
            string jsonData = JsonSerializer.Serialize(rentalData, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, jsonData);
            Console.WriteLine("Rentals data saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving rentals: {ex.Message}");
        }
    }
    public void LoadBooks()
    {
        try
        {
            string filePath = "books.json";

            if (!File.Exists(filePath))
            {
                Console.WriteLine("No books data file found. Starting with an empty book list.");
                return;
            }

            string jsonData = File.ReadAllText(filePath);
            Books = JsonSerializer.Deserialize<List<Book>>(jsonData) ?? new List<Book>();
            Console.WriteLine("Books data loaded successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading books: {ex.Message}");
        }
    }
    public void LoadMembers()
    {
        try
        {
            string filePath = "members.json";

            if (!File.Exists(filePath))
            {
                Console.WriteLine("No members data file found. Starting with an empty member list.");
                return;
            }

            string jsonData = File.ReadAllText(filePath);
            Members = JsonSerializer.Deserialize<List<Member>>(jsonData) ?? new List<Member>();
            Console.WriteLine("Members data loaded successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading members: {ex.Message}");
        }
    }
    public void LoadRentals()
    {
        try
        {
            string filePath = "rentals.json";

            if (!File.Exists(filePath))
            {
                Console.WriteLine("No rentals data file found. Starting with an empty rental list.");
                return;
            }

            string jsonData = File.ReadAllText(filePath);
            var rentalData = JsonSerializer.Deserialize<List<dynamic>>(jsonData);

            Rentals = rentalData?.Select(r => new Rental(
                Books.FirstOrDefault(b => b.SerialNum == r.GetProperty("BookSerialNum").GetString()),
                Members.FirstOrDefault(m => m.Id == r.GetProperty("MemberId").GetInt32())
            )).ToList() ?? new List<Rental>();

            Console.WriteLine("Rentals data loaded successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading rentals: {ex.Message}");
        }
    }
    
    public void SaveAll()
    {
        SaveBooks();
        SaveMembers();
        SaveRentals();
    }
    
    public void LoadAll()
    {
        LoadBooks();
        LoadMembers();
        LoadRentals();
    }

}
  

    
    
    



