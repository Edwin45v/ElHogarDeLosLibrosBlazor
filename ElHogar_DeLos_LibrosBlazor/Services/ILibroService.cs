using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElHogar_DeLos_LibrosBlazor.Models;

namespace ElHogar_DeLos_LibrosBlazor.Services
{
    public interface ILibroService 
    {
        Task<IEnumerable<Libro>> GetAll();
    }
}
