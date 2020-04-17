
using RestaurantsByAdo.Controllers;
using RestaurantsByAdo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MVCDemoApp.Models
{
    public class RestaurantsDataAccessLayer
    {

        public RestaurantsDataAccessLayer()
        {

        }

        string connectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=RestaurantsByAdo;Data Source=PRIYACHSANJAY";
      

        public object Name { get; private set; }

        //To view all the restauranttype details
        public IEnumerable<Restaurant> GetAllRestaurants()
        {
            List<Restaurant> lstRestaurantType = new List<Restaurant>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.spGetAllRestaurants", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Restaurant restauranttype = new Restaurant();

                    restauranttype.ID = Convert.ToInt32(rdr["ID"]);
                    restauranttype.RestaurantName = rdr["RestaurantName"].ToString();
                    restauranttype.CuisineType = rdr["Restaurant_Type"].ToString();
                    restauranttype.City = rdr["City"].ToString();
                    restauranttype.Rating = rdr["Rating"].ToString();
                    restauranttype.Contact = rdr["Contact"].ToString();
                    

                    lstRestaurantType.Add(restauranttype);

                }
                con.Close();

            }
            return lstRestaurantType;
        }

     
        //To Add new restaurant type record
        public void AddRestaurant(RestaurantsByAdo.Models.Restaurant restaurantstype)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddRestaurant", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RestaurantName", restaurantstype.RestaurantName);
                cmd.Parameters.AddWithValue("@CuisineType", restaurantstype.CuisineType);
                cmd.Parameters.AddWithValue("@City", restaurantstype.City);
                cmd.Parameters.AddWithValue("@Rating", restaurantstype.Rating);
                cmd.Parameters.AddWithValue("@Contact", restaurantstype.Contact);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
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

        internal void DeleteRestaurants(int? id)
        {
            throw new NotImplementedException();
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
