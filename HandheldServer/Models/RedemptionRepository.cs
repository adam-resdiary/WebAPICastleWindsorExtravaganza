using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Reflection;
using log4net;

namespace HandheldServer.Models
{
    public class RedemptionRepository : IRedemptionRepository
    {
        private readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly List<Redemption> redemptions = new List<Redemption>();

        public RedemptionRepository()
        {
            try
            {
                using (var conn = new OleDbConnection(
                      @"Provider=Microsoft.ACE.OLEDB.12.0;User ID=DuckbilledPlatypus;Password=SSCSBO;Data Source=C:\CDBWin\DATA\CDBDAT03.MDB;Jet OLEDB:System database=C:\CDBWin\Data\sscs.mdw"))
                {
                    using (var cmd = conn.CreateCommand())
                    {
                        //cmd.CommandText = "SELECT t_crv.crv_id AS [Redemption ID], t_crv.name AS Name, t_crv.amount AS Amount, t_crv.inv_id AS [Linked ID] FROM t_crv ORDER BY t_crv.crv_id";
                        cmd.CommandText = "SELECT crv_id, name, amount, inv_id FROM t_crv ORDER BY crv_id";
                        cmd.CommandType = CommandType.Text;
                        conn.Open();
                        int i = 1;
                        using (OleDbDataReader oleDbD8aReader = cmd.ExecuteReader())
                        {
                            while (oleDbD8aReader.Read())
                            {
                                //string RedemName = (oleDbD8aReader["name"] is DBNull ? string.Empty : (String)oleDbD8aReader["name"]);
                                //long RedemItemId = (oleDbD8aReader["crv_id"] is DBNull ? 0 : (long)oleDbD8aReader["crv_id"]);
                                //double RedemAmount = (oleDbD8aReader["amount"] is DBNull ? 0 : (Double)oleDbD8aReader["amount"]);
                                //string RedemId = (oleDbD8aReader["inv_id"] is DBNull ? string.Empty : (String)oleDbD8aReader["inv_id"]);
                                string RedemName = (oleDbD8aReader["name"] is DBNull ? string.Empty : oleDbD8aReader["name"].ToString());
                                long RedemItemId = (oleDbD8aReader["crv_id"] is DBNull ? 0 : Convert.ToInt64(oleDbD8aReader["crv_id"])); // changed from (long) to Convert.ToInt64(); see http://msdn.microsoft.com/en-us/library/ctetwysk.aspx and http://stackoverflow.com/questions/19594236/what-is-the-safest-practical-way-to-deal-with-non-required-ms-access-text-fields
                                double RedemAmount = (oleDbD8aReader["amount"] is DBNull ? 0 : Convert.ToDouble(oleDbD8aReader["amount"]));
                                string RedemId = (oleDbD8aReader["inv_id"] is DBNull ? string.Empty : oleDbD8aReader["inv_id"].ToString());
                                const int RedemDept = 42; //(oleDbD8aReader["name"] is DBNull ? string.Empty : (String)oleDbD8aReader["name"]);
                                const int RedemSubDept = 42; //(oleDbD8aReader["name"] is DBNull ? string.Empty : (String)oleDbD8aReader["name"]);
                                Add(new Redemption
                                {
                                    //Id = RedemItemId, RedemptionId = RedemId, RedemptionName = RedemName, RedemptionItemId = RedemItemId.ToString(), RedemptionAmount = RedemAmount, RedemptionDept = RedemDept, RedemptionSubDept = RedemSubDept 
                                    //Id = i, RedemptionId = RedemId, RedemptionName = RedemName, RedemptionItemId = RedemItemId.ToString(), RedemptionAmount = RedemAmount, RedemptionDept = RedemDept, RedemptionSubDept = RedemSubDept 
                                    Id = i, RedemptionID = RedemId, Name = RedemName, ItemID = RedemItemId.ToString(), Amount = RedemAmount, Department = RedemDept, Subdepartment = RedemSubDept
                                });
                                i++;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        public int Get()
        {
            return redemptions.Count;
        }

        public IEnumerable<Redemption> Get(int ID, int CountToFetch)
        {
            return redemptions.Where(i => i.Id > ID).Take(CountToFetch);
        }

        // This can be removed once the constructor gets actual data
        public Redemption Add(Redemption item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            redemptions.Add(item);
            return item;
        }

    }
}