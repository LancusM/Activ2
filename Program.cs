using System.Security.Cryptography.X509Certificates;

namespace Activ3
{
    internal class Program
    {

        class Book
        {
            protected string bookName;
            protected string authorName;
            protected string genreID;
            protected bool inLibrary;
            //private bool isBanned;
            protected string currentCheckoutUser;
            protected string bookType;
            protected string location;

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
            //public bool IsBanned
            //{
            //    get { return isBanned; }
            //    set { isBanned = value; }
            //}
            public string CurrentCheckoutUser {
                get { return currentCheckoutUser; }
                set { currentCheckoutUser = value; }
            }
            public string BookType
            {
                get { return bookType; }
                set { bookType = value; }
            }
            public string Location
            {
                get { return location; }
                set { location = value; }
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
                //isBanned = false;
                currentCheckoutUser = null;
            }

            public void createBook(string name, string author, string genre, string type, string theLocation)
            {

                bookName = name;
                authorName = author;
                genreID = genre;
                inLibrary = true;
                //isBanned = false;
                currentCheckoutUser = null;
                bookType = type;
                location = theLocation;

            }

            //public void BanBook()
            //{
            //    isBanned = true;
            //    Console.WriteLine($"{bookName} has been banned from the library.");
            //    inLibrary = false;
            //}

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
                    //if (isBanned)
                    //{
                    //    Console.WriteLine($"This book, {bookName}, is banned and cannot be returned.");
                    //    return;
                    //}
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

        class BadBook : Book
        {
            Book badBook;
            protected string reasonBanned;

            public string ReasonBanned
            {
                get { return reasonBanned; }
                set { reasonBanned = value; }
            }
            public void BannedInfo()
            {
                string status = "Banned from library: " + reasonBanned;
                Console.WriteLine($"{bookName} is banned from the library. Reason: {reasonBanned}");
            }
            public void DisplayInfo()
            {
                string status = "Banned from library.";
                Console.WriteLine($"Title: {bookName}, Author: {authorName}, Genre ID: {genreID}, Status: {status}");
            }
            public void CheckOut(string userName)
            {
                Console.WriteLine($"Sorry, {bookName} is banned and cannot be checked out.");
            }
        }

        class AgeRange : Book
        {
            Book ageBook;
            protected int minAge;
            protected int maxAge;

            public int MinAge
            {
                get { return minAge; }
                set { minAge = value; }
            }
            public int MaxAge
            {
                get { return maxAge; }
                set { maxAge = value; }
            }
            public void AgeInfo()
            {
                string status = "Recommended Age Range: " + minAge + " to " + maxAge;
                Console.WriteLine($"Title: {bookName}, Author: {authorName}, Genre ID: {genreID}, Status: {status}");
            }
        }

        class butIsItActuallyAGoodRead : Book
        {
            Book isItGood;
            protected int rating; //1-10
            public int Rating
            {
                get { return rating; }
                set { rating = value; }
            }
            public void GoodReadInfo()
            {
                string status = "Reader Rating: " + rating + "/10";
                Console.WriteLine($"Title: {bookName}, Author: {authorName}, Genre ID: {genreID}, Status: {status}");
            }
        }

        static void Main(string[] args)
        {

            //FIVE variables (w/ access modifiers)
            //Proprties per variable(?)
            //TWO constructors
            //THREE methods (outside of get/set for the constructors)


            //Book book1 = new Book("1984", "George Orwell", "Dystopian");
            //Book book2 = new Book("To Kill a Mockingbird", "Harper Lee", "Classic");
            //Book book3 = new Book("The Great Gatsby", "F. Scott Fitzgerald", "Classic");
            //Book book4 = new Book("The Catcher in the Rye", "J.D. Salinger", "Classic");

            Book book1 = new Book();
            Book book2 = new Book();
            Book book3 = new Book();
            Book book4 = new Book();
            //Book book5 = new Book();

            book1.createBook("1984", "George Orwell", "Dystopian", "Hardback", "North");
            book2.createBook("To Kill a Mockingbird", "Harper Lee", "Classic", "Paperback", "East");
            book3.createBook("The Great Gatsby", "F. Scott Fitzgerald", "Classic", "Audio", "South");
            book4.createBook("The Catcher in the Rye", "J.D. Salinger", "Classic", "Paperback", "West");
            //book5.createBook("The Communist Manifesto", "Karl Marx", "Political", "Hardback", "North");
            //book5.BanBook();

            book1.CheckOut("Alice");
            book3.CheckOut("Bob");
            book2.CheckOut("Charlie");
            book2.ReturnBook();
            Console.WriteLine();

            BadBook book5 = new BadBook();
            book5.createBook("The Communist Manifesto", "Karl Marx", "Political", "Hardback", "North");

            book5.ReasonBanned = "Because.";

            book5.BannedInfo();

            AgeRange book6 = new AgeRange();
            AgeRange book7 = new AgeRange();
            book6.createBook("Green Eggs and Ham", "Dr. Seuss", "Children's", "Paperback", "East");
            book7.createBook("War and Peace", "Leo Tolstoy", "Classic", "Hardback", "West");

            book6.MinAge = 3;
            book6.MaxAge = 7;
            book7.MinAge = 16;
            book7.MaxAge = 99;

            book6.AgeInfo();
            book7.AgeInfo();

            butIsItActuallyAGoodRead book8 = new butIsItActuallyAGoodRead();
            book8.createBook("The Hobbit", "J.R.R. Tolkien", "Fantasy", "Paperback", "South");
            book8.Rating = 9;
            book8.GoodReadInfo();

            Console.WriteLine();
            book5.CheckOut("Dave");
            //book5.ReturnBook();
            book7.CheckOut("Eve");
            book6.ReturnBook();

            book8.CheckOut("Frank");
            book8.ReturnBook();
            //book5.CheckOut("Dave");

            Console.WriteLine();
            book1.DisplayInfo();
            book2.DisplayInfo();
            book3.DisplayInfo();
            book4.DisplayInfo();
            book5.DisplayInfo();
            book6.DisplayInfo();
            book7.DisplayInfo();
            book8.DisplayInfo();

            //book1.DisplayInfo();
            //book2.DisplayInfo();
            //book3.DisplayInfo();
            //book4.DisplayInfo();
        }


    }
}
