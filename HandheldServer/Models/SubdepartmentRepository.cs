using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Reflection;
using log4net;

namespace HandheldServer.Models
{
    public class SubdepartmentRepository : ISubdepartmentRepository
    {
        private readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly List<Subdepartment> subdepartments = new List<Subdepartment>();

        public SubdepartmentRepository()
        {
            try
            {
                using (var conn = new OleDbConnection(
                      @"Provider=Microsoft.ACE.OLEDB.12.0;User ID=DuckbilledPlatypus;Password=SSCSBO;Data Source=C:\CDBWin\DATA\CDBDAT03.MDB;Jet OLEDB:System database=C:\CDBWin\Data\sscs.mdw"))
                {
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT dept_no, subdepartment, name FROM t_subdepartments ORDER BY dept_no, subdepartment";
                        cmd.CommandType = CommandType.Text;
                        conn.Open();
                        int i = 1;
                        using (OleDbDataReader oleDbD8aReader = cmd.ExecuteReader())
                        {
                            while (oleDbD8aReader != null && oleDbD8aReader.Read())
                            {
                                int deptId = oleDbD8aReader.GetInt16(0);
                                int subdeptId = oleDbD8aReader.GetInt16(1);
                                double deptIDDotSubdeptID = Convert.ToDouble(string.Format("{0}.{1}", deptId, subdeptId));
                                string subdeptName = oleDbD8aReader.GetString(2);
                                Add(new Subdepartment
                                {
                                    Id = i,
                                    AccountId = (float)deptIDDotSubdeptID,
                                    Name = subdeptName
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
            return subdepartments.Count;
        }

        public IEnumerable<Subdepartment> Get(int ID, int CountToFetch)
        {
            return subdepartments.Where(i => i.Id > ID).Take(CountToFetch);
        }

        //public IEnumerable<Subdepartment> GetAll()
        //{
        //    return subdepartments;
        //}

        // This can be removed once the constructor gets actual data
        public Subdepartment Add(Subdepartment item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Subdepartment item is null");
            }
            subdepartments.Add(item);
            return item;
        }

    }
}