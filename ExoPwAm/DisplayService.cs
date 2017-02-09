using System.Collections.Generic;

namespace ExoPwAm
{
    public class DisplayService
    {
        public IEnumerable<string> GetItemDisplayList(IEnumerable<Item> collection)
        {
            foreach (var item in collection)
            {
                yield return GetItemDisplay(item);
            }
        }

        public string GetItemDisplay(Item item)
        {
            return $"{item.Type} - {item.Name} - {item.Superficy} cm²";
        }
    }
}
