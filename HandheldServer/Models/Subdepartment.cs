using System.ComponentModel.DataAnnotations;

namespace HandheldServer.Models
{
    public class Subdepartment
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public float AccountId { get; set; }
        public string Name { get; set; }
    }
}