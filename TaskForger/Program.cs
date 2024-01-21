using Cocona;
using Microsoft.Extensions.DependencyInjection;
using TaskForger;
using TaskForger.Commands.Task;

var builder = CoconaApp.CreateBuilder();
builder.Services.AddScoped<TaskRepository>();
builder.Services.AddScoped<ConnectionBuilder>();

var app = builder.Build();

app.AddCommand("add", Add.Execute).WithDescription("Add task to database");

app.AddCommand("list-all", ListAll.Execute).WithDescription("List all tasks");


app.AddCommand("mark-finished", MarkFinished.Execute).WithDescription("Mark unfinished task as finished with id");

app.AddCommand("undo-finished", UndoFinished.Execute).WithDescription("Undo finished task as unfinished with id");

app.AddCommand("list-calendar", ListCalendar.Execute).WithDescription("Calendar view for tasks");

app.AddCommand("list-filtered", ListFiltered.Execute).WithDescription("List tasks filtered by title or description");

app.AddCommand("delete", Delete.Execute).WithDescription("Delete task with id");

app.AddCommand("update", Update.Execute).WithDescription("Update task with id, --title, --description, --due-date, --finished optional arguments");

app.AddCommand("export", Export.Execute).WithDescription("Export tasks to a file");

app.Run();