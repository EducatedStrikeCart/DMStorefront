using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMStorefront.Shared.Models
{
    public class Inventory
    {
        [Key] 
        public int Id { get; set; }
        [Required(ErrorMessage= "You must enter a number between 0 and 999999")]
        [Range(0, 9999999)]
        public int Wallet { get; set; }
        public string UserName { get; set; }

        public Inventory(int wallet, string userName)
        {
            Wallet = wallet;
            UserName = userName;
        }

        // TODO: Implement Item Inventory
        //public virtual ICollection<Item> Items { get; set; }


    }
}
