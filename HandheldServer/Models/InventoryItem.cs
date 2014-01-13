namespace HandheldServer.Models
{
    public class InventoryItem
    {
        // old:
        //public string Id { get; set; }
        //public int PackSize { get; set; }
        //public string Description { get; set; }
        //public double DeptDotSubdept { get; set; }
        //public double Unit_Cost { get; set; }
        //public double Unit_List { get; set; }
        //public string UPC_code { get; set; }
        //public int UPC_pack_size { get; set; }
        //public int CRV_Id { get; set; }

        // DDL from InvFile.cs in HHS (client)
        //CREATE TABLE inventory (ID NVARCHAR(19) NOT NULL," +
        //               " pksize INT, Description NVARCHAR(35), vendor_id NVARCHAR(10)," +
        //               " UnitCost FLOAT, UnitList FLOAT, Qty FLOAT, UPC NVARCHAR(19)," +
        //               " dept INT, subdept INT, upc_pack_size INT, vendor_item NVARCHAR(12), crv_id NVARCHAR(19)

        public string ID { get; set; }
        public int pksize { get; set; }
        public string Description { get; set; }
        public string vendor_id { get; set; }
        //public double DeptDotSubdept { get; set; } // This will be "faked" on the client, I guess, by concatenating (dept + '.' + subdept).
        public double UnitCost { get; set; }
        public double UnitList { get; set; }
        public double Qty { get; set; }
        public string UPC { get; set; }
        public int dept { get; set; }
        public int subdept { get; set; }
        public int upc_pack_size { get; set; }
        public string vendor_item { get; set; }
        public int crv_id { get; set; }
    }
}