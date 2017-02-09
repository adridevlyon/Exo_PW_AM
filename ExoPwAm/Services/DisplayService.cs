using System.Collections.Generic;
using System.Text;

namespace ExoPwAm
{
    public class DisplayService
    {
        public static string Euro = Encoding.Default.GetString(new byte[] { 128 });

        public IEnumerable<string> GetItemDisplayList(IEnumerable<Item> collection, IPricer pricer = null)
        {
            foreach (var item in collection)
            {
                yield return GetItemDisplay(item, pricer);
            }
        }

        public string GetItemDisplay(Item item, IPricer pricer = null)
        {
            var display = $"{item.Type} - {item.Name} - {item.Superficy} cm²";
            if (pricer != null)
            {
                display += $" - Estimation cout : { pricer.Price(item.Superficy)}" + Euro;
            }
            return display;
        }
    }
}
