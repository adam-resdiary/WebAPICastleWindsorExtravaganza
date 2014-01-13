using System.ComponentModel.DataAnnotations;

namespace HandheldServer.Models
{
    public class ItemGroup
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string item_group_id { get; set; }
        [Required]
        public string name { get; set; }
    }
}