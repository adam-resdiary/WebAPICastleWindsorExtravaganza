using System.Collections.Generic;

namespace HandheldServer.Models
{
    interface IVendorRepository
    {
        IEnumerable<Vendor> Get(int ID, int CountToFetch);
        Vendor Add(Vendor item);
    }
}
