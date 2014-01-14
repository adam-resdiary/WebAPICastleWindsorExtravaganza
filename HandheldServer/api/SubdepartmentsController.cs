using System.Collections.Generic;
using System.Web.Http;
using HandheldServer.Models;

namespace HandheldServer.Controllers
{
    public class SubdepartmentsController : ApiController
    {
        static readonly ISubdepartmentRepository subdepartmentsRepository = new SubdepartmentRepository();

        //public IEnumerable<Subdepartment> GetAllSubdepartments()
        //{
        //    return subdepartmentsRepository.GetAll();
        //}

        public int GetCountOfSubdepartmentRecords()
        {
            return subdepartmentsRepository.Get();
        }

        public IEnumerable<Subdepartment> GetBatchOfSubdpartmentsByStartingID(int ID, int CountToFetch)
        {
            return subdepartmentsRepository.Get(ID, CountToFetch);
        }

    }
}
