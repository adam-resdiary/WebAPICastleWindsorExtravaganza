using System;
using System.Collections.Generic;
using System.Linq;

namespace HandheldServer.Models
{
    public class VendorRepository : IVendorRepository
    {
        private readonly List<Vendor> vendors = new List<Vendor>();

        public VendorRepository()
        {
            // This will be replaced by the actual data access, querying MS SQL Server
            Add(new Vendor { Id = 1, vendor_id = "7.0", name = "Vendor7" });
            Add(new Vendor { Id = 2, vendor_id = "8.0", name = "Vendor8" });
            Add(new Vendor { Id = 3, vendor_id = "9.0", name = "Vendor9" });
            Add(new Vendor { Id = 4, vendor_id = "10.0", name = "Vendor7" });
            Add(new Vendor { Id = 5, vendor_id = "11.0", name = "Vendor7" });
            Add(new Vendor { Id = 6, vendor_id = "12.0", name = "Vendor8" });
        }

        public IEnumerable<Vendor> Get(int ID, int CountToFetch)
        {
            return vendors.Where(i => i.Id > ID).Take(CountToFetch);
        }

        // This can be removed once the constructor gets actual data
        public Vendor Add(Vendor item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("vendor item is null");
            }
            vendors.Add(item);
            return item;
        }
    }

}