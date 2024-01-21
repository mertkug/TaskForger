using Spectre.Console;
using Task = TaskForger.Entities.Task;
namespace TaskForger;

public static class Utility
{
    public static void RenderCalendar(int year, int month, IEnumerable<Task> tasks)
    {
        var calendar = new Calendar(year, month)
        {
            HighlightStyle = Style.Parse("yellow bold")
        };

        foreach (var task in tasks.Where(task => task.Finished != true && task.DueDate.Year == year && task.DueDate.Month == month))
        {
            calendar.AddCalendarEvent(task.Title, task.DueDate);
        }

        AnsiConsole.Write(calendar);
    }
}