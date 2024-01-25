using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    internal class Library
    {
        private List<Book> books = new List<Book>();

        public void AddingNewBook(Book book)
        {
            this.books.Add(book);
        }

        public List<Book> GetBooks()
        {
            return books;
        }
    }

    class Author
    {
        private string authorName;
        private string authorBio;
        public Author(string authorName, string authorBio)
        {
            this.authorName = authorName;
            this.authorBio = authorBio;
        }

        public void DisplayAuthor()
        {
            Console.WriteLine(this.authorName);
            Console.WriteLine(this.authorBio);
        }

    }
    interface IDiscount
    {
        public double CalDiscountedPrice();
    }

    interface ShowBookInfo
    {
        public void PrintInfo() { }
    }
    class Book : Library, IDiscount,ShowBookInfo
    {
        private string bookTitle;
        private Author author;
        private int bookId;
        private double price;
        private int numberOfCopies;
        public Book(string bookTitle, Author author, int bookId, double price, int numberOfCopies)
        {
            this.bookTitle = bookTitle;
            this.author = author;
            this.bookId = bookId;
            this.price = price;
            this.numberOfCopies = numberOfCopies;
            base.AddingNewBook(this);
        }

        public string DisplayTitle()
        {
            return this.bookTitle;
        }

        public int GetBookId()
        {
            return this.bookId;
        }
        public void UpdateCopies(int Copies)
        {
            /*return this.numberOfCopies;*/
            if (Copies > 0)
            {
                this.numberOfCopies = numberOfCopies + Copies;
            }
            if (Copies < 0)
            {
                this.numberOfCopies = numberOfCopies - Copies;
            }
        }
        public double CalDiscountedPrice()
        {
            return this.price - (this.price * 10);
        }

        public void PrintInfo()
        {
            Console.WriteLine(this.bookTitle);
            Console.WriteLine(this.author);
            Console.WriteLine(this.bookId);
            Console.WriteLine(this.price);
            Console.WriteLine(this.CalDiscountedPrice());
        }
    }

    class EBook : Book, ShowBookInfo
    {
        private string Format;

        public EBook(string bookTitle, Author author, int bookId, double price, int numberOfCopies, string format)
            : base(bookTitle, author, bookId, price, numberOfCopies)
        {
            this.Format = format;
        }
        public new void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine(this.Format);
        }
    }

    class PrintedBook : Book
    {
        private int weight;
        private bool inStock;
        public PrintedBook(string bookTitle, Author author, int bookId, double price, int numberOfCopies, int weight, bool inStock) : base(bookTitle, author, bookId, price, numberOfCopies)
        {
            this.weight = weight;
            this.inStock = inStock;
        }
    }

    interface IBookOperations
    {
        void IssueBook(string Title);
        void ReturnBook(string Title, int bookId);
    }
    class LibraryUser : Library, IBookOperations
    {
        private string userName;
        private int userId;
        private List<Book> booksIssued = new List<Book>();

        public LibraryUser(string name, int userId)
        {
            this.userName = name;
            this.userId = userId;
            this.booksIssued = new List<Book>();
        }

        public void IssueBook(string Title)
        {
            /*foreach(Book bookInLibrary in )*/
            bool Issued = false;
            var books = base.GetBooks();
            foreach (var book in books)
            {
                string temp = book.DisplayTitle();
                if (temp == Title)
                {
                    booksIssued.Add(book);
                    Issued = true;

                    book.UpdateCopies(-1);
                    break;
                }
            }
            if (Issued)
            {
                Console.WriteLine($"The Book:{Title} has been Issued");
            }
            else
            {
                Console.WriteLine($"We don't have this Book:{Title} in Library");
            }
        }

        public void ReturnBook(string Title, int bookId)
        {
            bool Issued = false;
            foreach (var IsuuedBook in booksIssued)
            {
                var temp = IsuuedBook.DisplayTitle();
                var tempBookId = IsuuedBook.GetBookId();
                if (temp == Title && bookId == tempBookId)
                {
                    booksIssued.Remove(IsuuedBook);
                    Issued = true;
                    break;
                }
            }
            if (Issued)
            {
                foreach (var LibraryBooks in base.GetBooks())
                {
                    if ((LibraryBooks.DisplayTitle()) == Title && (LibraryBooks.GetBookId()) == bookId)
                    {
                        LibraryBooks.UpdateCopies(1);
                        break;
                    }
                    else
                    {
                        Issued = false;
                    }
                }
            }
            if (Issued)
            {
                Console.WriteLine($"The Book:{Title} Id:{bookId} has been Returned");
            }
            else
            {
                Console.WriteLine("Ther is some issue");
            }
            /*var books = base.GetBooks();*/
            /*foreach (var book in books)
            {
                string temp = book.DisplayTitle();
                if (temp == Title)
                {
                    booksIssued.Add(book);
                    Issued = true;
                    book.UpdateCopies(-1);
                    break;
                }
            }
            if (Issued)
            {
                Console.WriteLine($"The Book:{Title} has been Issued");
            }
            else
            {
                Console.WriteLine($"We don't have this Book:{Title} in Library");
            }*/

        }
        public void DisplayDetails()
        {
            Console.WriteLine(this.userName);
            Console.WriteLine(this.userId);
            foreach (Book book in booksIssued)
            {
                Console.WriteLine(book.DisplayTitle());
            }
        }

    }
}
