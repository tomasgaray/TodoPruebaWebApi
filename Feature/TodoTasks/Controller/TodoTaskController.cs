using Microsoft.AspNetCore.Mvc;
using TodoPruebaWebApi.Feature.Services;
using TodoPruebaWebApi.Feature.TodoTasks.Entities;
using TodoPruebaWebApi.Shared.Controllers;

namespace TodoPruebaWebApi.Feature.TodoTasks.Controllers{
    public class TodoTaskController : BaseApiController
    {
        private readonly TodoTaskService _todoTaskService;
        public TodoTaskController(TodoTaskService todoTaskService)
        {
            _todoTaskService = todoTaskService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(){
            try
            {
                var result = await _todoTaskService.Get();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("Search/{text}")]
        public async Task<IActionResult> Search(string text){
            try
            {
                var result = await _todoTaskService.Search(text);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TodoTask task){
            try
            {
                var result = await _todoTaskService.Add(task);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] TodoTask task){
            try
            {
                var result = await _todoTaskService.Edit(task);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{TaskId}")]
        public async Task<IActionResult> Remove(int taskId){
            try
            {
                await _todoTaskService.Remove(taskId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPut("changeStatus/{taskId}/{completed}")]
        public async Task<IActionResult> ChangeStatus(int taskId, bool completed){
            try
            {
                var result = await _todoTaskService.ChangeStatus(taskId, completed);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}