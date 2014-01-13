using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HandheldServer.Models
{
    public class SiteMapping
    {
        public int Id { get; set; }
        public int site_no { get; set; }
        public string location_num { get; set; }
        public string station_name { get; set; }
        public string station_street { get; set; }
        public string station_city { get; set; }
    }
}