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
    public class RolService
    {
        private readonly HttpClient _httpClient;
        public RolService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        JsonSerializerOptions options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        public async Task<IEnumerable<Rol>> GetAll()
        {
            string resp = await _httpClient.GetStringAsync($"Rol");
            return JsonSerializer.Deserialize<IEnumerable<Rol>>(resp, options);
        }

        public async Task<IEnumerable<Rol>> GetByRol(int idRol)
        {
            var resp = await _httpClient.PostAsJsonAsync($"Rol/Buscar", new { idRol = idRol });
            string respString = await resp.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<Rol>>(respString, options);
        }

        public async Task<Rol> GetById(int id)
        {
            string resp = await _httpClient.GetStringAsync($"Rol/{id}");
            return JsonSerializer.Deserialize<Rol>(resp, options);
        }
    }
}
