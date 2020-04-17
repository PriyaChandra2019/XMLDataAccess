using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantsByAdo.Models

{
    public class Restaurant
    {
        public int ID { get; set; }
        [Required]
        public string RestaurantName { get; set; }
        [Required]
        public string CuisineType { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Rating { get; set; }
        [Required]
        public string Contact { get; set; }
    }    
}
