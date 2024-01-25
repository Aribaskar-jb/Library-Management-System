You are tasked with developing a Library Management System using C# that incorporates various object-oriented programming concepts. The system should manage books, authors, and library users.
Class and Objects:
Create a class named Book with the following attributes:
Title
Author
Book Number
Price
Implement methods to display book details and calculate the discounted price.
Create a class named Author with the following attributes:
Author Name
Author Bio
Implement methods to display author details.
Create a class named LibraryUser with the following attributes:
User ID
User Name
BooksIssued (list of books issued to the user)
Implement methods to display user details and the books issued to the user.
Inheritance:
Implement inheritance between Book and a new class EBook that represents electronic books. Add a new attribute Format to EBook (e.g., PDF, EPUB).
Create another class PrintedBook that also inherits from Book and add attributes like Weight and InStock to represent physical books.
Interfaces:
Define an interface named IBookOperations with methods like IssueBook() and ReturnBook(). Implement this interface in the LibraryUser class to handle book transactions.
Implement another interface named IDiscount with a method to calculate discounts. Implement this interface in the Book class.
Polymorphism:
Implement polymorphism by creating a method that takes an array of books (both regular and electronic) and prints the details for each book.
Demonstrate method overloading by creating multiple methods to issue and return books in the LibraryUser class.
 
Implement a polymorphic method that displays details for either a Book or an EBook.

![image](https://github.com/Aribaskar-jb/Library-Management-System/assets/85920362/d5d0af90-114b-4ab6-b55e-dd231a75df84)

