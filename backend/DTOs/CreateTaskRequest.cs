using System.ComponentModel.DataAnnotations;

namespace TaskManager.API.DTOs;

public class CreateTaskRequest
{
    [Required]
    [StringLength(100)]
    public string Title { get; set; } = string.Empty;

}

