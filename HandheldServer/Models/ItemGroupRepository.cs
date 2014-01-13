using System;
using System.Collections.Generic;
using System.Linq;

namespace HandheldServer.Models
{
    public class ItemGroupRepository : IItemGroupRepository
    {
        private readonly List<ItemGroup> itemGroups = new List<ItemGroup>();

        public ItemGroupRepository()
        {
            // This will be replaced by the actual data access, querying MS SQL Server
            Add(new ItemGroup { Id = 1, item_group_id = "7.0", name = "itemGroup7" });
            Add(new ItemGroup { Id = 2, item_group_id = "8.0", name = "itemGroup8" });
            Add(new ItemGroup { Id = 3, item_group_id = "9.0", name = "itemGroup9" });
            Add(new ItemGroup { Id = 4, item_group_id = "10.0", name = "itemGroup7" });
            Add(new ItemGroup { Id = 5, item_group_id = "11.0", name = "itemGroup7" });
            Add(new ItemGroup { Id = 6, item_group_id = "12.0", name = "itemGroup8" });
        }

        public IEnumerable<ItemGroup> Get(int ID, int CountToFetch)
        {
            return itemGroups.Where(i => i.Id > ID).Take(CountToFetch);
        }


        // This can be removed once the constructor gets actual data
        public ItemGroup Add(ItemGroup item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            itemGroups.Add(item);
            return item;
        }

    }
}