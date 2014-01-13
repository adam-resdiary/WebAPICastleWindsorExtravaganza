using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HandheldServer.Models
{
    public class WorkTables
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string fileType { get; set; }
        public int totalItems { get; set; }
        public double totalAmt { get; set; }
        public int siteNo { get; set; }
        public string fileDate { get; set; }
    }
}