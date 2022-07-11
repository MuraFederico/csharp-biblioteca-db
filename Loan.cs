using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    internal class Loan
    {
        public User loaner;
        public Item itemLoaned;
        public DateTime startLoan;
        public DateTime endLoan;
        double loanDuration;

        public Loan(User loaner, Item itemLoaned)
        {
            this.loaner = loaner;
            this.itemLoaned = itemLoaned;
            this.startLoan = new DateTime();
            this.endLoan = new DateTime().AddDays(loanDuration);
        }


    }
}
