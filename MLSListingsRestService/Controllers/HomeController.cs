using MLSListingsRestService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml;

namespace MLSListingsRestService.Controllers
{
    public class HomeController : ApiController
    {
        static readonly IHomeListRepository repository = new HomeListRepository();

        //GET api/Home
        public IEnumerable<HomeDetails> GetAllHomes()
        {
            return repository.GetAll();
        }

        //GET api/Home/1
        public HomeDetails GetHomeDetailsByID(int ID)
        {
            HomeDetails item = repository.Get(ID);
            return item;
        }

        //POST api/Home
        public HttpResponseMessage PostHomeDetails(HomeDetails item)
        {
            item = repository.Add(item);
            var response = Request.CreateResponse<HomeDetails>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.ID });
            response.Headers.Location = new Uri(uri);
            return response;
        }

    }
}
