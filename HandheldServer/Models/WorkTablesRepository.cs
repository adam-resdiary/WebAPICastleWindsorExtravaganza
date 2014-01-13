using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HandheldServer.Models
{
    public class WorkTablesRepository : IWorkTablesRepository
    {
        private readonly List<WorkTables> workTables = new List<WorkTables>();

        public WorkTablesRepository()
        {
            // This will be replaced by the actual data access, querying MS SQL Server
            Add(new WorkTables { Id = 2, Name = "Name that tune", fileType = "XML file", totalItems = 42, totalAmt = 42.76, siteNo = 3, fileDate ="December 16, 2013" });
            Add(new WorkTables { Id = 4, Name = "Name that tune, dude", fileType = "CSV file", totalItems = 44, totalAmt = 41.76, siteNo = 1, fileDate ="December 17, 2013" });
            Add(new WorkTables { Id = 6, Name = "Name that tune, dudette", fileType = "JSON file", totalItems = 46, totalAmt = 43.76, siteNo = 2, fileDate ="December 18, 2013" });
            Add(new WorkTables { Id = 8, Name = "That's the name of that tune", fileType = "Text file", totalItems = 48, totalAmt = 44.76, siteNo = 1, fileDate ="December 19, 2013" });
            Add(new WorkTables { Id = 10, Name = "Play it again, Sam", fileType = "XLS file", totalItems = 52, totalAmt = 45.76, siteNo = 3, fileDate ="December 20, 2013" });
            Add(new WorkTables { Id = 12, Name = "This is the last song", fileType = "DOC file", totalItems = 62, totalAmt = 46.76, siteNo = 2, fileDate ="December 23, 2013" });
        }

        public IEnumerable<WorkTables> Get(int ID, int CountToFetch)
        {
            return workTables.Where(i => i.Id > ID).Take(CountToFetch);
        }

        // This can be removed once the constructor gets actual data
        public WorkTables Add(WorkTables item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("work tables item null");
            }
            workTables.Add(item);
            return item;
        }
    }
}