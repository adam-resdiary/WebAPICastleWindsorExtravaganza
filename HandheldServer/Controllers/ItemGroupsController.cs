using System.Collections.Generic;
using System.Web.Http;
using HandheldServer.Models;

namespace HandheldServer.Controllers
{
    public class ItemGroupsController : ApiController
    {
        static readonly IItemGroupRepository itemGroupsRepository = new ItemGroupRepository();

        public IEnumerable<ItemGroup> GetBatchOfItemGroupsByStartingID(int ID, int CountToFetch)
        {
            return itemGroupsRepository.Get(ID, CountToFetch);
        } 


    }
}
