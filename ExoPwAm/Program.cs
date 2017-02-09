using System;
using System.Collections.Generic;
using System.Text;

namespace ExoPwAm
{
    class Program
    {
        private const string ExpectedFormat = "Format attendu : [Cercle|Triangle|Carré] [Nom] [Superficie]";
        private const string WrongFormat = "Mauvais format d'entrée !";
        private const string ItemAdded = "Nouvel élément créé avec succès !";
        private static DisplayService _displayService;
        private static ParseService _parseService;
        private static JsonService _jsonService;
        private static IPricer _pricer;

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Default;
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

            collection.Add(newItem);

            _jsonService = new JsonService();
            _jsonService.SaveCollectionToFile(collection);

            Console.WriteLine(ItemAdded);
            Console.WriteLine();

            DisplayCollectionWithPricer(collection);

            Console.WriteLine();
            DisplayCollectionWithOtherPricer(collection);

            Console.ReadLine();
        }

        private static void DisplayCollectionWithOtherPricer(List<Item> collection)
        {
            _pricer = new OtherPricer();

            Console.WriteLine("Avec OtherPricer :");
            foreach (var itemDisplay in _displayService.GetItemDisplayList(collection, _pricer))
            {
                Console.WriteLine(itemDisplay);
            }
        }

        private static void DisplayCollectionWithPricer(List<Item> collection)
        {
            _pricer = new Pricer();

            Console.WriteLine("Avec Pricer :");
            foreach (var itemDisplay in _displayService.GetItemDisplayList(collection, _pricer))
            {
                Console.WriteLine(itemDisplay);
            }
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
