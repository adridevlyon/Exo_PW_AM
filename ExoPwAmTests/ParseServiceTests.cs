using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExoPwAm.Tests
{
    [TestClass()]
    public class ParseServiceTests
    {
        [TestMethod()]
        public void ParseEntryToItemTest_WhenCorrectEntry()
        {
            var entry = "Cercle MonNom 10";
            var expectedItem = new Item
            {
                Type = "Cercle",
                Name = "MonNom",
                Superficy = 10
            };

            var parseService = new ParseService();
            var parseItem = parseService.ParseEntryToItem(entry);

            Assert.IsNotNull(parseItem);
            Assert.AreEqual(expectedItem.Type, parseItem.Type);
            Assert.AreEqual(expectedItem.Name, parseItem.Name);
            Assert.AreEqual(expectedItem.Superficy, parseItem.Superficy);

            entry = "Triangle MonNom 10";
            expectedItem = new Item
            {
                Type = "Triangle",
                Name = "MonNom",
                Superficy = 10
            };

            parseItem = parseService.ParseEntryToItem(entry);

            Assert.IsNotNull(parseItem);
            Assert.AreEqual(expectedItem.Type, parseItem.Type);
            Assert.AreEqual(expectedItem.Name, parseItem.Name);
            Assert.AreEqual(expectedItem.Superficy, parseItem.Superficy);

            entry = "Carré MonNom 10";
            expectedItem = new Item
            {
                Type = "Carré",
                Name = "MonNom",
                Superficy = 10
            };

            parseItem = parseService.ParseEntryToItem(entry);

            Assert.IsNotNull(parseItem);
            Assert.AreEqual(expectedItem.Type, parseItem.Type);
            Assert.AreEqual(expectedItem.Name, parseItem.Name);
            Assert.AreEqual(expectedItem.Superficy, parseItem.Superficy);
        }

        [TestMethod()]
        public void ParseEntryToItemTest_WhenEmptyEntry()
        {
            var entry = string.Empty;

            var parseService = new ParseService();
            var parseItem = parseService.ParseEntryToItem(entry);

            Assert.IsNull(parseItem);
        }

        [TestMethod()]
        public void ParseEntryToItemTest_WhenWrongEntry()
        {
            var entry = "Cercle MonNom";

            var parseService = new ParseService();
            var parseItem = parseService.ParseEntryToItem(entry);

            Assert.IsNull(parseItem);
        }

        [TestMethod()]
        public void ParseEntryToItemTest_WhenEntryWithWrongType()
        {
            var entry = "Cercl MonNom 10";

            var parseService = new ParseService();
            var parseItem = parseService.ParseEntryToItem(entry);

            Assert.IsNull(parseItem);

            entry = "Cercle MonNom test";
            parseItem = parseService.ParseEntryToItem(entry);

            Assert.IsNull(parseItem);
        }
    }
}