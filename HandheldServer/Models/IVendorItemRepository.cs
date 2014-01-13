using System.Collections.Generic;

namespace HandheldServer.Models
{
    interface IVendorItemRepository
    {
        IEnumerable<VendorItem> Get(int ID, int CountToFetch);
        VendorItem Add(VendorItem item);
    }
}
