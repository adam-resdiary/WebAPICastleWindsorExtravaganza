using System.Collections.Generic;

namespace HandheldServer.Models
{
    interface IRedemptionRepository
    {
        int Get();
        IEnumerable<Redemption> Get(int ID, int CountToFetch);
        Redemption Add(Redemption item);
    }
}
