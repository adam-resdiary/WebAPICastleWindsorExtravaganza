using System.Collections.Generic;
using System.Web.Http;
using HandheldServer.Models;

namespace HandheldServer.Controllers
{
    public class RedemptionsController : ApiController
    {
        static readonly IRedemptionRepository redemptionsRepository = new RedemptionRepository();

        //public IEnumerable<Redemption> GetAllRedemptions()
        //{
        //    return redemptionsRepository.GetAll();
        //}

        public int GetCountOfRedemptionRecords()
        {
            return redemptionsRepository.Get();
        }

        public IEnumerable<Redemption> GetBatchOfRedemptionsByStartingID(int ID, int CountToFetch)
        {
            return redemptionsRepository.Get(ID, CountToFetch);
        }

    }
}
