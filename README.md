# Library Management System

## Overview

The Library Management System is a console-based application written in C#. It provides core functionalities to manage books, members, and rentals in a library. The system does not use a database; instead, data is stored in JSON files for simplicity. This project is designed to be modular and easy to expand.

---

## Features

1. **Book Management**

   - Add, view, and remove books.
   - Track book availability (borrowed or available).

2. **Member Management**

   - Add, view, and remove members.
   - Track member details such as ID and name.

3. **Rental Management**

   - Borrow books (linking a book to a member).
   - Return books and update their availability.
   - Track rental history.

4. **Data Persistence**

   - All data (books, members, rentals) is stored in JSON files.
   - Separate save and load functionality for books, members, and rentals.

---

## Structure

The application consists of the following key components:

### Classes

1. **Book**

   - Properties: `SerialNum`, `Title`, `Author`, `IsAvailable`
   - Methods: `ToString()` for detailed book representation.

2. **Member**

   - Properties: `Id`, `Name`
   - Methods: `ToString()` for detailed member representation.

3. **Rental**

   - Properties: `Book`, `Member`
   - Methods: `ToString()` for rental information.

4. **Library**

   - Manages collections of books, members, and rentals.
   - Implements save and load functionality for each entity.

### JSON Data Files

- `books.json` for storing book data.
- `members.json` for storing member data.
- `rentals.json` for storing rental data.

---

## How to Use

1. **Run the Program**

   - Compile and execute the `Program.cs` file.

2. **Available Commands**

   - Add books, members, or rentals.
   - View all books, members, or current rentals.
   - Return books and update their status.

3. **Data Persistence**

   - The program automatically saves data to JSON files when modifications are made.
   - Data is loaded from the JSON files upon startup.

---

## Example Usage

### Adding a Book:

```plaintext
Enter the serial number: 123
Enter the title: Kiki Krosan
Enter the author: Kiki Miki
Book added successfully.
```

### Borrowing a Book:

```plaintext
Enter Member ID: 1
Enter Book Serial Number: 123
Book successfully borrowed by Member 1.
```

---

## Requirements

- .NET SDK (latest version)
- Visual Studio or any compatible C# editor

---

## Installation

1. Clone the repository:

   ```bash
   git clone <repository_url>
   ```

2. Open the solution in Visual Studio.

3. Build the solution to restore dependencies.

4. Run the application from `Program.cs`.

---

## Future Enhancements

- Implement overdue book tracking.
- Add penalties for late returns.
- Enhance the user interface with a graphical UI.
- Integrate a database for larger-scale use.

---

## Contributors

- Pehilj Bilal

---

##
  
