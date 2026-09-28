using System;
using System.Collections.Generic;

namespace BookStore
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Book> books = new List<Book>();

            Book book1 = new Book
            {
                Title = "Cien años de soledad",
                Author = "Gabriel Garcia Marquez",
                PublishYear = 1967,
                Genre = "Realismo magico",
                Stock = 1,
                ISBN = "856-454487787",
                Pages = 300
            };

            Book books2 = new Book
            {
                Title = "El cadaver exquisito",
                Author = "Agustina Bazterrica",
                PublishYear = 2020,
                Genre = "Horror",
                Stock = 3,
                ISBN = "465-4564545645",
                Pages = 249
            };

            List<Magazine> magazines = new List<Magazine>();

            Magazine magazine1 = new Magazine
            {
                Title = "National Geographic",
                Author = "National Geographic Society",
                PublishYear =2026,
                Stock = 2,
                IssueNumber = 125,
                PublicationFrequency = Magazine.Frequency.Weekly
            };


            Magazine magazine2 = new Magazine
            {
                Title = "TIME",
                Author = "TIME Magazine",
                PublishYear = 2026,
                Stock = 5,
                IssueNumber = 15,
                PublicationFrequency = Magazine.Frequency.Weekly
            };

            books.Add(book1);
            books.Add(books2);

            magazines.Add(magazine1);
            magazines.Add(magazine2);


            int option = 0;

            while (option !=6)
            {

                Console.WriteLine("=====BOOKS STORE=====");
                Console.WriteLine("1. Show Books");
                Console.WriteLine("2. Show Magazines");
                Console.WriteLine("3. Request to borrow a book ");
                Console.WriteLine("4. Request to borrow a magazine ");
                Console.WriteLine("5. Return a loan");
                Console.WriteLine("6. Go out");

                Console.WriteLine("\nSelect an Option: ");
                
                if (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Enter a valid number.");
                    Console.ReadLine();
                    continue;
                    }

                switch (option)
                {
                    case 1:
                        Console.Write("\n====BOOKS====\n");

                        foreach (Book book in books)
                        {
                            book.ObtainDescription();
                        }
                        break;

                    case 2:
                        Console.Write("\n====MAGAZINES====\n");
                        foreach (Magazine magazine in magazines)
                        {
                            magazine.ObtainDescription();
                        }
                        break;

                    case 3:

                        Console.Write("User data: ");
                        string borrower = Console.ReadLine();

                        Console.Write("User Document: ");
                        string document = Console.ReadLine();

                        Console.WriteLine("\nAvailable Books");

                        for (int i = 0; i < books.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {books[i].Title} - {books[i].Genre} ");
                        }

                        Console.Write("\nSelect a Book: ");

                        int bookNumber = int.Parse(Console.ReadLine());

                        Book selectedBook = books[bookNumber - 1];

                        selectedBook.Loan(borrower, document);

                        break;

                    case 4:

                        Console.Write("User data: ");
                        string borrower1 = Console.ReadLine();

                        Console.Write("User Document: ");
                        string document2 = Console.ReadLine();

                        Console.WriteLine("\nAvailable Magazines");

                        for (int i = 0; i < magazines.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {magazines[i].Title} - {books[i].Genre} ");
                        }

                        Console.Write("\nSelect a Book: ");

                        int magazineNumber = int.Parse(Console.ReadLine());

                        Magazine selectedMagazine = magazines[magazineNumber - 1];

                        selectedMagazine.Loan(borrower1, document2);


                        break;

                    case 5:

                        Console.WriteLine("1. Book");
                        Console.WriteLine("2. Magazine");

                        Console.Write("What would you like to return: ");

                        if (!int.TryParse(Console.ReadLine(), out option))
                        {
                            Console.WriteLine("Enter a valid number.");
                            Console.ReadLine();
                            continue;
                        }

                        switch (option)
                        {
                            case 1:
                                for (int i = 0; i < books.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1}. {books[i].Title}");
                                }

                                Console.Write("Which book would you like to return?: ");
                                int bookNumberReturn = int.Parse(Console.ReadLine());

                                Book returnBook = books[bookNumberReturn - 1];

                                returnBook.Return();

                                break;

                            case 2:
                                for (int i = 0; i < magazines.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1}. {magazines[i].Title}");
                                }

                                Console.Write("Which magazine would you like to return?: ");
                                int magazineNumberReturn = int.Parse(Console.ReadLine());

                                Magazine returnMagazine = magazines[magazineNumberReturn - 1];

                                returnMagazine.Return();

                                break;

                        }
                        break; 

                    case 6:
                        Console.WriteLine("¡¡¡Come back soon!!!");

                        break;

                }


            }
        }
    }
}
