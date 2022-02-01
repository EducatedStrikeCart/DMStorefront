using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMStorefront.Shared.Models.Item
{
    public class Item
    {
        [Key]
        public string Name { get; set; }
       
        public int Weight { get;  set; }

        
        public int Price { get; set; }

        public string Description { get; set; }

      

        public Item()
        {

            Name = string.Empty;
            Weight = 0;
            Price = 0;
            Description = string.Empty;
           
            
        }

        
    }
}

