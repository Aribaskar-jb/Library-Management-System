namespace Library_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Author SalmanRushdie = new Author("Salman Rushdie", "19 June 1947");
            Book TheSatanicVerses = new Book("The Satanic Verses", SalmanRushdie, 1988, 525.0,10);
            LibraryUser Aribaskar = new LibraryUser("Aribaskar-jb", 1508);
        }
    }
}
