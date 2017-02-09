using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExoPwAm.Tests
{
    [TestClass()]
    public class JsonServiceTests
    {
        [TestMethod()]
        public void SaveCollectionToFileTest()
        {
            var jsonService = new JsonService();

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

            jsonService.SaveCollectionToFile(collection);
            Assert.IsTrue(File.Exists(JsonService.CollectionJson));
        }
    }
}