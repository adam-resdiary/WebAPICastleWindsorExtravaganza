using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HandheldServer.Models;

namespace HandheldServer.Controllers
{
    public class WorkTablesController : ApiController
    {
        static readonly IWorkTablesRepository workTablesRepository = new WorkTablesRepository();

        public IEnumerable<WorkTables> GetBatchOfWorkTablesByStartingID(int ID, int CountToFetch)
        {
            return workTablesRepository.Get(ID, CountToFetch);
        } 

    }
}
