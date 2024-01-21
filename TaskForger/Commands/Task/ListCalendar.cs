using Cocona;

namespace TaskForger.Commands.Task;

public abstract class ListCalendar
{
    public static void Execute(TaskRepository taskRepository, [Argument] int year, [Argument] int month)
    {
        var tasks = taskRepository.GetTasks();
        
        Utility.RenderCalendar(year, month, tasks);
        
    }
}