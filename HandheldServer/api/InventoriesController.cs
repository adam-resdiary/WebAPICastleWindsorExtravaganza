using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HandheldServer.Models;

namespace HandheldServer.Controllers
{
    public class InventoriesController : ApiController
    {
        static readonly IInventoryRepository inventoryRepository = new InventoryRepository();

        public HttpResponseMessage PostInventory(Inventory inventory)
        {
            inventory = inventoryRepository.Add(inventory);
            var response = Request.CreateResponse(HttpStatusCode.Created, inventory);

            string uri = Url.Link("DefaultApi", new { id = inventory.Id });
            if (uri != null) response.Headers.Location = new Uri(uri);
            return response;
        }
    }
}
