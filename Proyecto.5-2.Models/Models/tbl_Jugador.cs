//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------
using System.ComponentModel.DataAnnotations;
namespace Proyecto._5_2.Models.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_Jugador
    {
        
        public int JugadorID { get; set; }

        [Required(ErrorMessage = "El Nombre es Obligatorio")]
        [MinLength(3, ErrorMessage = "El nombre del estudiante debe tener al menos 3 caracteres")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "El Apellido es Obligatorio")]
        [MinLength(3, ErrorMessage = "El Apellido del estudiante debe tener al menos 3 caracteres")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "El Edad es Obligatoria")]
        [MinLength(3, ErrorMessage = "El nombre del estudiante debe tener al menos 3 caracteres")]
        public Nullable<int> Edad { get; set; }

        [Required(ErrorMessage = "La posicion es Obligatorio")]
        [MinLength(3, ErrorMessage = "La posicion del estudiante debe tener al menos 3 caracteres")]
        public string Posicion { get; set; }

        [Required(ErrorMessage = "El Nombre es Obligatorio")]
        public int EquipoID { get; set; }

        [Required(ErrorMessage = "El Nombre es Obligatorio")]
        public virtual tbl_Equipo tbl_Equipo { get; set; }
    }
}
