using System.Net.Http.Json;
using ModularMonolith.Modules.Users.Shared;
using ModularMonolith.Modules.Users.Shared.DTO;

namespace WalletApi.Modules.Wallets.Application;

public record UsersModuleApiService : IUsersModuleApi
{
    private readonly HttpClient _httpClient;
    public UsersModuleApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<UserDetailsDto> GetUserAsync(Guid userId)
    {
        var result = await _httpClient.GetFromJsonAsync<UserDetailsDto>($"users/{userId}");
        return result ?? new UserDetailsDto();
    }

    public async Task<UserDetailsDto> GetUserAsync(string email)
    {
        var result = await _httpClient.GetFromJsonAsync<UserDetailsDto>($"users/{email}");
        return result ?? new UserDetailsDto();
    }
}