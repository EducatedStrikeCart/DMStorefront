using System.ComponentModel.DataAnnotations;

namespace DMStorefront.Shared
{
    public class NewItemModel
    {
        [Required]
        public string Name { get; set; }
        [Range(1,100000, ErrorMessage = "Please enter a number between 1 and 100,000")]
        public int Weight { get; set; }
        
        [PriceValidation(ErrorMessage = "Please enter price")]
        public Price Price { get; set; }
        
        public string Description { get; set; }    

       

        public NewItemModel()
        {
            
            Name = string.Empty;
            Weight = 0;
            Price = new Price();
            Description = string.Empty;
            
        }

    }

}
