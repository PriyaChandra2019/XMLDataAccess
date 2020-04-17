using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

//namespace RestaurantsByAdo
//{
//    public class Program1
//    {
//        public static void Main()
//        {
//            StringBuilder sb = new StringBuilder();
//            string delimiter = ",";
//            XDocument.Load(@"C:\repos\CodeSmart-Intern-Training\RestaurantsByAdo\RestaurantsByAdo:Data.xml").Descendants("Restaurant").ToList().ForEach(element => sb.Append(element.Attribute("RestaurantName").Value + delimiter +
//                                                                                                                             element.Element("CuisineType").Value + delimiter +
//                                                                                                                             element.Element("City").Value + delimiter +
//                                                                                                                             element.Element("Rating").Value + delimiter + element.Element("Contact").Value + "\r\n"));
//            StreamWriter sw = new StreamWriter(@"C:\repos\CodeSmart-Intern-Training\RestaurantsByAdo\RestaurantsByAdo\Result.csv");
//            sw.WriteLine(sb.ToString());
//            sw.Close();
//        }
//    }
//}
