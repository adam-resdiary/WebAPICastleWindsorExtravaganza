// I created this using http://www.asp.net/web-api/overview/getting-started-with-aspnet-web-api/tutorial-your-first-web-api as a basis,
// and then cleaned it up with Resharper
using System.Collections.Generic;
using HandheldServer.Models;
using System.Web.Http;

namespace HandheldServer.Controllers
{
    public class VendorItemsController : ApiController
    {
        static readonly IVendorItemRepository vendorItemsRepository = new VendorItemRepository();

        public IEnumerable<VendorItem> GetBatchOfVendorItemsByStartingID(int ID, int CountToFetch)
        {
            return vendorItemsRepository.Get(ID, CountToFetch);
        } 

    }
}
