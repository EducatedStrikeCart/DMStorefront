using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMStorefront.Shared.Models;

namespace DMStorefront.Shared.Models
{
    public class Item
    {
        [Key]
        public string Name { get; set; }

        public int Weight { get; set; }

        public int Price { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Stock>? Stocks { get; set; }

        public Item()
        {

            Name = string.Empty;
            Weight = 0;
            Price = 0;
            Description = string.Empty;


        }

        public override bool Equals(object? obj)
        {
            return obj is Item item &&
                   Name == item.Name;
        }
    }
}