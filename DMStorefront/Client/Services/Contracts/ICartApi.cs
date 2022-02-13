using DMStorefront.Shared.Models;

namespace DMStorefront.Client.Services.Contracts
{
    public interface ICartApi
    {
        Task Add(string item);
        Task UpdateQuantity(string item);
        Task Remove(string item);
        Task<List<Item>> GetItems(string itemString);
    }
}
