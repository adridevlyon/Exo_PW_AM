﻿using System;
using System.Collections.Generic;

namespace ExoPwAm
{
    class Program
    {
        static void Main(string[] args)
        {
            var collection = new List<Item>()
            {
                new Item()
                {
                    Type = "Cercle",
                    Name = "Nom1",
                    Superficy = 12
                },
                new Item()
                {
                    Type = "Cercle",
                    Name = "Nom2",
                    Superficy = 15
                },
                new Item()
                {
                    Type = "Triangle",
                    Name = "Nom3",
                    Superficy = 16
                }
            };

            var displayService = new DisplayService();

            foreach (var itemDisplay in displayService.GetItemDisplayList(collection))
            {
                Console.WriteLine(itemDisplay);
            }
        }
    }
}
