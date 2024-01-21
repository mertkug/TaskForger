using System.ComponentModel.DataAnnotations;

namespace TaskForger.Entities;

public class Task
{
    public int TaskId { get; init; }
    public string Description { get; init; } = "";
    public string Title { get; init; } = "";
    
    public DateTime DueDate { get; init; } 
    
    public bool Finished { get; init; }
}