using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;

namespace HandheldServer.Models
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly List<Department> departments = new List<Department>();

        public DepartmentRepository()
        {
            using (var conn = new OleDbConnection(
                @"Provider=Microsoft.ACE.OLEDB.12.0;User ID=DuckbilledPlatypus;Password=SSCSBO;Data Source=C:\CDBWin\DATA\CDBDAT03.MDB;Jet OLEDB:System database=C:\CDBWin\Data\sscs.mdw"))
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT td_department_accounts.dept_no, IIF(ISNULL(t_accounts.name),'No Name provided',t_accounts.name) AS name FROM t_accounts INNER JOIN td_department_accounts ON t_accounts.account_no = td_department_accounts.account_no ORDER BY td_department_accounts.dept_no";
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    int i = 1;
                    using (OleDbDataReader oleDbD8aReader = cmd.ExecuteReader())
                    {
                        while (oleDbD8aReader != null && oleDbD8aReader.Read())
                        {
                            int deptNum = oleDbD8aReader.GetInt16(0);
                            string deptName = oleDbD8aReader.GetString(1);
                            Add(new Department { Id = i, AccountId = deptNum, Name = deptName });
                            // Or, more succinctly, although perhaps less grokkable, could do this:
                            //Add(new Department { Id = i, AccountId = oleDbD8aReader.GetInt16(0), Name = oleDbD8aReader.GetString(1) });
                            i++;
                        }
                    }
                }
            }
        }

        public int Get()
        {
            return departments.Count;
        }

        private Department Get(int ID) // called by Delete()
        {
            return departments.First(d => d.Id == ID);
        }

        public IEnumerable<Department> Get(int ID, int CountToFetch)
        {
            return departments.Where(i => i.Id > ID).Take(CountToFetch);
        }

        public Department Add(Department dept)
        {
            if (dept == null)
            {
                throw new ArgumentNullException("Department arg was null");
            }
            // This is called internally, so need to disregard Id vals that already exist
            if (dept.Id <= 0)
            {
                int maxId = departments.Max(d => d.Id);
                dept.Id = maxId + 1;
            }
            if (departments != null) departments.Add(dept);
            return dept;
        }

        public void PostDepartment(int accountid, string name)
        {
            int maxId = departments.Max(d => d.Id);
            Department dept = new Department();
            dept.Id = maxId + 1;
            dept.AccountId = accountid;
            dept.Name = name;
            departments.Add(dept);
        }

        public void Post(Department department)
        {
            int maxId = departments.Max(d => d.Id);
            department.Id = maxId + 1;
            departments.Add(department);
        }

        public void Put(Department department)
        {
            int index = departments.ToList().FindIndex(p => p.Id == department.Id);
            departments[index] = department;
        }

        public void Put(int id, Department department)
        {
            int index = departments.ToList().FindIndex(p => p.Id == id);
            departments[index] = department;
        }

        public void Delete(int id)
        {
            Department dept = Get(id);
            departments.Remove(dept);
        }

    }
}