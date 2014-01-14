using System.Collections.Generic;
using System.Web.Http;
using HandheldServer.Models;

namespace HandheldServer.Controllers
{
    public class InventoryItemsController : ApiController
    {
        static readonly IInventoryItemRepository inventoryItemsRepository = new InventoryItemRepository();

        public int GetCountOfInventoryItems()
        {
            return inventoryItemsRepository.Get();
        }

        //[HttpGet]
        //[Route("GetAll", RouteOrder = 1)]
        //public IEnumerable<InventoryItem> GetAllInventoryItems()
        //{
        //    return inventoryItemsRepository.GetAll();
        //}

        //[HttpGet]
        //[Route("api/{controller}/{ID:string}/{CountToFetch:int}")] <-- throws exception - won't run
        //[Route("{controller}/{ID:string}/{CountToFetch:int}")] <-- throws exception - won't run
        //[Route("inventoryItems/{ID:string}/{CountToFetch:int}")] <-- throws exception - won't run
        //[Route("api/inventoryItems/{ID:string}/{CountToFetch:int}")] <-- throws exception - won't run
        //[Route("api/{controller}/{ID}/{CountToFetch}")] // <-- runs, but is not called
        //[Route("api/inventoryItems/{ID}/{CountToFetch}")] // <-- runs, but is not called
        //[Route("api/InventoryItems/{ID}/{CountToFetch}")]
        //[Route("api/InventoryItems/{ID}/{CountToFetch:int}")]
        //[Route("api/{controller}/{ID:string}/{CountToFetch:int}")] <-- throws exception - won't run
        //[Route("api/inventoryItems/{ID:string}/{CountToFetch:int}")] 
        public IEnumerable<InventoryItem> GetBatchOfInventoryItemsByStartingID(string ID, int CountToFetch)
        {
            return inventoryItemsRepository.Get(ID, CountToFetch);
        }

        public IEnumerable<InventoryItem> GetBatchOfInventoryItemsByStartingID(string ID, int packSize, int CountToFetch)
        {
            return inventoryItemsRepository.Get(ID, packSize, CountToFetch);
        }

        //public HttpResponseMessage PostInventoryItem(InventoryItem inventoryItem)
        //{
        //    inventoryItem = inventoryItemsRepository.Add(inventoryItem);
        //    var response = Request.CreateResponse(HttpStatusCode.Created, inventoryItem);

        //    string uri = Url.Link("DefaultApi", new { id = inventoryItem.Id });
        //    if (uri != null) response.Headers.Location = new Uri(uri);
        //    return response;
        //}

        // Some ideas from Charlie's "Practical ASP.NET Web API":
        // POST api/InventoryItems
        public void Post(InventoryItem invItem)
        {
            string maxId = "42"; //inventoryItemsRepository.Max(i => i.Id);
            invItem.ID = maxId + 1;
            inventoryItemsRepository.Add(invItem);
        }

        public void Put(int id, InventoryItem invItem)
        {
            //int index = ist.ToList().FindIndex(i => i.Id == id);
            //list[index] = invItem;
        }

        public void Delete(int id)
        {
            //InventoryItem invItem = Get(id);
            //list.Remove(invItem);
        }
    }
}
