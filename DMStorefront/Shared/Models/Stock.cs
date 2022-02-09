using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DMStorefront.Shared.Models
{
    public class Stock
    {
        [Key]
        public int Id { get; set; }


        public virtual ICollection<Item> Items { get; set; }

       public string UserName { get; set; }

        public Stock()
        {
            Items = new List<Item>();
            
        }
    }

   
}
