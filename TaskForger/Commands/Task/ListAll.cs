using Spectre.Console;

namespace TaskForger.Commands.Task;

public abstract class ListAll
{
    // a command to list all tasks
    public static void Execute(TaskRepository taskRepository)
    {
        var tasks = taskRepository.GetTasks();

        if (tasks.Count > 0)
        {
            var table = new Table();

            // Add colored columns
            table.AddColumn(new TableColumn("Task Id").Header("[blue]TaskId[/]"));
            table.AddColumn(new TableColumn("Title").Header("[blue]Title[/]"));
            table.AddColumn(new TableColumn("Description").Header("[blue]Description[/]"));
            table.AddColumn(new TableColumn("Due Date").Header("[blue]DueDate[/]"));
            table.AddColumn(new TableColumn("Finished").Header("[blue]Finished[/]"));

            foreach (var task in tasks)
            {
                table.AddRow(
                    task.TaskId.ToString(),
                    task.Title,
                    task.Description,
                    task.DueDate.ToString("yyyy-MM-dd HH:mm:ss"),
                    task.Finished ? "[green]Yes[/]" : "[red]No[/]"
                );
            }

            AnsiConsole.Write(table);
        }
        else
        {
            Console.WriteLine("No tasks found.");
        }
    }
}