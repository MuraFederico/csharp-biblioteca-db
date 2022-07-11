using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace csharp_biblioteca
{
    internal class UsersList
    {
        List<User> users;

        public UsersList()
        {
            users = new List<User>();
        }
        public void RegisterUser(string surname, string name, string email, string password)
        {
            using(SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=biblioteca-db;Integrated Security=True"))
            {
                try
                {
                    connection.Open();

                    using(SqlCommand command = connection.CreateCommand())
                    using(SqlTransaction transaction = connection.BeginTransaction("UserCreation"))
                    {
                        command.Transaction = transaction;
                        command.Connection = connection;

                        try
                        {
                            command.CommandText = "INSERT INTO Users (Name, Surname, Email, Password) VALUES (@name, @surname, @email, @password)";
                            command.Parameters.Add(new SqlParameter("@name", name));
                            command.Parameters.Add(new SqlParameter("@surname", surname));
                            command.Parameters.Add(new SqlParameter("@email", email));
                            command.Parameters.Add(new SqlParameter("@password", password));

                            command.ExecuteNonQuery();
                            transaction.Commit();
                        } catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                            transaction.Rollback();
                        }
                    }
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public User LogIn(string email, string password)
        {
            User user = null;

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
                            command.CommandText = "SELECT * FROM Users WHERE Email=@email AND Password=@password";
                            command.Parameters.Add(new SqlParameter("@email", email));
                            command.Parameters.Add(new SqlParameter("@password", password));

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
                                string name = reader.GetString(1);
                                string surname = reader.GetString(2);
                                email = reader.GetString(3);
                                password = reader.GetString(4);
                                user = new User(surname, name, email, password);
                                user.isLogged = true;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            return user;
        }
        public void PrintUsers()
        {
            foreach (User user in users)
            {
                Console.WriteLine($"{user.name} {user.surname}\n");
            }
        }
    }
}
