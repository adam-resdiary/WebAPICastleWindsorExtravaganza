using System;
using System.Collections.Generic;

namespace HandheldServer.Models
{
    public class DeliveryRepository : IDeliveryRepository
    {
        private readonly List<Delivery> deliveries = new List<Delivery>();

        public IEnumerable<Delivery> GetAll()
        {
            return deliveries;
        }

        public Delivery Add(Delivery item)
        {
            // I asked which approach is better here: http://codereview.stackexchange.com/questions/32576/which-approach-for-checking-for-null-is-preferable-or-are-they-2-of-one-a-pair
            // If clear-cut reason to go with one of the Contract.Requires, change the rest to that approach.
            //Contract.Requires(item != null);
            //Contract.Requires<ArgumentNullException>(item != null, "item");
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            deliveries.Add(item);
            //Contract.Ensures(); <-- need to ensure anything?
            return item;
        }

    }
}