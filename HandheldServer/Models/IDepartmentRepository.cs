using System.Collections.Generic;

namespace HandheldServer.Models
{
    public interface IDepartmentRepository
    {
        int Get();
        IEnumerable<Department> Get(int ID, int CountToFetch);
        Department Add(Department item);
        void Post(Department dept);
        void PostDepartment(int accountid, string name);
        void Put(Department dept);
        void Delete(int Id);
    }
}
