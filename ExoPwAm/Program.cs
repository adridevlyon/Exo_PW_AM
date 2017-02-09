using System;
using System.Collections.Generic;

namespace ExoPwAm
{
    class Program
    {
        private const string ExpectedFormat = "Format attendu : [Cercle|Triangle|Carré] [Nom] [Superficie]";
        private const string WrongFormat = "Mauvais format d'entrée !";
        private const string ItemAdded = "Nouvel élément créé avec succès !";
        private static DisplayService _displayService;
        private static ParseService _parseService;

        static void Main(string[] args)
        {
            var collection = new List<Item>
            {
                new Item
                {
                    Type = "Cercle",
                    Name = "Nom1",
                    Superficy = 12
                },
                new Item
                {
                    Type = "Cercle",
                    Name = "Nom2",
                    Superficy = 15
                },
                new Item
                {
                    Type = "Triangle",
                    Name = "Nom3",
                    Superficy = 16
                }
            };

            _displayService = new DisplayService();
            DisplayCollection(collection);

            _parseService = new ParseService();

            var newItem = AddNewEntry();
            Console.WriteLine(ItemAdded);
            Console.WriteLine(_displayService.GetItemDisplay(newItem));
            Console.ReadLine();
        }

        private static Item AddNewEntry()
        {
            Console.WriteLine();
            Console.WriteLine("Ajouter un élément ? " + ExpectedFormat);
            var newEntry = Console.ReadLine();

            var newItem = _parseService.ParseEntryToItem(newEntry);
            while (newItem == null)
            {
                Console.WriteLine(WrongFormat);
                Console.WriteLine(ExpectedFormat);
                newEntry = Console.ReadLine();
                newItem = _parseService.ParseEntryToItem(newEntry);
            }

            return newItem;
        }

        private static void DisplayCollection(List<Item> collection)
        {
            foreach (var itemDisplay in _displayService.GetItemDisplayList(collection))
            {
                Console.WriteLine(itemDisplay);
            }
        }
    }
}
