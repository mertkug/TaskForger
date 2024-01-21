using Dapper;

namespace TaskForger.Tests;
using Entities;

public class Tests
{
    [SetUp]
    public void Setup()
    {
        // clear database
        var cb = new ConnectionBuilder();
        cb.Connection.Execute("DELETE FROM Tasks;");
    }

    [Test]
    public void AddTest()
    {
        var cb = new ConnectionBuilder();
        TaskRepository taskRepository = new(cb);
        taskRepository.AddTask(new Task
        {
            Title = "Test Task",
            Description = "This is a test task.",
            DueDate = DateTime.Now,
            Finished = false
        });
        Assert.That(taskRepository.GetTaskWithId(1).Title, Is.EqualTo("Test Task"));
    }

    [Test]
    public void UpdateTask()
    {
        var cb = new ConnectionBuilder();
        TaskRepository taskRepository = new(cb);
        var task = taskRepository.GetTaskWithId(1);
        taskRepository.UpdateTask(1, new Task
        {
            Title = "Updated Task",
            Description = task.Description,
            DueDate = task.DueDate,
            Finished = task.Finished
        });
        
        Assert.That(taskRepository.GetTaskWithId(1).Title, Is.EqualTo("Updated Task"));
    }
}