namespace LibManSys;

public class Member
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public double Fine { get; set; }
    public List<Book> RentedItems { get; private set; }

    public Member(int id, string name, string address, string phone, string email)
    {
        Id = id;
        Name = name;
        Address = address;
        Phone = phone;
        Email = email;
        Fine = 10.00;
        RentedItems = new List<Book>();
    }


    public void RentBook(Book book)
    {
        if (book == null)
        {
            Console.WriteLine("Book is not in the list.");
            return;
        }

        if (book.GetAvailability())
        {
            book.SetAvailable(false);
            RentedItems.Add(book);
            Console.WriteLine($"Member \"{Name}\" rented \"{book.Title}\".");
        }
        else
        {
            Console.WriteLine($"Book \"{book.Title}\" is currently unavailable.");
        }
    }

    public void ReturnBook(Book book)
    {
        if (RentedItems.Contains(book))
        {
            RentedItems.Remove(book);
            book.SetAvailable(true);
            Console.WriteLine($"Member \"{Name}\" returned \"{book.Title}\".");
        }
        else
        {
            Console.WriteLine($"The book \"{book.Title}\" was not rented by \"{Name}\".");
        }
    }
}
