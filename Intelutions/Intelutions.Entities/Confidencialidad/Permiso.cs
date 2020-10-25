using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Intelutions.Entities.Confidencialidad
{
    public class Permiso
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
        public DateTime FechaPermiso { get; set; }
    }
}
