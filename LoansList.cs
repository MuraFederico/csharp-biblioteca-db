using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    internal class LoansList
    {
        public List<Loan> loans;

        public LoansList()
        {
            this.loans = new List<Loan>();
        }

        public void AddLoan(User loaner, Item item)
        {
            Loan newLoan = new Loan(loaner, item);
            loans.Add(newLoan);
        }

        public Loan FindLoan(string loanerName)
        {
            foreach (Loan loan in loans)
            {
                if(loanerName == loan.loaner.name)
                {
                    return loan;
                }
            }
            return null;
        }

        public void MakeLoan(User loaner, Item itemLoaned)
        {
            Loan newLoan = new Loan(loaner, itemLoaned);
            loans.Add(newLoan);
            itemLoaned.isAvailable = false;
        }

        public void PrintLoans()
        {
            foreach (Loan loan in loans)
            {
                Console.WriteLine($"{loan.loaner.name}\n" +
                    $"{loan.itemLoaned.title}\n" +
                    $"{loan.startLoan}\n" +
                    $"{loan.endLoan}");
            }
        }
    }
}
