using System.Collections.Generic;

namespace ExoPwAm
{
    public class ParseService
    {
        private const int NumberElements = 3;
        private List<string> AllowedTypes = new List<string>(new[] { "Cercle", "Triangle", "Carré" });

        public Item ParseEntryToItem(string entry)
        {
            if (string.IsNullOrEmpty(entry)) return null;

            var entrySplit = entry.Split(' ');

            if (entrySplit.Length != NumberElements) return null;

            var type = entrySplit[0];
            if (!CheckType(type)) return null;

            var superficy = 0;
            if (!int.TryParse(entrySplit[2], out superficy)) return null;

            return new Item
            {
                Type = type,
                Name = entrySplit[1],
                Superficy = superficy
            };
        }

        private bool CheckType(string type)
        {
            return AllowedTypes.Contains(type);
        }
    }
}
