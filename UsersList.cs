using System;
using System.Collections.Generic;
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
        public void RegisterUser(string surname, string name, string email, string password, string phoneNumber)
        {
            User newUser = new User(surname, name, email, password, phoneNumber);
            users.Add(newUser);
        }

        public User LogIn(string email, string password)
        {
            foreach (User user in users)
            {
                if(user.email == email && user.password == password)
                {
                    Console.WriteLine($"Welcome {user.name} {user.surname}\n");
                    user.isLogged = true;
                    return user;
                }
            }
            Console.WriteLine("wrong credentials");
            return null;
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
