using System;
using System.Collections.Generic;
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
        public void AddItem(string serialNumber, uint duration, string title, string author, DateTime year, string genre, bool isAvailable, int inShelf)
        {
            Dvd newDvd = new Dvd(serialNumber, duration, title, author, year, genre, isAvailable, inShelf);
            items.Add(newDvd);
        }

        public void AddItem(string serialNumber, int numberPages, string title, string author, DateTime year, string genre, bool isAvailable, int inShelf)
        {
            Boock newBoock = new Boock(serialNumber, numberPages, title, author, year, genre, isAvailable, inShelf);
            items.Add(newBoock);
        }
        public List<Item> FindItem(string identifier)
        {
            List<Item> results = new List<Item>();
            foreach (Item item in items)
                if (identifier == item.title || identifier == item.id)
                {
                    results.Add(item);
                }
            return results;
        }
    }
}
