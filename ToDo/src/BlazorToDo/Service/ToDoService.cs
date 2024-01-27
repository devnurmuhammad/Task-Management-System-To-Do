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

        public async Task<TodoTask> GetTaskById(int id)
        {
            return await _httpClient.GetFromJsonAsync<TodoTask>($"http://localhost:5131/api/Task/GetTaskById?id={id}");

        }
        public async Task DeleteTask(int id)
        {
            await _httpClient.DeleteAsync($"http://localhost:5131/api/Task/DeleteTask?id={id}");
        }

        public async Task AddTask(TodoTask newtask)
        {
            await _httpClient.PostAsJsonAsync("http://localhost:5131/api/Task/CreateTask", newtask);
        }

        public async Task UpdateTask(TodoTask editedtask)
        {
            await _httpClient.PutAsJsonAsync("http://localhost:5131/api/Task/UpdateTask", editedtask);
        }
    }
}
