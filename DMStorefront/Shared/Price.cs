using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMStorefront.Shared
{
    public class Price
    {
    
        
        public int Gold { get; set; }
        public int Silver { get; set; }
        public int Copper { get; set; }
        public int Value { get; set; }

        public Price(int value)
        {
            Gold = value/ 100;
            Silver = (value % 100) / 10;
            Copper =  value % 10;
            Value = value;
        }

       public Price() { }

        public Price(int gold, int silver, int copper)
        {
            Gold = gold;
            Silver = silver;
            Copper = copper;
            Value = (gold * 100) + (silver * 10) + copper;
        }

        public override string ToString()
        {
            return Gold.ToString() + " gold " + Silver.ToString() + " silver " + Copper.ToString() + " copper " + Value.ToString();

        }

        //might need to also be comparable
    }
}
