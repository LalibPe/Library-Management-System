using System;

class Program
{
    static void Main()
    {
        Library library = new Library();
        library.LoadAll();

        while (true)
        {
            Console.WriteLine("\n--- Library Management System ---");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Remove Book");
            Console.WriteLine("3. Display Books");
            Console.WriteLine("4. Add Member");
            Console.WriteLine("5. Remove Member");
            Console.WriteLine("6. Display Members");
            Console.WriteLine("7. Rent Book");
            Console.WriteLine("8. Return Book");
            Console.WriteLine("9. Check Overdue Rentals");
            Console.WriteLine("10. Save Data");
            Console.WriteLine("11. Exit");
            Console.Write("Enter your choice: ");
            
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    AddBook(library);
                    break;
                case "2":
                    RemoveBook(library);
                    break;
                case "3":
                    library.DisplayBooks();
                    break;
                case "4":
                    AddMember(library);
                    break;
                case "5":
                    RemoveMember(library);
                    break;
                case "6":
                    library.DisplayMembers();
                    break;
                case "7":
                    RentBook(library);
                    break;
                case "8":
                    ReturnBook(library);
                    break;
                case "9":
                    library.CheckOverdueRentals();
                    break;
                case "10":
                    library.SaveAll();
                    break;
                case "11":
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
    
    static void AddBook(Library library)
    {
        Console.Write("Enter book title: ");
        string title = Console.ReadLine();
        Console.Write("Enter book author: ");
        string author = Console.ReadLine();
        Console.Write("Enter book serial number: ");
        string serialNum = Console.ReadLine();

        library.AddBook(title, author, serialNum);
    }

    static void RemoveBook(Library library)
    {
        Console.Write("Enter book serial number: ");
        string serialNum = Console.ReadLine();

        library.RemoveBook(serialNum);
    }

    static void AddMember(Library library)
    {
        Console.Write("Enter member name: ");
        string name = Console.ReadLine();
        Console.Write("Enter member address: ");
        string address = Console.ReadLine();
        Console.Write("Enter member phone: ");
        string phone = Console.ReadLine();
        Console.Write("Enter member email: ");
        string email = Console.ReadLine();

        library.AddMember(name, address, phone, email);
    }

    static void RemoveMember(Library library)
    {
        Console.Write("Enter member ID: ");
        if (int.TryParse(Console.ReadLine(), out int memberId))
        {
            library.RemoveMember(memberId);
        }
        else
        {
            Console.WriteLine("Invalid member ID.");
        }
    }

    static void RentBook(Library library)
    {
        Console.Write("Enter book title: ");
        string bookTitle = Console.ReadLine();
        Console.Write("Enter member ID: ");
        if (int.TryParse(Console.ReadLine(), out int memberId))
        {
            library.RentBook(bookTitle, memberId);
        }
        else
        {
            Console.WriteLine("Invalid member ID.");
        }
    }

    static void ReturnBook(Library library)
    {
        Console.Write("Enter book title: ");
        string bookTitle = Console.ReadLine();
        Console.Write("Enter member ID: ");
        if (int.TryParse(Console.ReadLine(), out int memberId))
        {
            library.ReturnBook(bookTitle, memberId);
        }
        else
        {
            Console.WriteLine("Invalid member ID.");
        }
    }
}
