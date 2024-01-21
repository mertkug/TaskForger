namespace TaskForger.Commands.Task;
using Task = TaskForger.Entities.Task;

public abstract class Update
{
    public static void Execute(TaskRepository taskRepository, int id, string? title, string? description, DateTime? dueDate, bool? finished)
    {
        var task = taskRepository.GetTaskWithId(id);
        Task updatedTask = new()
        {
            Title = title ?? task.Title,
            Description = description ?? task.Description,
            DueDate = dueDate ?? task.DueDate,
            Finished = finished ?? task.Finished
        };
        taskRepository.UpdateTask(id, updatedTask);
    }
}