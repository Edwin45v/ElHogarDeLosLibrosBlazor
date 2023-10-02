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
    public class QUIZService
    {
        private readonly HttpClient _httpClient;
        public QUIZService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        JsonSerializerOptions options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        public async Task<IEnumerable<QUIZ>> GetAll()
        {
            string resp = await _httpClient.GetStringAsync($"Alumno");
            return JsonSerializer.Deserialize<IEnumerable<QUIZ>>(resp, options);
        }

        public async Task<IEnumerable<QUIZ>> GetByAlumnos(int idQUIZ)
        {
            var resp = await _httpClient.PostAsJsonAsync($"QUIZ/Buscar", new { idQUIZ = idQUIZ });
            string respString = await resp.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<QUIZ>>(respString, options);
        }

        public async Task<QUIZ> GetById(int id)
        {
            string resp = await _httpClient.GetStringAsync($"QUIZ/{id}");
            return JsonSerializer.Deserialize<QUIZ>(resp, options);
        }
    }
}
