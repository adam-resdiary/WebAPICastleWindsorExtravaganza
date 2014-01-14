using System.Collections.Generic;
using System.Web.Http;
using HandheldServer.Models;

namespace HandheldServer.Controllers
{
    public class VendorsController : ApiController
    {
        static readonly IVendorRepository vendorsRepository = new VendorRepository();

        public IEnumerable<Vendor> GetBatchOfVendorsByStartingID(int ID, int CountToFetch)
        {
            return vendorsRepository.Get(ID, CountToFetch);
        } 

    }
}
