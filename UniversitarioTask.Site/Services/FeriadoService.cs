using System.Net.Http.Json;
using UniversitarioTask.Site.Models;

namespace UniversitarioTask.Site.Services
{
    public class FeriadoService
    {
        private readonly HttpClient _httpClient;

        public FeriadoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<FeriadoModel>> BuscarFeriados(int ano)
        {

            try
            {
                var url = $"https://brasilapi.com.br/api/feriados/v1/{ano}";
                var feriados = await _httpClient.getFromJsonAsync<List<FeriadoModel>>(url);
                return feriados ?? new List<FeriadoModel>();
            }
            catch
            {
                return new List<FeriadoModel>();
            }
        }
    }
}
