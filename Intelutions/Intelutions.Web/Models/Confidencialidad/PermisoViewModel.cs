using System;
using System.ComponentModel.DataAnnotations;

namespace Intelutions.Web.Models.Confidencialidad
{
    public class PermisoViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string NombreEmpleado { get; set; }
        [Required]
        public string ApellidosEmpleado { get; set; }
        [Required]
        public int TipoPermiso { get; set; }
        [Required]
        public DateTime? FechaPermiso { get; set; }
    }
}
