
using RestaurantsByAdo.Controllers;
using RestaurantsByAdo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MVCDemoApp.Models
{
    public class RestaurantXMLDataAccessLayer
    {

        public RestaurantXMLDataAccessLayer()
        {


        }

        string connectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=RestaurantsByAdo;Data Source=PRIYACHSANJAY";
      

        public object Name { get; private set; }
        public IEnumerable<object> RestaurantName { get; private set; }




        //To view all the restauranttype details
        public IEnumerable<Restaurant> GetAllRestaurants()
        {
            List<Restaurant> lstRestaurantType = new List<Restaurant>();

            XElement xelement = XElement.Load(@"C:\repos\CodeSmart-Intern-Training\RestaurantsByAdoXML\RestaurantsByAdo\XMLFile.xml");
            IEnumerable<XElement> restaurants = xelement.Elements();
            Console.WriteLine("List of all Restaurant along with their Restaurant Name:");
            foreach (var Restaurant in restaurants)
            {
                Restaurant restauranttype = new Restaurant();

                restauranttype.RestaurantName = Restaurant.Element("RestaurantName").Value;
                restauranttype.CuisineType = Restaurant.Element("CuisineType").Value;
                restauranttype.City = Restaurant.Element("City").Value;
                restauranttype.Rating = Restaurant.Element("Rating").Value;
                restauranttype.Contact = Restaurant.Element("Contact").Value;
                restauranttype.ID = Convert.ToInt32(Restaurant.Element("Id").Value);

                lstRestaurantType.Add(restauranttype);


            }
                               
                     return lstRestaurantType;
        }

     
        //To Add new restaurant type record
        public void AddRestaurant(RestaurantsByAdo.Models.Restaurant restaurant)
        {
            string filePath = @"C:\repos\CodeSmart-Intern-Training\RestaurantsByAdoXML\RestaurantsByAdo\XMLFile.xml";
            XDocument xmlDocument = XDocument.Load(filePath);

            XElement root = new XElement("Restaurant");
            root.Add(new XElement("RestaurantName", restaurant.RestaurantName));
            root.Add(new XElement("CuisineType", restaurant.CuisineType));
            root.Add(new XElement("City", restaurant.City));
            root.Add(new XElement("Rating", restaurant.Rating));
            root.Add(new XElement("Contact", restaurant.Contact));
            root.Add(new XElement("Id", GetRandomNumber(100, 10000)));
            xmlDocument.Element("Restaurants").Add(root);
            xmlDocument.Save(filePath);

            //using (SqlConnection con = new SqlConnection(connectionString))
            //{
            //    SqlCommand cmd = new SqlCommand("spAddRestaurant", con);
            //    cmd.CommandType = CommandType.StoredProcedure;

            //    cmd.Parameters.AddWithValue("@RestaurantName", restaurantstype.RestaurantName);
            //    cmd.Parameters.AddWithValue("@CuisineType", restaurantstype.CuisineType);
            //    cmd.Parameters.AddWithValue("@City", restaurantstype.City);
            //    cmd.Parameters.AddWithValue("@Rating", restaurantstype.Rating);
            //    cmd.Parameters.AddWithValue("@Contact", restaurantstype.Contact);

            //    con.Open();
            //    cmd.ExecuteNonQuery();
            //    con.Close();

            //}
        }

        private int GetRandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        //To update the records of a particular restauranttype
        public void UpdateRestaurant(Restaurant restaurant)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdateRestaurant", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID", restaurant.ID);
                cmd.Parameters.AddWithValue("@RestaurantName", restaurant.RestaurantName);
                cmd.Parameters.AddWithValue("@CuisineType", restaurant.CuisineType);
                cmd.Parameters.AddWithValue("@City", restaurant.City);
                cmd.Parameters.AddWithValue("@Rating", restaurant.Rating);
                cmd.Parameters.AddWithValue("@Contact", restaurant.Contact);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

      
        //Get the details of a particular Restaurant Type
        public Restaurant GetRestaurantsData(int? id)
        {
            RestaurantsByAdo.Models.Restaurant restaurant = new RestaurantsByAdo.Models.Restaurant();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM tblRestaurantsType WHERE ID= " + id.Value.ToString();
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    restaurant.RestaurantName = rdr["RestaurantName"].ToString();
                    restaurant.CuisineType = rdr["CuisineType"].ToString();
                    restaurant.City = rdr["City"].ToString();
                    restaurant.Rating = rdr["Rating"].ToString();
                    restaurant.Contact = rdr["Contact"].ToString();
                }

            }
            return restaurant;
        }

        //To Delete the record on a particular restauranttype

        public void DeleteRestaurant(int id)
        {
            string filePath = @"C:\repos\CodeSmart-Intern-Training\RestaurantsByAdoXML\RestaurantsByAdo\XMLFile.xml";
            XDocument xmlDocument = XDocument.Load(filePath);
            
            xmlDocument.Element("Restaurants").Elements("Restaurant")
                        .Where( t=> t.Element("Id").Value == id.ToString())
                        .Remove();

            xmlDocument.Save(filePath);
        }

            public void DeleteEmployee(int? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteRestaurant", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RestaurantName", Name);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

    }
}
