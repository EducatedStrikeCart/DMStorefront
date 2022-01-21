using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMStorefront.Shared
{
    public class Item
    {
        [Key]
        public string Name { get; set; }
       
        public int Weight { get; set; }

        
        public Price Price { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public Item()
        {

            Name = string.Empty;
            Weight = 0;
            Price = new Price();
            Description = string.Empty;
            ImageUrl = string.Empty;
            
        }

        
    }
}

