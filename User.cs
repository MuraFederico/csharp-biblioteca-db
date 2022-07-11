using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    internal class User
    {
        public int id;
        public string surname;
        public string name;
        public string email;
        public string password;
        public bool isLogged;

        public User(int id, string surname, string name, string email, string password)
        {
            this.surname = surname;
            this.name = name;
            this.email = email;
            this.password = password;
            isLogged = false;
        }


    }
}
