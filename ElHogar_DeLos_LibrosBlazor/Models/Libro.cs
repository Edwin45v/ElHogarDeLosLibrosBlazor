using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElHogar_DeLos_LibrosBlazor.Models
{
    public class Libro
    {
        public int Id { get; set; }
        public int IdQuiz { get; set; }
        public string Nombre { get; set; }
        public string Autor { get; set; }
        public int Categoria { get; set; }
        public string Imagen { get; set; }
    }
}
