using Microsoft.EntityFrameworkCore;
using TodoPruebaWebApi.Feature.TodoTasks.Entities;
using TodoPruebaWebApi.Infraestructure;

namespace TodoPruebaWebApi.Feature.Services{
    public class TodoTaskService{
        private readonly TodoTaskDbContext _dbContext;
        public TodoTaskService(TodoTaskDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<TodoTask>> Get(){
            await Task.Delay(200);//Solamente para que se noten las animaciones
            List<TodoTask> tasks = await _dbContext.TodoTask.ToListAsync();
            return tasks.OrderByDescending(x=> x.TaskId).ToList();
        }

        public async Task<List<TodoTask>> Search(string text){
            text = text.ToLower();
            List<TodoTask> tasks = await _dbContext.TodoTask
            .Where(x=> x.Title.ToLower().Contains(text) || (x.Description??"").ToLower().Contains(text)).ToListAsync();
            return tasks;
        }

        public async Task<TodoTask> GetById(int TaskId){
            TodoTask? task = await _dbContext.TodoTask.Where(x=> x.TaskId == TaskId).FirstOrDefaultAsync();
            if(task == null) throw new Exception("Esta tarea ya no existe, intente actualizar el sitio web");
            return task;
        }


        public async Task<TodoTask> Add(TodoTask task){
            await Task.Delay(200);//Solamente para que se noten las animaciones
            task.Valid();
            await _dbContext.AddAsync(task);
            await _dbContext.SaveChangesAsync();
            return task;
        }

        public async Task<TodoTask> Edit(TodoTask task){
            await Task.Delay(200);//Solamente para que se noten las animaciones
            task.Valid();
            TodoTask currentTask = await GetById(task.TaskId);
            currentTask.Completed = task.Completed;
            currentTask.Title = task.Title;
            currentTask.Description = task.Description;
            _dbContext.Update(currentTask);
            await _dbContext.SaveChangesAsync();
            return task;
        }

        public async Task Remove(int taskId){
            await Task.Delay(200);//Solamente para que se noten las animaciones
            TodoTask currentTask = await GetById(taskId);
            _dbContext.Remove(currentTask);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<TodoTask> ChangeStatus(int taskId, bool completed){
            await Task.Delay(200);//Solamente para que se noten las animaciones
            TodoTask currentTask = await GetById(taskId);
            currentTask.Completed = completed;
            _dbContext.Update(currentTask);
            await _dbContext.SaveChangesAsync();
            return currentTask;
        }
    }
}