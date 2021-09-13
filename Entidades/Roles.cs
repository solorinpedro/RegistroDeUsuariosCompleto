using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RegistroDeUsuarios.Entidades
{
    public class Roles
    {
        [Key]
        public int RollD { get; set; }
        public String Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public String Descripcion { get; set; }
    }
}
