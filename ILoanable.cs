
namespace BookStore
{
    internal interface ILoanable
    {
        bool Loan(string borrower, string document);

        void Return();
    }
}
