using System.ComponentModel.DataAnnotations;

namespace HandheldServer.Models
{
    public enum EditListType { Always, Never, CostChange }
    public enum RedemptionType {  Ignore, IncludeInCount, SeparateLine }
    public class Delivery
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string InvoiceNumber { get; set; }
        [Required]
        public decimal TotalAmount { get; set; }
        public string VendorID { get; set; }
        [Required]
        public string Site { get; set; }
        [Required]
        public EditListType EditListOption { get; set; }
        [Required]
        public RedemptionType RedemptionOption { get; set; }
        public bool AllowNewItems { get; set; }
    }
}