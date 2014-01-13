using System.ComponentModel.DataAnnotations;

namespace HandheldServer.Models
{
    public class Redemption
    {
        //[Key]
        //public long Id { get; set; }
        //[Required]
        //public string RedemptionId { get; set; }
        //[Required]
        //public string RedemptionName { get; set; }
        //[Required]
        //public string RedemptionItemId { get; set; }
        //[Required]
        //public double RedemptionAmount { get; set; }
        //public string RedemptionDept { get; set; }
        //public string RedemptionSubDept { get; set; }
        
        [Key]
        public long Id { get; set; }
        public string RedemptionID;
        public string Name;
        public string ItemID;
        public double Amount;
        public int Department;
        public int Subdepartment;
    }
}