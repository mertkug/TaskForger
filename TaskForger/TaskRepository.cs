using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Caching.Memory;
using Task = TaskForger.Entities.Task;
namespace TaskForger;

public class TaskRepository
{
    private readonly SqliteConnection _connection;
    public TaskRepository(ConnectionBuilder connectionBuilder)
    {
        _connection = connectionBuilder.Connection;
        
        _connection.Open();
        
        _connection.Execute("""
                            
                                        CREATE TABLE IF NOT EXISTS Tasks (
                                            TaskId INTEGER PRIMARY KEY AUTOINCREMENT,
                                            Description TEXT,
                                            Title TEXT,
                                            DueDate DATETIME,
                                            Finished BOOLEAN
                                        );
                             """);
    }

    public void AddTask(Task newTask)
    {
        const string insertQuery = "INSERT INTO Tasks (Description, Title, DueDate, Finished) VALUES (@Description, @Title, @DueDate, @Finished);";
        
        var rowsAffected = _connection.Execute(insertQuery, newTask);
        
        Console.WriteLine(rowsAffected > 0 ? "Insert successful!" : "Insert failed.");
    }

    public void MarkFinished(int id, bool finished = true)
    {
        const string updateQuery = "UPDATE Tasks SET Finished = @Finished WHERE TaskId = @TaskId;";
    
        _connection.Execute(updateQuery, new { TaskId = id, Finished = finished ? 1 : 0 });
    }
    
    public List<Task> GetTasks()
    {
        const string selectQuery = "SELECT * FROM Tasks;";

        var tasks = _connection.Query<Task>(selectQuery).ToList();

        return tasks;
    }

    public Task GetTaskWithId(int id)
    {
        const string selectQuery = "SELECT * FROM Tasks WHERE TaskId = @TaskId;";
        var task = _connection.Query<Task>(selectQuery, new { TaskId = id }).FirstOrDefault();
        if (task == null)
        {
            throw new Exception("Task not found.");
        }
        return task;
    }

    public List<Task> GetTasksWithFilter(string filter)
    {
        const string selectQuery = "SELECT * FROM Tasks WHERE Title LIKE @Filter OR Description LIKE @Filter;";
        
        var tasks = _connection.Query<Task>(selectQuery, new { Filter = $"%{filter}%" }).ToList();
        
        return tasks;
    }
    
    public void DeleteTask(int id)
    {
        const string deleteQuery = "DELETE FROM Tasks WHERE TaskId = @TaskId;";
        
        _connection.Execute(deleteQuery, new { TaskId = id });
    }
    
    public void UpdateTask(int id, Task updatedTask)
    {
        const string updateQuery = "UPDATE Tasks SET Description = @Description, Title = @Title, DueDate = @DueDate, Finished = @Finished WHERE TaskId = @TaskId;";
        
        _connection.Execute(updateQuery, new { TaskId = id, updatedTask.Description, updatedTask.Title, updatedTask.DueDate, updatedTask.Finished });
    }

}