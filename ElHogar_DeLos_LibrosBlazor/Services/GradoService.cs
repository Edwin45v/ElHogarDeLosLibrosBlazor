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
    public class GradoService
    {
        private readonly HttpClient _httpClient;
        public GradoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        JsonSerializerOptions options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        public async Task<IEnumerable<Grado>> GetAll()
        {
            string resp = await _httpClient.GetStringAsync($"Grado");
            return JsonSerializer.Deserialize<IEnumerable<Grado>>(resp, options);
        }

        public async Task<IEnumerable<Grado>> GetByGrado(int idGrado)
        {
            var resp = await _httpClient.PostAsJsonAsync($"Grado/Buscar", new { idGrado = idGrado });
            string respString = await resp.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<Grado>>(respString, options);
        }

        public async Task<Grado> GetById(int id)
        {
            string resp = await _httpClient.GetStringAsync($"Grado/{id}");
            return JsonSerializer.Deserialize<Grado>(resp, options);
        }
    }
}
