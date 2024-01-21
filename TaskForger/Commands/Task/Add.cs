namespace TaskForger.Commands.Task;
using Entities;
public abstract class Add
{
    // a command to add a task
    public static void Execute(TaskRepository taskRepository)
    {
        var taskAdded = false;
        while (!taskAdded)
        {
            Console.Out.WriteLine("Enter task details: ");

            Console.Write("Task Title (Required): ");
            var title = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("Title cannot be empty. Please enter a valid title.");
                continue; // Continue to the next iteration of the loop
            }

            Console.Write("Task Description: ");
            var description = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(description))
            {
                description = "";
            }

            Console.Write("Due Date: ");
            var due = Console.ReadLine();
            if (!DateTime.TryParse(due, out var parsedDueDate))
            {
                Console.WriteLine("Invalid due date format. Please use a valid date and time format.");
                continue; // Continue to the next iteration of the loop
            }

            // Create new task
            var task = new Task
            {
                Title = title,
                Description = description,
                Finished = false,
                DueDate = parsedDueDate
            };

            taskRepository.AddTask(task);
            
            taskAdded = true;

            Console.WriteLine("Task added successfully!");
            
        }
    }
}