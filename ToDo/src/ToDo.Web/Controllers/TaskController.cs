using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDo.Application.UseCases.TodoTasks.Commands;
using ToDo.Application.UseCases.TodoTasks.Queries;
using ToDo.Application.ViewModels;
using ToDo.Domain.Entities;

namespace ToDo.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllTasks()
        {
            IList<TodoTask> tasks = await _mediator.Send(new GetAllTasksQuery());
            return Ok(tasks);
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateTask(TaskDTO taskDTO)
        {
            var task = new CreateTaskCommand() { TaskDto = taskDTO };

            await _mediator.Send(task);
            return Ok("Created");
        }

        [HttpPut]
        public async ValueTask<ActionResult<bool>> UpdateTask(UpdateTaskCommand command)
        {
            bool result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        public async ValueTask<ActionResult<bool>> DeleteTask(int id)
        {
            bool result = await _mediator.Send(new DeleteTaskCommand() { Id = id });
            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetTaskById(int id)
        {
            TodoTask? task = await _mediator.Send(new GetTaskByIdQuery() { Id = id });
            return Ok(task);
        }
    }
}
