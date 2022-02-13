using DMStorefront.Shared.Models;

namespace DMStorefront.Client.Services.ServiceModels
{
    public class CartEntry
    {
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public int PriceSubTotal
        {
            get { return Item.Price * Quantity; }
        }

        public CartEntry(Item item, int quantity)
        {
            Item = item;
            Quantity = quantity;
        }
    }
}
