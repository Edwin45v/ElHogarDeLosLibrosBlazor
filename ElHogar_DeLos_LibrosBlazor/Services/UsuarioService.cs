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
    public class UsuarioService
    {
        private readonly HttpClient _httpClient;
        public UsuarioService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        JsonSerializerOptions options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        public async Task<IEnumerable<Usuario>> GetAll()
        {
            string resp = await _httpClient.GetStringAsync($"Usuario");
            return JsonSerializer.Deserialize<IEnumerable<Usuario>>(resp, options);
        }

        public async Task<IEnumerable<Usuario>> GetByRol(int idUsuario)
        {
            var resp = await _httpClient.PostAsJsonAsync($"Usuario/Buscar", new { idUsuario = idUsuario });
            string respString = await resp.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<Usuario>>(respString, options);
        }

        public async Task<Usuario> GetById(int id)
        {
            string resp = await _httpClient.GetStringAsync($"Usuario/{id}");
            return JsonSerializer.Deserialize<Usuario>(resp, options);
        }
    }
}
