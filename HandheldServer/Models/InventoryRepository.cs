using System;
using System.Collections.Generic;

namespace HandheldServer.Models
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly List<Inventory> inventories = new List<Inventory>();

        public IEnumerable<Inventory> GetAll()
        {
            return inventories;
        }

        public Inventory Add(Inventory item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            inventories.Add(item);
            // TODO: Add record to database here?
            return item;
        }
    }
}