using System;
using System.Collections.Generic;

namespace HandheldServer.Models
{
    public class DeliveryItemRepository : IDeliveryItemRepository
    {
        private readonly List<DeliveryItem> deliveryItems = new List<DeliveryItem>();

        public IEnumerable<DeliveryItem> GetAll()
        {
            return deliveryItems;
        }

        public DeliveryItem Add(DeliveryItem item)
        {
            //Contract.Requires<ArgumentNullException>(item != null, "item"); See http://stackoverflow.com/questions/19365702/why-has-my-webapi-rest-method-broken-over-the-weekend
            if (item == null)
            {
                throw new ArgumentNullException("item");
            } 
            deliveryItems.Add(item);
            return item;
        }
    }
}