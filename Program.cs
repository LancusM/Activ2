using System.Security.Cryptography.X509Certificates;

namespace Activ2
{
    internal class Program
    {

        class Book
        {
            private string bookName;
            private string authorName;
            private string genreID;
            private bool inLibrary;
            private string currentCheckoutUser;

            public string BookName {
                get { return bookName; }
                set { bookName = value; }
            }
            public string AuthorName {
                get { return authorName; }
                set { authorName = value; }
            }
            public string GenreID {
                get { return genreID; }
                set { genreID = value; }
            }
            public bool InLibrary {
                get { return inLibrary; }
                set { inLibrary = value; }
            }
            public string CurrentCheckoutUser {
                get { return currentCheckoutUser; }
                set { currentCheckoutUser = value; }
            }



            //Default constructor
            public Book()
            {
                bookName = "Unknown";
                authorName = "Unknown";
                genreID = "000";
                inLibrary = true;
                currentCheckoutUser = null;
            }
            //Overloaded constructor
            public Book(string name, string author, string genre)
            {
                bookName = name;
                authorName = author;
                genreID = genre;
                inLibrary = true;
                currentCheckoutUser = null;
            }
            public void CheckOut(string userName)
            {
                if (inLibrary)
                {
                    inLibrary = false;
                    currentCheckoutUser = userName;
                    Console.WriteLine($"You have checked out {bookName}. Enjoy reading, {userName}!");
                }
                else
                    {
                        Console.WriteLine($"Sorry, {bookName} is currently checked out by {currentCheckoutUser}.");
                    }
                }
            public void ReturnBook()
            {
                if (!inLibrary)
                {
                    inLibrary = true;
                    Console.WriteLine($"Thank you for returning {bookName}, {currentCheckoutUser}. We hope you enjoyed it!");
                    currentCheckoutUser = null;
                }
                else
                {
                    Console.WriteLine($"{bookName} is already in the library.");
                }
            }
            public void DisplayInfo()
            {
                string status = inLibrary ? "Available" : $"Checked out by {currentCheckoutUser}";
                Console.WriteLine($"Title: {bookName}, Author: {authorName}, Genre ID: {genreID}, Status: {status}");
            }
        }

        

        static void Main(string[] args)
        {

            //FIVE variables (w/ access modifiers)
            //Proprties per variable(?)
            //TWO constructors
            //THREE methods (outside of get/set for the constructors)


            Book book1 = new Book("1984", "George Orwell", "Dystopian");
            Book book2 = new Book("To Kill a Mockingbird", "Harper Lee", "Classic");
            Book book3 = new Book("The Great Gatsby", "F. Scott Fitzgerald", "Classic");
            Book book4 = new Book("The Catcher in the Rye", "J.D. Salinger", "Classic");

            //book1.DisplayInfo();
            //book2.DisplayInfo();
            //book3.DisplayInfo();
            //book4.DisplayInfo();

            book1.CheckOut("Alice");
            book3.CheckOut("Bob");
            book2.CheckOut("Charlie");
            book2.ReturnBook();
            

            //book1.DisplayInfo();
            //book2.DisplayInfo();
            //book3.DisplayInfo();
            //book4.DisplayInfo();
        }
        

    }
}
