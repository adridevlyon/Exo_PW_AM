using System.Collections.Generic;

namespace ExoPwAm
{
    public class DisplayService
    {
        public IEnumerable<object> GetItemDisplayList(IEnumerable<Item> collection)
        {
            foreach (var item in collection)
            {
                yield return $"{item.Type} - {item.Name} - {item.Superficy} cm²";
            }
        }
    }
}
