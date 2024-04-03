using System.Net.Http.Json;

namespace BlazorApp1.Services;

public class UserModel
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}

public interface IUserService
{
    Task<UserModel> GetUserById(string id);
}

public class UserService : IUserService
{
    private readonly HttpClient _client;

    public UserService(HttpClient client)
    {
        _client = client;
    }

    public async Task<UserModel> GetUserById(string id)
    {
        var result =  await _client.GetFromJsonAsync<UserModel>($"users/{id}");
        return result ?? new UserModel();
    }
}