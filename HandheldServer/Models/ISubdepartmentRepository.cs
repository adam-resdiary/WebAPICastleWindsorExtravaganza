using System.Collections.Generic;

namespace HandheldServer.Models
{
    interface ISubdepartmentRepository
    {
        int Get();
        IEnumerable<Subdepartment> Get(int ID, int CountToFetch);
        Subdepartment Add(Subdepartment item); 
    }
}
