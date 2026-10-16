
using System.ComponentModel.DataAnnotations;

namespace TaskManager.API.DTOs;


public class UpdateTaskRequest
{
    [Required]
    [StringLength(100)]
    public string Title { get; set; } = string.Empty;

    public bool IsCompleted { get; set; }
}