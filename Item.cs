using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    internal class Item
    {
        public string id;
        public string title;
        public string author;
        public DateTime year;
        public string genre;
        public bool isAvailable;
        public int inShelf;

        public Item(string id, string title, string author, DateTime year, string genre, bool isAvailable, int inShelf)
        {
            this.title = title;
            this.author = author;
            this.year = year;
            this.genre = genre;
            this.isAvailable = isAvailable;
            this.inShelf = inShelf;
        }

        public void PrintItem()
        {
            Console.WriteLine($"title: { this.title}\n" +
                $"author: {this.author}\n" +
                $"year: {this.year}\n" +
                $"aviability: {this.isAvailable}\n");
        }


    }
}
