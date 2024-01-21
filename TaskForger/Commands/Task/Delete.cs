using Cocona;

namespace TaskForger.Commands.Task;

public abstract class Delete
{
    public static void Execute(TaskRepository taskRepository, [Argument] int id)
    {
        taskRepository.DeleteTask(id);
    }
}