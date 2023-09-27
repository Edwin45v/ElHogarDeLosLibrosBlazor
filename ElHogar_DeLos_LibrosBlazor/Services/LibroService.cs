using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

using ElHogar_DeLos_LibrosBlazor.Models;

namespace ElHogar_DeLos_LibrosBlazor.Services
{
    public class LibroService : ILibroService
    {
        private readonly HttpClient _httpClient;
        public LibroService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Libro>> GetAll()
        {
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string resp = await _httpClient.GetStringAsync($"Libro");
            return JsonSerializer.Deserialize<IEnumerable<Libro>>(resp, options);
        }
    }
}
