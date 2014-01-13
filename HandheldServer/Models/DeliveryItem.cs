using System.ComponentModel.DataAnnotations;

namespace HandheldServer.Models
{
    public class DeliveryItem
    {
        [Key]
        public int Id { get; set; }
        // InvoiceNumber is a Foreign key, linking to the "Master" Delivery record; 1..N relationship between Delivery and DeliveryItem
        [Required]
        public string InvoiceNumber { get; set; }
        [Required]
        public string UPC_PLU { get; set; }
        public string VendorItemId { get; set; }
        public int PackSize { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Cost { get; set; }
        public decimal Margin { get; set; }
        public decimal ListPrice { get; set; }
        public int DepartmentNumber { get; set; }
        public string Subdepartment { get; set; }
    }
}