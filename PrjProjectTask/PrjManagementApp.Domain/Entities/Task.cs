using System.ComponentModel.DataAnnotations;

namespace PrjManagementApp.Domain.Entities;

public class Task
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public Guid ProjectId { get; set; }

    [Required]
    [MaxLength(200)]
    public string Title { get; set; }

    public string Description { get; set; }

    [Required]
    public bool IsCompleted { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    public Project Project { get; set; }
}