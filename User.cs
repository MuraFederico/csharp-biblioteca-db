using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    internal class User
    {
        public string surname;
        public string name;
        public string email;
        public string password;
        public string phoneNumber;
        public bool isLogged;

        public User(string surname, string name, string email, string password, string phoneNumber)
        {
            this.surname = surname;
            this.name = name;
            this.email = email;
            this.password = password;
            this.phoneNumber = phoneNumber;
            isLogged = false;
        }


    }
}
