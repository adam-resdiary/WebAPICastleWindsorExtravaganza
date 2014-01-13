using System.ComponentModel.DataAnnotations;

namespace HandheldServer.Models
{
    public class VendorItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string VendorId { get; set; }
        [Required]
        public string VendorItemId { get; set; }
        [Required]
        public string ItemId { get; set; }
        [Required]
        public int PackSize { get; set; }
    }
}