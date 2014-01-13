using System.ComponentModel.DataAnnotations;

namespace HandheldServer.Models
{
    public class Vendor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string vendor_id { get; set; }
        [Required]
        public string name { get; set; }
    }
}