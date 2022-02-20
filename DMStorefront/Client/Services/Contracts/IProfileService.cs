using DMStorefront.Client.Services.ServiceModels;

namespace DMStorefront.Client.Services.Contracts
{
    public interface IProfileService
    {
        Task ToggleUserMode();

        Task<Preferences> GetPreferences();
    }
}
