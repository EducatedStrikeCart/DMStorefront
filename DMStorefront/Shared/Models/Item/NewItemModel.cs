using System.ComponentModel.DataAnnotations;

namespace DMStorefront.Shared.Models.Item
{
    public class NewItemModel
    {
        [Required]
        public string Name { get; set; }
        [Range(1,100000, ErrorMessage = "Please enter a number between 1 and 100,000")]
        public int Weight { get; set; }
        
        [Required]
        public string Price { get; set; }
        
        public string Description { get; set; }    

       

        public NewItemModel()
        {
            
            Name = string.Empty;
            Weight = 0;
            Price = new string("0.0.0");
            Description = string.Empty;
            
        }

    }

}
