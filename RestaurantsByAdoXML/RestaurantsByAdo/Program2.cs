//using System;
//using System.Linq;
//using System.Xml.Linq;

//namespace Demo
//{
//    class Program2
//    {
//        public static void Main()
//        {
//            XDocument xmlDocument = XDocument.Load(@"C:\repos\CodeSmart-Intern-Training\RestaurantsByAdoXML\RestaurantsByAdo\XMLFile.xml");

//            XDocument result = new XDocument(
//                new XElement("Restaurants",
//                new XElement("RestaurantName",
//                       from s in xmlDocument.Descendants("Restaurant")
//                       where s.Element("RestaurantName").Value == "Priya"
//                       select new XElement("Restaurant",
//                       new XElement("CuisineType", s.Element("CuisineType").Value),
//                       new XElement("City", s.Element("City").Value),
//                       new XElement("Rating", s.Element("Rating").Value),
//                       new XElement("Contact", s.Element("Contact").Value)
//                       )),
//                 new XElement("RestaurantName",
//                       from s in xmlDocument.Descendants("Restaurant")
//                       where s.Element("RestaurantName").Value == "BestBuffet"
//                       select new XElement("Restaurant",
//                       new XElement("CuisineType", s.Element("CuisineType").Value),
//                       new XElement("City", s.Element("City").Value),
//                       new XElement("Rating", s.Element("Rating").Value),
//                       new XElement("Contact", s.Element("Contact").Value)
//                       )),
//                  new XElement("RestaurantName",
//                       from s in xmlDocument.Descendants("Restaurant")
//                       where s.Element("RestaurantName").Value == "GarlicGarden"
//                       select new XElement("Restaurant",
//                       new XElement("CuisineType", s.Element("CuisineType").Value),
//                       new XElement("City", s.Element("City").Value),
//                       new XElement("Rating", s.Element("Rating").Value),
//                       new XElement("Contact", s.Element("Contact").Value)
//                       )),
//                   new XElement("RestaurantName",
//                       from s in xmlDocument.Descendants("Restaurant")
//                       where s.Element("RestaurantName").Value == "Mayan"
//                       select new XElement("Restaurant",
//                       new XElement("CuisineType", s.Element("CuisineType").Value),
//                       new XElement("City", s.Element("City").Value),
//                       new XElement("Rating", s.Element("Rating").Value),
//                       new XElement("Contact", s.Element("Contact").Value)
//                       )),
//                    new XElement("RestaurantName",
//                       from s in xmlDocument.Descendants("Restaurant")
//                       where s.Element("RestaurantName").Value == "GrainBread"
//                       select new XElement("Restaurant",
//                       new XElement("CuisineType", s.Element("CuisineType").Value),
//                       new XElement("City", s.Element("City").Value),
//                       new XElement("Rating", s.Element("Rating").Value),
//                       new XElement("Contact", s.Element("Contact").Value)
                     
//                       ))));
//            result.Save(@"C:\repos\CodeSmart-Intern-Training\RestaurantsByAdoXML\RestaurantsByAdo\Result.xml");
//        }
//    }
//}
