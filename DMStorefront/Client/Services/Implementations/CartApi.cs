using Blazored.LocalStorage;
using DMStorefront.Client.Services.Contracts;
using DMStorefront.Client.Services.ServiceModels;
using DMStorefront.Shared.Models;
using System.Net.Http.Json;

namespace DMStorefront.Client.Services.Implementations
{

    public class CartApi : ICartApi
    {
        public event Action? OnChange;
        public List<CartEntry>? CartItems { get; set; }

        private readonly ILocalStorageService _localStorageService;

        public CartApi(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public async Task Add(Item item)
        {
            List<CartEntry> newCart = await GetCart();
            var entry = newCart.FirstOrDefault(e => e.Item.Name == item.Name);
            if (entry != null)
            {
                entry.Quantity += 1;
            }
            else
            {
                newCart.Add(new CartEntry(item, 1));
            }
            await _localStorageService.SetItemAsync("cart", newCart);

            OnChange?.Invoke();
        }

        public async Task Remove(Item item)
        {
            List<CartEntry> newCart = await GetCart();
            var entry = newCart.FirstOrDefault(e => e.Item.Name == item.Name);
            if (entry != null)
            {
                if (entry.Quantity == 1)
                {
                    newCart.Remove(entry);
                }
                else
                {
                    entry.Quantity -= 1;
                }
            }
            await _localStorageService.SetItemAsync("cart", newCart);

            OnChange?.Invoke();
        }

        public async Task<List<CartEntry>> GetCart()
        {
            List<CartEntry> cart;
            cart = await _localStorageService.GetItemAsync<List<CartEntry>>("cart");
            if (cart == null)
            {
                List<CartEntry> newCart = new();
                await _localStorageService.SetItemAsync("cart", newCart);
                return newCart;
            }
            else
            {
                return await _localStorageService.GetItemAsync<List<CartEntry>>("cart");
            }

        }
    }
}
