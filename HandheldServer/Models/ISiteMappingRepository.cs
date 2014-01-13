using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HandheldServer.Models
{
    interface ISiteMappingRepository
    {
        IEnumerable<SiteMapping> Get(int ID, int CountToFetch);
        SiteMapping Add(SiteMapping item);
    }
}