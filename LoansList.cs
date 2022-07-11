using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

/*        public void AddLoan(User loaner, Item item)
        {
            Loan newLoan = new Loan(loaner, item);
            loans.Add(newLoan);
        }*/

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

        public void MakeLoan(User loaner, int bookId, DateTime start, DateTime end)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=biblioteca-db;Integrated Security=True"))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = connection.CreateCommand())
                    using (SqlTransaction transaction = connection.BeginTransaction("UserCreation"))
                    {
                        command.Transaction = transaction;
                        command.Connection = connection;

                        try
                        {
                            command.CommandText = "INSERT INTO Rents (user_id, Copy_id, Start, [End]) VALUES (@user_id, @copy_id, @start, @end)";
                            command.Parameters.Add(new SqlParameter("@user_id", loaner.id));
                            command.Parameters.Add(new SqlParameter("@copy_id", bookId));
                            command.Parameters.Add(new SqlParameter("@start", start));
                            command.Parameters.Add(new SqlParameter("@end", end));

                            command.ExecuteNonQuery();
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            transaction.Rollback();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
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
