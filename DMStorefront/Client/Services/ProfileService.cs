using Blazored.LocalStorage;

namespace DMStorefront.Client.Services
{
    public class ProfileService
    {
        private readonly ILocalStorageService _localStorageService;
        public event Action<Preferences> OnChange;

        public ProfileService(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public async Task ToggleUserMode()
        {
            var preferences = await GetPreferences();
            var newPreferences = preferences
                with
            { UserMode = !preferences.UserMode };
            await _localStorageService.SetItemAsync("preferences", newPreferences);

            OnChange?.Invoke(newPreferences);
        }

        public async Task<Preferences> GetPreferences()
        {
            return await _localStorageService.GetItemAsync<Preferences>("preferences")
                ?? new Preferences();
        }

    }
}
