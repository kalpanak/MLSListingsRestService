using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace MLSListingsRestService.Models
{
    interface IHomeListRepository
    {
        IEnumerable<HomeDetails> GetAll();

        HomeDetails Get(int id);

        HomeDetails Add(HomeDetails item);
    }
}