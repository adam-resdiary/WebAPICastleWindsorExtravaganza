using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Reflection;
using System.Linq;
using System.Web.UI.WebControls;
using log4net;
using WebGrease.Css.Ast.Selectors;

namespace HandheldServer.Models
{
    public class InventoryItemRepository : IInventoryItemRepository
    {
        private readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly List<InventoryItem> inventoryItems = new List<InventoryItem>();

        public InventoryItemRepository()
        {
            //string lastGoodId = string.Empty;
            string id = string.Empty;

            try
            {
                using (var conn = new OleDbConnection(
                      @"Provider=Microsoft.ACE.OLEDB.12.0;User ID=DuckbilledPlatypus;Password=SSCSBO;Data Source=C:\CDBWin\DATA\CDBDAT03.MDB;Jet OLEDB:System database=C:\CDBWin\Data\sscs.mdw"))
                {
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText =
                              "SELECT id, pack_size, description, department, subdepartment, unit_cost, unit_list, UPC_code, UPC_pack_size, crv_id FROM t_inv ORDER BY id, pack_size";
                        cmd.CommandType = CommandType.Text;
                        conn.Open();
                        using (OleDbDataReader oleDbD8aReader = cmd.ExecuteReader())
                        {
                            while (oleDbD8aReader.Read())
                            {
                                //lastGoodId = id;
                                id = (oleDbD8aReader["id"] is DBNull ? "" : oleDbD8aReader["id"].ToString());
                                int packSize = (oleDbD8aReader["pack_size"] is DBNull ? 0 : Convert.ToInt16(oleDbD8aReader["pack_size"]));
                                string desc = (oleDbD8aReader["description"] is DBNull ? "" : oleDbD8aReader["description"].ToString());
                                int dept = (oleDbD8aReader["department"] is DBNull ? 0 : Convert.ToInt16(oleDbD8aReader["department"]));
                                int subDept = (oleDbD8aReader["subdepartment"] is DBNull ? 0 : Convert.ToInt16(oleDbD8aReader["subdepartment"]));
                                //string deptSubdept = string.Format("{0}.{1}", dept, subDept);
                                //double deptSubdeptCombo;
                                //double.TryParse(deptSubdept, out deptSubdeptCombo);
                                double unitCost = (oleDbD8aReader["unit_cost"] is DBNull ? 0.00 : Convert.ToDouble(oleDbD8aReader["unit_cost"]));
                                double unitList = (oleDbD8aReader["unit_list"] is DBNull ? 0.00 : Convert.ToDouble(oleDbD8aReader["unit_list"]));
                                string UPC_Code = (oleDbD8aReader["UPC_code"] is DBNull ? "" : oleDbD8aReader["UPC_code"].ToString());
                                int UPC_PackSize = (oleDbD8aReader["UPC_pack_size"] is DBNull ? 0 : Convert.ToInt16(oleDbD8aReader["UPC_pack_size"]));
                                int CRV_id = (oleDbD8aReader["crv_id"] is DBNull ? 0 : Convert.ToInt32(oleDbD8aReader["crv_id"]));

                                Add(new InventoryItem
                                {
                                    // OLD:
                                    //Id = id,
                                    //PackSize = packSize,
                                    //Description = desc,
                                    //DeptDotSubdept = deptSubdeptCombo,
                                    //Unit_Cost = unitCost,
                                    //Unit_List = unitList,
                                    //UPC_code = UPC_Code,
                                    //UPC_pack_size = UPC_PackSize,
                                    //CRV_Id = CRV_id

                                    // 
                                    //public string ID { get; set; }
                                    //public int pksize { get; set; }
                                    //public string Description { get; set; }
                                    //public string vendor_id { get; set; }
                                    ////public double DeptDotSubdept { get; set; } // This will be "faked" on the client, I guess, by concatenating (dept + '.' + subdept).
                                    //public double UnitCost { get; set; }
                                    //public double UnitList { get; set; }
                                    //public double Qty { get; set; }
                                    //public string UPC { get; set; }
                                    //public int dept { get; set; }
                                    //public int subdept { get; set; }
                                    //public int upc_pack_size { get; set; }
                                    //public string vendor_item { get; set; }
                                    //public int crv_id { get; set; }
                                    ID = id,
                                    pksize = packSize,
                                    Description = desc,
                                    vendor_id = "vendor_id",     // Placeholder value; will this have to be queried separately?
                                    UnitCost = unitCost,
                                    UnitList = unitList,
                                    Qty = 1.2,                   // Placeholder value; where will this come from?
                                    UPC = UPC_Code,
                                    dept = dept,
                                    subdept = subDept,
                                    upc_pack_size = UPC_PackSize,
                                    vendor_item = "vendor_item", // Placeholder value; will this have to be queried separately?
                                    crv_id = CRV_id
                                });
                            } // while
                        } // using (OleDbDataReader
                    } // using (var cmd
                } // using (var conn
            } // try
            catch (Exception ex)
            {
                log.Error(string.Format("last ID was {0}; {1}", id, ex.Message));
            }
        } // InventoryItemRepository (constructor)

        public IEnumerable<InventoryItem> Get(string ID, int CountToFetch)
        {
            return inventoryItems.Where(i => 0 < String.Compare(i.ID, ID)).Take(CountToFetch);
        }

        public IEnumerable<InventoryItem> Get(string ID, int packSize, int CountToFetch)
        {
            // Extrapolated/adapted from http://stackoverflow.com/questions/20060781/what-linq-do-i-need-for-this-rather-involved-logic/20067740?noredirect=1#20067740
            //return inventoryItems
            //    .Where(i => (i.Id.CompareTo(ID) == 0 && i.PackSize > packSize) || i.Id.CompareTo(ID) > 0)
            //    .Take(CountToFetch);
            return inventoryItems
               .Where(i => (i.ID.CompareTo(ID) == 0 && i.pksize > packSize) || i.ID.CompareTo(ID) > 0)
               .Take(CountToFetch);
        }

        public InventoryItem Get(int id)
        {
            return inventoryItems.Find(i => 0 == (String.Compare(i.ID, id.ToString())));
        }

        public int Get()
        {
            return inventoryItems.Count;
        }

        //public InventoryItem Add(InventoryItem item)
        //{
        //    if (item == null)
        //    {
        //        throw new ArgumentNullException("item");
        //    }
        //    inventoryItems.Add(item);
        //    return item;
        //    // If wanted to also permanently add the record, would need to have an INSERT statement for Access here also
        //}

        // I don't think we'd ever need to get the just-added item back, as was originally done above (apparently when adapting from an example found online)
        public void Add(InventoryItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            inventoryItems.Add(item);
            // If want to also "permanently" add the record, would need to have an INSERT statement for Access here also
        }

        public bool Update(InventoryItem item) // possibly better named "Put" as MVC/Web API allows "convention over configuration"
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = inventoryItems.FindIndex(i => i.ID == item.ID);
            if (index == -1)
            {
                return false;
            }
            inventoryItems.RemoveAt(index);
            inventoryItems.Add(item);
            return true;
            // If want to also "permanently" update the record, would need to have an UPDATE statement for Access here also
        }

    }
}