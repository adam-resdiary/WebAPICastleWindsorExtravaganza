using System.Collections.Generic;
using System.Linq;

namespace HandheldServer.Models
{
    interface IInventoryItemRepository
    {
        IEnumerable<InventoryItem> Get(string ID, int packSize, int CountToFetch); // <-- will query from the string (excluding that particular one, though) up to CountToFetch records
        IEnumerable<InventoryItem> Get(string ID, int CountToFetch); // <-- will query from the string (excluding that particular one, though) up to CountToFetch records
        InventoryItem Get(int ID);

        int Get();

        //InventoryItem Add(InventoryItem item);
        void Add(InventoryItem item);
        bool Update(InventoryItem item);
    }
}
