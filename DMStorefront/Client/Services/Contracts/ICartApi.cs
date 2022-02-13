using DMStorefront.Shared.Models;

namespace DMStorefront.Client.Services.Contracts
{
    public interface ICartApi
    {
        Task Add(string item);
        Task Remove(string item);
        Task<Dictionary<string, int>> GetCart();
    }
}
