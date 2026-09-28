using System;

namespace BookStore
{     
    public abstract class Material
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublishYear { get; set; }
        public int Stock {  get; set; }
        public bool IsAvailable() => Stock > 0;
        public abstract void ObtainDescription();

    }

    public class Book : Material, ILoanable
    { 
        public string ISBN { get; set; }
        public int Pages { get; set; }
        public string Genre { get; set; }

        public bool Loan(string borrower, string document)
        {
            if (IsAvailable())
            {
                Stock--;
                Console.WriteLine($"The Book '{Title}' has been successfully lent.");
                Console.WriteLine($"Remaiing stock: {Stock}");

                return true;
            }

                Console.WriteLine($"The Book '{Title}' is not available.");

                return false;
            
        }
       

        public override void ObtainDescription() =>
            Console.WriteLine($"Book: {Title} by {Author} ({PublishYear}) - Genre: {Genre} - ISBN: {ISBN} - It has {Pages} number of pages - " + $" Is Available: {(IsAvailable()? "Yes":"No")}" );

        public void Return()
        {
            Stock++;

            Console.WriteLine($"The Book '{Title}' has been returned.");
            Console.WriteLine($"Remaiing stock: {Stock}");
        }
    }

    public class Magazine : Material, ILoanable
    {
        public Frequency PublicationFrequency { get; set; }
        public int IssueNumber { get; set; }

        public bool Loan(string borrower, string document)
        {
            if (IsAvailable())
            {
                Stock--;
                Console.WriteLine($"The Magazine '{Title}' has been successfully lent.");
                Console.WriteLine($"Remaiing stock: {Stock}");

                return true;
            }

            Console.WriteLine($"The Magazine '{Title}' is not available.");

            return false;
        }

        public override void ObtainDescription() => 
            Console.WriteLine($"Magazine: {Title} by {Author} ({PublishYear}) - Issue: {IssueNumber} - " + $" Is Available: {(IsAvailable() ? "Yes" : "No")}" );

        public void Return()
        {
            Stock++;

            Console.WriteLine($"The Magazine '{Title}' has been returned.");
            Console.WriteLine($"Remaiing stock: {Stock}");
        }

        public enum Frequency { Weekly, Monthly, Quarterly }
    }
}
