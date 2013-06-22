using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Xml;
using System.Xml.Linq;
using System.Configuration;

namespace MLSListingsRestService.Models
{
    public class HomeListRepository : IHomeListRepository
    {
        private string DataSourceFile()
        {
            return ConfigurationManager.AppSettings["DataSource"];
        }

        private List<HomeDetails> HomeData = new List<HomeDetails>();

        public HomeListRepository()
        {
            XDocument doc = XDocument.Load(DataSourceFile());
            XElement HomeElement = doc.Element("Details");
            HomeData = (from c in HomeElement.Descendants("HomeDetails")
                        select new HomeDetails()
                                    {
                                        ID = Convert.ToInt16(c.Element("ID").Value),
                                        Address = c.Element("Address").Value.ToString(),
                                        City = c.Element("City").Value.ToString(),
                                        State = c.Element("State").Value.ToString(),
                                        Zip = Convert.ToInt64(c.Element("Zip").Value)
                                    }).ToList<HomeDetails>();
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
            HomeData.Add(item);

            using (XmlWriter writer = XmlWriter.Create(DataSourceFile()))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Details");

                foreach (HomeDetails home in HomeData)
                {
                    writer.WriteStartElement("HomeDetails");

                    writer.WriteElementString("ID", home.ID.ToString());
                    writer.WriteElementString("Address", home.Address);
                    writer.WriteElementString("City", home.City);
                    writer.WriteElementString("State", home.State);
                    writer.WriteElementString("Zip", home.Zip.ToString());

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }

            return item;
        }

    }
}