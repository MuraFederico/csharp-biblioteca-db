using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    internal class Dvd : Item
    {

        uint duration;
        public Dvd(string id, uint duration, string title, string author, DateTime year, string genre, bool isAvailable, int inShelf) : base(id, title, author, year, genre, isAvailable, inShelf)
        {
            this.duration = duration;
            this.id = id;
        }
    }
}
