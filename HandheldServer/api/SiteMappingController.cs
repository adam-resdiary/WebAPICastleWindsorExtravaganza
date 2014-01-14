using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HandheldServer.Models;

namespace HandheldServer.Controllers
{
    public class SiteMappingController : ApiController
    {
        static readonly ISiteMappingRepository sitemappingsRepository = new SiteMappingRepository();

        public IEnumerable<SiteMapping> GetBatchOfSiteMappingsByStartingID(int ID, int CountToFetch)
        {
            return sitemappingsRepository.Get(ID, CountToFetch);
        } 

    }
}
