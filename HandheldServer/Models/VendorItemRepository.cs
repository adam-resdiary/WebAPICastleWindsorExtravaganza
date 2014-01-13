using System;
using System.Collections.Generic;
using System.Linq;

namespace HandheldServer.Models
{
    public class VendorItemRepository : IVendorItemRepository
    {
        private readonly List<VendorItem> vendorItems = new List<VendorItem>();

        public VendorItemRepository()
        {
            // This will be replaced by the actual data access, querying MS SQL Server
            Add(new VendorItem { Id = 1, VendorId = "7.0", VendorItemId = "vendItem7", ItemId = "itemId1", PackSize = 1 });
            Add(new VendorItem { Id = 2, VendorId = "8.0", VendorItemId = "vendItem8", ItemId = "itemId2", PackSize = 2 });
            Add(new VendorItem { Id = 3, VendorId = "9.0", VendorItemId = "vendItem9", ItemId = "itemId3", PackSize = 4 });
            Add(new VendorItem { Id = 4, VendorId = "10.0", VendorItemId = "vendItem7", ItemId = "itemId4", PackSize = 6 });
            Add(new VendorItem { Id = 5, VendorId = "11.0", VendorItemId = "vendItem7", ItemId = "itemId5", PackSize = 12 });
            Add(new VendorItem { Id = 6, VendorId = "12.0", VendorItemId = "vendItem8", ItemId = "itemId6", PackSize = 24 });
        }

        public IEnumerable<VendorItem> Get(int ID, int CountToFetch)
        {
            return vendorItems.Where(i => i.Id > ID).Take(CountToFetch);
        }


        // This can be removed once the constructor gets actual data
        public VendorItem Add(VendorItem item)
        {
            //Contract.Requires<ArgumentNullException>(item != null, "item");
            //Contract.Requires<ArgumentNullException>(item != null, "item");
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            vendorItems.Add(item);
            return item;
        }

    }
}