using System.ComponentModel.DataAnnotations;

namespace HandheldServer.Models
{
    // The data that comes across (from the XML file) does not have an "Id" value; this is added so that the data can be ordered and looped through from the client
    public class Department
    {   
        public int Id { get; set; }
        [Required]
        public int AccountId { get; set; }
        [Required] 
        public string Name { get; set; }
    }
}