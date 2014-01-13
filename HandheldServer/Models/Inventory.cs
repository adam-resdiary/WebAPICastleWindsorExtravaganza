using System.ComponentModel.DataAnnotations;

namespace HandheldServer.Models
{
    // This should correspond to "InvHeader" (perhaps InventoryMaster would have been a better name); the related legacy class is
    // InvItem, which perhaps should have been InventoryDetail
    // Local table creation code in the legacy app:
    // CREATE TABLE invHeader ( ID int not null, " +
    // "filename nvarchar(250), sDept float, " +
    // "eDept float, siteno nvarchar(20)
    public class Inventory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string InventoryName { get; set; } // Is this analagous to filename? IOW, do we only need one, not both?
        public string FileName { get; set; }
        public double StartingDept { get; set; }
        public double EndingDept { get; set; }
        [Required]
        public string SiteNumber { get; set; }
    }
}