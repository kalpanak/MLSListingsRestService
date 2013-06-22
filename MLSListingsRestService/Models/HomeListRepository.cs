using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;

namespace MLSListingsRestService.Models
{
    public class HomeListRepository : IHomeListRepository
    {
        private List<HomeDetails> HomeData = new List<HomeDetails>();

        private int _nextId = 1;

        public HomeListRepository()
        {
            Add(new HomeDetails {Address = "Halford Avenue", City= "Santa Clara", State="California", Zip= 95051});
            Add(new HomeDetails {Address = "North 1st Street", City= "San Jose", State="California", Zip= 95054});
            Add(new HomeDetails {Address = "Lillick Drive", City= "Santa Clara", State="California", Zip= 95051});
            Add(new HomeDetails {Address = "Wild Wood Drive", City= "St Louis", State="Missouri", Zip= 65053});
            Add(new HomeDetails {Address = "Technology Street", City = "Dallas", State = "Texas", Zip = 75022 });
        }

        public IEnumerable<HomeDetails> GetAll()
        {
            return HomeData;
        }

        public HomeDetails Get(int id)
        {
            return HomeData.Find(h => h.ID == id);
        }

        public HomeDetails Add(HomeDetails item)
        {
            //if (item == null)
            //    throw new ArgumentNullException("item");
            item.ID = _nextId++;
            HomeData.Add(item);
            return item;
        }
    }
}