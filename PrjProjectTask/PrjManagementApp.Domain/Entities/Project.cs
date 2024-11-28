using System.ComponentModel.DataAnnotations;

namespace PrjManagementApp.Domain.Entities;

public class Project
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [MaxLength(200)]
    public string Name { get; set; }

    public string Description { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    public ICollection<Task> Tasks { get; set; } = new List<Task>();
}