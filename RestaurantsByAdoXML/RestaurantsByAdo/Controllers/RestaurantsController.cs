using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCDemoApp.Models;
using RestaurantsByAdo.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestaurantsByAdo.Controllers
{
    public class RestaurantsController : Controller
    {
        //Camel Case.. Only firstletter will be lower, every first letter of the words should be caps. 
        //e.g: objRestaurantType
        //private RestaurantsDataAccessLayer dataAccess = new RestaurantsDataAccessLayer();
        //
        //RestaurantsDataAccessLayer objRestaurantType = new RestaurantsDataAccessLayer();

        RestaurantXMLDataAccessLayer objRestaurantType = new RestaurantXMLDataAccessLayer();

        //private object objRestaurants;
        //private object objrestauranttppe;
        //private object objrestauranttypeData;

        // Adding the logic of create View
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                objRestaurantType.AddRestaurant(restaurant);
                return RedirectToAction("Index");
            }
            return View(restaurant);
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Restaurant> lstRestaurants = new List<Restaurant>();
            lstRestaurants = objRestaurantType.GetAllRestaurants().ToList();

            return View(lstRestaurants);
        }

        //Adding the logic of Edit View
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Restaurant restauranttype = objRestaurantType.GetRestaurantsData(id);
            if (restauranttype == null)
            {
                return NotFound();
            }
            return View(restauranttype);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind]Restaurant restaurant)
        {
            if (id != restaurant.ID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                objRestaurantType.UpdateRestaurant(restaurant);
                return RedirectToAction("Index");
            }
            return View(restaurant);
        }
        
        //Adding Logic for Details View

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Restaurant restauranttype = objRestaurantType.GetRestaurantsData(id);
            if (restauranttype == null)
            {
                return NotFound();
            }
            return View(restauranttype);
        }

        private Restaurant GetRestauranttype(int? id)
        {
            return objRestaurantType.GetRestaurantsData(id);
        }

        //Adding Logic to Delete View
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
      
            Restaurant restauranttype = objRestaurantType.GetRestaurantsData(id);
            if (restauranttype == null)
            {
                return NotFound();
            }
            return View(restauranttype);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? Id)
        {
            objRestaurantType.DeleteRestaurant(Id.Value);
            return RedirectToAction("Index");
        }
    }
}

//private RestaurantsDataAccessLayer dataAccess = new RestaurantsDataAccessLayer();

// GET: /<controller>/
//public IActionResult Index()
//{
// IEnumerable<RestaurantsType> restaurantsList =  dataAccess.GetAllRestaurantTypes();
//return View(restaurantsList);
// }
// }
//}