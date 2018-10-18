using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.WebAPI.Models
{
    public class Publisher
    {
        //Constructor (Entity Framework, dus parameterloze constructor nodig!)
        public Publisher()
        {
        }

        //Contructor Overload
        public  Publisher(int id, string name, string country)
        {
            Id = id;
            Name = name;
            Country = country;
        }

        //Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }    
    }
}
