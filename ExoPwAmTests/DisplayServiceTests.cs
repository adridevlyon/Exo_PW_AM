using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExoPwAm.Tests
{
    [TestClass()]
    public class DisplayServiceTests
    {
        [TestMethod()]
        public void GetItemDisplayListTest()
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

            var displayService = new DisplayService();
            var i = 0;

            foreach (var itemDisplay in displayService.GetItemDisplayList(collection))
            {
                var item = collection[i];
                Assert.AreEqual($"{item.Type} - {item.Name} - {item.Superficy} cm²", itemDisplay);
                i++;
            }
        }

        [TestMethod()]
        public void GetItemDisplayListTest_WithPricer()
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

            var displayService = new DisplayService();
            IPricer pricer = new Pricer();
            var i = 0;

            foreach (var itemDisplay in displayService.GetItemDisplayList(collection, pricer))
            {
                var item = collection[i];
                Assert.AreEqual($"{item.Type} - {item.Name} - {item.Superficy} cm² - Estimation cout : {pricer.Price(item.Superficy)}{DisplayService.Euro}", itemDisplay);
                i++;
            }

            pricer = new OtherPricer();
            i = 0;

            foreach (var itemDisplay in displayService.GetItemDisplayList(collection, pricer))
            {
                var item = collection[i];
                Assert.AreEqual($"{item.Type} - {item.Name} - {item.Superficy} cm² - Estimation cout : {pricer.Price(item.Superficy)}{DisplayService.Euro}", itemDisplay);
                i++;
            }
        }
    }
}