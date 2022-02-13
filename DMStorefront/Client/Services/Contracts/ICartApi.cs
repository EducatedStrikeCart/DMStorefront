using DMStorefront.Client.Services.ServiceModels;
using DMStorefront.Shared.Models;

namespace DMStorefront.Client.Services.Contracts
{
    public interface ICartApi
    {
        Task Add(Item item);
        Task Remove(Item item);
        Task<List<CartEntry>> GetCart();
    }
}
