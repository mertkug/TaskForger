using Cocona;

namespace TaskForger.Commands.Task;

public abstract class UndoFinished
{
    public static void Execute(TaskRepository taskRepository, [Argument] int id)
    {
        taskRepository.MarkFinished(id, false);
    }
}