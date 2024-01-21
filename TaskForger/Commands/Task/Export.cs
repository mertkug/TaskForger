using System.Runtime.InteropServices;

namespace TaskForger.Commands.Task;

public abstract class Export
{
    public static void Execute(TaskRepository taskRepository, string? path)
    {
        var tasks = taskRepository.GetTasks();
        var taskInfo = tasks.Select(task =>
            $"Title: {task.Title}, Description: {task.Description}, Due Date: {task.DueDate}, Finished: {task.Finished}"
        ).ToArray();
        File.WriteAllLines(path ?? Directory.GetCurrentDirectory(), taskInfo);
    }
}