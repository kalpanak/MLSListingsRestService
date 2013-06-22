using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MLSListingsRestService.Models;

namespace MLSListingsRestService.Controllers
{
    public class ZipController : ApiController
    {
        static readonly IHomeListRepository repository = new HomeListRepository();
 
        //GET api/Zip/95051
        public IEnumerable<HomeDetails> GetHomeDetailsByID(int ID)
        {
            IEnumerable<HomeDetails> HomeList = (from home in repository.GetAll() where home.Zip == ID select home);

            return HomeList;

        }
    }
}
