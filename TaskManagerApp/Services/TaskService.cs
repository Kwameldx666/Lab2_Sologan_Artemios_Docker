using System.Text.Json;
using TaskManagerApp.Models;

namespace TaskManagerApp.Services
{
    public class TaskService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        public TaskService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        public async Task<List<TaskItem>> GetAllTasksAsync()
        {
            var response = await _httpClient.GetAsync("api/tasks");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<TaskItem>>(json, _jsonOptions) ?? new List<TaskItem>();
        }

        public async Task<TaskItem?> GetTaskAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/tasks/{id}");
            if (!response.IsSuccessStatusCode) return null;
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TaskItem>(json, _jsonOptions);
        }

        public async Task<TaskItem?> CreateTaskAsync(TaskItem task)
        {
            var json = JsonSerializer.Serialize(task, _jsonOptions);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/tasks", content);
            if (!response.IsSuccessStatusCode) return null;
            var responseJson = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TaskItem>(responseJson, _jsonOptions);
        }

        public async Task<TaskItem?> UpdateTaskAsync(int id, TaskItem task)
        {
            var json = JsonSerializer.Serialize(task, _jsonOptions);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"api/tasks/{id}", content);
            if (!response.IsSuccessStatusCode) return null;
            var responseJson = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TaskItem>(responseJson, _jsonOptions);
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/tasks/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}