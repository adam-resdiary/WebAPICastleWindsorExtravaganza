using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HandheldServer.Models
{
    interface IWorkTablesRepository
    {
        IEnumerable<WorkTables> Get(int ID, int CountToFetch);
        WorkTables Add(WorkTables item);
    }
}