using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HandheldServer.Models;
using System.Linq;

namespace HandheldServer.Controllers
{
    public class DepartmentsController : ApiController
    {
        //static readonly IDepartmentRepository deptsRepository = new DepartmentRepository();
        //static IDepartmentRepository _deptsRepository;
        private readonly IDepartmentRepository _deptsRepository;

        public DepartmentsController(IDepartmentRepository deptsRepository)
        {
            if (deptsRepository == null)
            {
                throw new ArgumentNullException("deptsRepository is null");
            }
            _deptsRepository = deptsRepository;
        }

        [Route("api/Departments/Count")]
        public int GetCountOfDepartmentRecords()
        {
            return _deptsRepository.Get();
        }

        [Route("api/Departments")]
        public IEnumerable<Department> GetBatchOfDepartmentsByStartingID(int ID, int CountToFetch)
        {
            return _deptsRepository.Get(ID, CountToFetch);
        }

        //public HttpResponseMessage PostDepartment(Department department)
        //public HttpResponseMessage PostDepartment(int id, int accountid, string name)
        //public HttpResponseMessage PostDepartment(int accountid, string name)
        public void PostDepartment(int accountid, string name)
        {
            ////int ID = deptsRepository.
            //Department dept = new Department { 
            //    //Id = id,
            //    AccountId = accountid,
            //    Name = name
            //};
            ////department = deptsRepository.Add(department);
            ////dept = deptsRepository.Add(dept);
            _deptsRepository.PostDepartment(accountid, name);
            //var response = Request.CreateResponse(HttpStatusCode.Created, dept);
            //// I don't know if the rest of this is necessary
            //string uri = Url.Link("DefaultApi", new { id = dept.Id });
            //response.Headers.Location = new Uri(uri);
            //return response;
        }

        //public void Post(Department department)
        public HttpResponseMessage Post(Department department)
        {
            ////department = deptsRepository.Add(department);
            ////deptsRepository.Add(department);
            //deptsRepository.Post(department); // <--changed to this; test it

            // Based on code 2/3 down http://www.codeproject.com/Articles/344078/ASP-NET-WebAPI-Getting-Started-with-MVC4-and-WebAP?msg=4727042#xx4727042xx
            department = _deptsRepository.Add(department);
            var response = Request.CreateResponse<Department>(HttpStatusCode.Created, department);
            string uri = Url.Route(null, new { id = department.Id });
            response.Headers.Location = new Uri(Request.RequestUri, uri);
            return response;
        }

        //public void Put(Department department)
        //{
        //    deptsRepository.Put(department);
        //}

        public void PutDepartment(int id, Department dept)
        {
            dept.Id = id;
            // TODO: Find via Id, Delete, Add dept passed in
            //if (!deptsRepository.Update(dept))
            //{
            //    //throw new HttpResponseException(HttpStatusCode.NotFound);
            //    throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            //}
        }

        public HttpResponseMessage DeleteDepartment(int id)
        {
            //deptsRepository.Remove(id);
            // TODO: Replace with code elsewhere in the project
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

    }
}
