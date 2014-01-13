using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HandheldServer.Models
{
    public class SiteMappingRepository : ISiteMappingRepository
    {
        private readonly List<SiteMapping> siteMappings = new List<SiteMapping>();

        public SiteMappingRepository()
        {
            // This will be replaced by the actual data access, querying MS SQL Server
            Add(new SiteMapping { Id = 10, site_no = 3, location_num = "three", station_name = "Sheep Station", station_street = "Adelaide Avenue", station_city = "Adelaide" });
            Add(new SiteMapping { Id = 20, site_no = 6, location_num = "six", station_name = "Service Station", station_street = "Brisbane Boulevard", station_city = "Brisbane" });
            Add(new SiteMapping { Id = 30, site_no = 1, location_num = "one", station_name = "Gas Station", station_street = "Canberra Circle", station_city = "Canberra" });
            Add(new SiteMapping { Id = 40, site_no = 2, location_num = "two", station_name = "Inflation Station", station_street = "Darwin Drive", station_city = "Darwin" });
            Add(new SiteMapping { Id = 50, site_no = 42, location_num = "forty2", station_name = "TV Station", station_street = "Sydney Street", station_city = "Sydney" });
            Add(new SiteMapping { Id = 55, site_no = 76, location_num = "76Trombones", station_name = "Radio Station", station_street = "Wagga Wagga Way", station_city = "Wagga Wagga" });
        }

        public IEnumerable<SiteMapping> Get(int ID, int CountToFetch)
        {
            return siteMappings.Where(i => i.Id > ID).Take(CountToFetch);
        }

        // This can be removed once the constructor gets actual data
        public SiteMapping Add(SiteMapping item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("site mapping item null");
            }
            siteMappings.Add(item);
            return item;
        }

    }
}