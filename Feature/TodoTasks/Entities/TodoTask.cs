using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TodoPruebaWebApi.Feature.TodoTasks.Entities{
    public class TodoTask{
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Completed { get; set; }

        public TodoTask()
        {
            Title = "";
        }
        public TodoTask(TodoTask? Task)
        {
            this.TaskId = Task?.TaskId??0;
            this.Title = Task?.Title??string.Empty;
            this.Description = Task?.Description??string.Empty;
            this.CreatedDate = Task?.CreatedDate??DateTime.Now;
            this.Completed = Task?.Completed??false;
        }
        public void Valid(){
            if(string.IsNullOrEmpty(Title)) throw new Exception("Por favor ingrese el título");
        }

        
         public class Map
        {
            public Map(EntityTypeBuilder<TodoTask> builder)
            {
                builder.HasKey(x => x.TaskId);
                builder.Property(x => x.TaskId).HasColumnName("TaskId");
                builder.Property(x => x.Title).HasColumnName("Title");
                builder.Property(x => x.Description).HasColumnName("Description");
                builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate");
                builder.Property(x => x.Completed).HasColumnName("Completed");
                builder.ToTable("TodoTask");
            }
        }
    }
}