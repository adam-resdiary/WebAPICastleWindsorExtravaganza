using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HandheldServer.Models;

namespace HandheldServer.Controllers
{
    public class DeliveryItemsController : ApiController
    {
        static readonly IDeliveryItemRepository deliveryItemRepository = new DeliveryItemRepository();

        //// For model validation, see http://www.asp.net/web-api/overview/formats-and-model-binding/model-validation-in-aspnet-web-api
        public HttpResponseMessage PostDeliveryItem(DeliveryItem deliveryItem)
        {
            deliveryItem = deliveryItemRepository.Add(deliveryItem);
            var response = Request.CreateResponse(HttpStatusCode.Created, deliveryItem);

            string uri = Url.Link("DefaultApi", new { id = deliveryItem.Id });
            if (uri != null) response.Headers.Location = new Uri(uri);
            return response;
        }

        // These are what are added when selecting "Add empty read/write actions ("empty" meaning: No Entity Framework)"; see commented out
        // portion of DeliveriesController for other commented out possibilities
        // GET api/deliveryitems
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/deliveryitems/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/deliveryitems
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/deliveryitems/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/deliveryitems/5
        //public void Delete(int id)
        //{
        //}
    }
}