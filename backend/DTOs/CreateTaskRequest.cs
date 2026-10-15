using System.ComponentModel.DataAnnotations;
using TaskManager.API.Models;

namespace TaskManager.API.DTOs;

public class CreateTaskRequest
{
    [Required]
    [StringLength(100)]
    public string Title { get; set;} = string.Empty;

}