using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HandheldServer.Models;

namespace HandheldServer.Controllers
{
    public class DeliveriesController : ApiController
    {
        static readonly IDeliveryRepository deliveryRepository = new DeliveryRepository();

        public HttpResponseMessage PostDelivery(Delivery delivery)
        {
            delivery = deliveryRepository.Add(delivery);
            var response = Request.CreateResponse(HttpStatusCode.Created, delivery);

            string uri = Url.Link("DefaultApi", new { id = delivery.Id });
            if (uri != null) response.Headers.Location = new Uri(uri);
            return response;
        }

        // The commented out code below may never be used; these are the other CRUD operations: C[reate] is PostDelivery() above;
        // R[ead] is GetAllDeliverys(), GetDelivery(int id), and GetDeliveryByCategory(string deliveryName); 
        // U[pdate] is PutDelivery(int id, Delivery delivery); D[elete] is DeleteDelivery(int id)

        //public IEnumerable<Delivery> GetAllDeliveries()
        //{
        //    //return deliveryRepository.
        //}

        //public Delivery GetDelivery(int id)
        //{
        //    Delivery delivery = repository.Get(id);
        //    if (delivery == null)
        //    {
        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    }
        //    return delivery;
        //}

        //// Can test this via: http://localhost:48614/api/Deliverys?deliveryName=delivery7
        //public IEnumerable<Delivery> GetDeliveryByCategory(string deliveryName)
        //{
        //    return repository.GetAll().Where(
        //        p => string.Equals(p.deliveryName, deliveryName, StringComparison.OrdinalIgnoreCase));
        //}

        //public void PutDelivery(int id, Delivery delivery)
        //{
        //    delivery.Id = id;
        //    if (!repository.Update(delivery))
        //    {
        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    }
        //}

        //public void DeleteDelivery(int id)
        //{
        //    Delivery item = repository.Get(id);
        //    if (item == null)
        //    {
        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    }
        //    repository.Remove(id);
        //}

    }
}
