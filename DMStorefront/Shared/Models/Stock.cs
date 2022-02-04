using DMStorefront.Shared.Models;
using System.ComponentModel.DataAnnotations;

namespace DMStorefront.Shared.Models
{
    public class Stock
    {
        [Key]
        public int Id { get; set; }

        public virtual ICollection<Item> Items { get; set; }


    }


}
