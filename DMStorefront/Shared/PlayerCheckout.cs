using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMStorefront.Shared

    {     
    public class PlayerCheckout
            {
            [Key]
            public string ItemId { get; set; }

            public string CartId { get; set; }

            public int Quantity { get; set; }

            public virtual PlayerCheckout Product { get; set; }

            }
    }
    
