using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ExoPwAm
{
    public class JsonService
    {
        public const string CollectionJson = "collection.json";

        public void SaveCollectionToFile(List<Item> collection)
        {
            if (collection == null) return;

            using (var file = File.CreateText(CollectionJson))
            {
                var collectionJson = JsonConvert.SerializeObject(collection);
                file.WriteLine(collectionJson);
            }
        }
    }
}
