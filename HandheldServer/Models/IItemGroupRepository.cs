using System.Collections.Generic;

namespace HandheldServer.Models
{
    interface IItemGroupRepository
    {
        IEnumerable<ItemGroup> Get(int ID, int CountToFetch);
        ItemGroup Add(ItemGroup item);
    }
}
