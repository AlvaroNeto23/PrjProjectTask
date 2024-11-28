using System;
using System.ComponentModel.DataAnnotations;

namespace PrjManagementApp.API.Models
{
    public class TaskModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Selecione um Projeto.")]
        public Guid ProjectId { get; set; }

        [Required(ErrorMessage = "Title tem preenchimento obrigatório.")]
        //[StringLength(100)]
        public string Title { get; set; }

        //[StringLength(500)]
        public string Description { get; set; }

        [Required(ErrorMessage = "IsCompleted tem preenchimento obrigatório.")]
        public bool IsCompleted { get; set; }

        [Required(ErrorMessage = "CreatedAt tem preenchimento obrigatório.")]
        public DateTime CreatedAt { get; set; }
    }
}