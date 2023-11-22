namespace Soru4.Services
{
    using Soru4.Dto.Responses;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    public class UserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<User> GetUserAsync(int userId)
        {
            var response = await _httpClient.GetAsync($"https://gorest.co.in/public/v2/users/{userId}");

            if (response.IsSuccessStatusCode)
            {
                var jsonContent = await response.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<User>(jsonContent);
                return user;
            }

            // Handle error cases if needed
            return null;
        }
        public async Task<List<User>> GetAllUsers()
        {
            var response = await _httpClient.GetStringAsync("https://gorest.co.in/public/v2/users");
            var users = JsonConvert.DeserializeObject<List<User>>(response);
            return users;
        }
    }
}
