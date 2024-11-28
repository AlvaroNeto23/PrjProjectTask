using System;
using System.ComponentModel.DataAnnotations;

namespace PrjManagementApp.API.DTOs
{
    public class ProjectModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name tem preenchimento obrigatório.")]
        [StringLength(100, ErrorMessage = "Preencha o campo Name com o máximo de 100 caracteres.")]
        public string Name { get; set; }

        [StringLength(500, ErrorMessage = "Preencha o campo Description com o máximo de 500 caracteres.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "CreatedAt tem preenchimento obrigatório.")]
        public DateTime CreatedAt { get; set; }
    }
}