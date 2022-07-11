using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    internal class ItemsList
    {
        public List<Item> items;

        public ItemsList()
        {
            this.items = new List<Item>();
        }
        public void AddItem(int serialNumber, uint duration, string title, string author, DateTime year, string genre, bool isAvailable, int inShelf)
        {
            Dvd newDvd = new Dvd(serialNumber, duration, title, author, year, genre, isAvailable, inShelf);
            items.Add(newDvd);
        }

        public void AddItem(int serialNumber, int numberPages, string title, string author, DateTime year, string genre, bool isAvailable, int inShelf)
        {
            Boock newBoock = new Boock(serialNumber, numberPages, title, author, year, genre, isAvailable, inShelf);
            items.Add(newBoock);
        }
        public List<Item> FindItem(string identifier)
        {
            List<Item> results = new List<Item>();

            using (SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=biblioteca-db;Integrated Security=True"))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = connection.CreateCommand())
                    using (SqlTransaction transaction = connection.BeginTransaction("RetrivUser"))
                    {
                        command.Transaction = transaction;
                        command.Connection = connection;

                        try
                        {
                            command.CommandText = "SELECT * FROM Books" +
                                " INNER JOIN Copies ON Copies.Book_id = Books.Id" +
                                " WHERE Books.Title=@srcString OR Copies.ISBN=@srcString";
                            command.Parameters.Add(new SqlParameter("@srcString", identifier));

                            command.ExecuteNonQuery();

                            transaction.Commit();

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                            transaction.Rollback();
                        }
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(6);
                                string title = reader.GetString(1);
                                string author = reader.GetString(2);
                                DateTime year = reader.GetDateTime(3);
                                string ISBN = reader.GetString(11);
                                int pages = reader.GetInt32(12);
                                Boock book = new Boock(id, pages, title, author, year, "genere generico", true, 2);
                                results.Add(book);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            return results;
        }
    }
}
