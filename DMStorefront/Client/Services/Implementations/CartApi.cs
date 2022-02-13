using Blazored.LocalStorage;
using DMStorefront.Shared.Models;
using System.Net.Http.Json;

namespace DMStorefront.Client.Services.Implementations
{
    public class CartApi
    {
        public event Action? OnChange;
        public Dictionary<string, int>? CartItems { get; set; }

        private readonly ILocalStorageService _localStorageService;

        public CartApi(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public async Task Add(string itemName)
        {
            Dictionary<string, int> newCart = await GetCart();
            if (newCart.ContainsKey(itemName))
            {
                newCart[itemName] += 1;
            }
            else
            {
                newCart.Add(itemName, 1);
            }
            await _localStorageService.SetItemAsync("cart", newCart);

            OnChange?.Invoke();
        }

        public async Task Remove(string itemName)
        {
            Dictionary<string, int> newCart = await GetCart();
            if (newCart.ContainsKey(itemName))
            {
                if (newCart[itemName] == 1)
                {
                    newCart.Remove(itemName);
                }
                else
                {
                    newCart[itemName] -= 1;
                }
            }
            await _localStorageService.SetItemAsync("cart", newCart);

            OnChange?.Invoke();
        }

        public async Task<Dictionary<string, int>> GetCart()
        {
            Dictionary<string, int> cart = new();
            cart = await _localStorageService.GetItemAsync<Dictionary<string, int>>("cart");
            if (cart == null)

            {
                Dictionary<string, int> newCart = new();
                await _localStorageService.SetItemAsync("cart", newCart);
                return newCart;
            }
            else
            {
                return await _localStorageService.GetItemAsync<Dictionary<string, int>>("cart");
            }

        }
    }
}
