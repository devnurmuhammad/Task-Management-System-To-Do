using BlazorToDo.Entities;

namespace BlazorToDo.Service
{
    public class ToDoService
    {
        private readonly HttpClient _httpClient;
        public ToDoService(HttpClient http)
        {
            _httpClient = http;
        }
        public List<TodoTask> tasks { get; set; } = new List<TodoTask>();
        public async Task GetAllTask()
        {
           tasks = await _httpClient.GetFromJsonAsync<List<TodoTask>>("http://localhost:5131/api/Task/GetAllTasks");
        }
        public async Task DeleteTask(int id)
        {
            await _httpClient.DeleteAsync($"http://localhost:5131/api/Task/DeleteTask?id={id}");
        }
    }
}
