using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElHogar_DeLos_LibrosBlazor.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public int RolId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Estatus { get; set; }
        public DateTime FechaRegistro { get; set; } 
    }
}
