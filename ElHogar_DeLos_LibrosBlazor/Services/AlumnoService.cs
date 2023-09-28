using ElHogar_DeLos_LibrosBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace ElHogar_DeLos_LibrosBlazor.Services
{
    public class AlumnoService : IAlumnoService
    {
        private readonly HttpClient _httpClient;
        public AlumnoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        JsonSerializerOptions options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        public async Task<IEnumerable<Alumno>> GetAll()
        {
            string resp = await _httpClient.GetStringAsync($"Alumno");
            return JsonSerializer.Deserialize<IEnumerable<Alumno>>(resp, options);
        }

        public async Task<IEnumerable<Alumno>> GetByAlumnos(int idAlumno)
        {
            var resp = await _httpClient.PostAsJsonAsync($"Alumno/Buscar", new { idAlumno = idAlumno });
            string respString = await resp.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<Alumno>>(respString, options);
        }

        public async Task<Alumno> GetById(int id)
        {
            string resp = await _httpClient.GetStringAsync($"Alumno/{id}");
            return JsonSerializer.Deserialize<Alumno>(resp, options);
        }
    }
}
