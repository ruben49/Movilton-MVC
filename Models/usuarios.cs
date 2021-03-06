//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace movilton_mvc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class usuarios
    {
        public usuarios()
        {
            this.articulos = new HashSet<articulos>();
            this.perfil_empresa = new HashSet<perfil_empresa>();
        }
    
        public int id_user { get; set; }
      
        
        [Display(Name = "Nombre de usuario")]
        [Required]
        public string nombre_usuario { get; set; }
        
        
        [Display(Name = "Nombres")]
        public string nombres { get; set; }

        
        [Display(Name = "Apellidos")]
        public string apellidos { get; set; }

        
        [Display(Name = "Email")]
        public string email { get; set; }

        
        [Display(Name = "Teléfono")]
        public int telefono { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string password { get; set; }

        public int tipo_user { get; set; }
        public int estado { get; set; }
        public int usuario_activo { get; set; }
    
        public virtual ICollection<articulos> articulos { get; set; }
        public virtual ICollection<perfil_empresa> perfil_empresa { get; set; }
    }
}
