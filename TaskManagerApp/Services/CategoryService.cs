using System.Text.Json;
using TaskManagerApp.Models;

namespace TaskManagerApp.Services
{
    public class CategoryService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            var response = await _httpClient.GetAsync("api/categories");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Category>>(json, _jsonOptions) ?? new List<Category>();
        }

        public async Task<Category?> GetCategoryAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/categories/{id}");
            if (!response.IsSuccessStatusCode) return null;
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Category>(json, _jsonOptions);
        }

        public async Task<Category?> CreateCategoryAsync(Category category)
        {
            var json = JsonSerializer.Serialize(category, _jsonOptions);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/categories", content);
            if (!response.IsSuccessStatusCode) return null;
            var responseJson = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Category>(responseJson, _jsonOptions);
        }

        public async Task<Category?> UpdateCategoryAsync(int id, Category category)
        {
            var json = JsonSerializer.Serialize(category, _jsonOptions);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"api/categories/{id}", content);
            if (!response.IsSuccessStatusCode) return null;
            var responseJson = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Category>(responseJson, _jsonOptions);
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/categories/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}