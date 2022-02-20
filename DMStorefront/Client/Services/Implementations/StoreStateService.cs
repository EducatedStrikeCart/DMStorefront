using DMStorefront.Client.Services.Contracts;

namespace DMStorefront.Client.Services.Implementations
{
    public class StoreStateService : IStoreStateService
    {
        public event Action? OnChange;

        public void UpdateStore()
        {
            OnChange?.Invoke();
        }
    }
}
