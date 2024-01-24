using AirFranceDI22Model.Dao;
using AirFranceDI22Model.Dto;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;

namespace ClientAirFranceDI22.Services
{
    public static class HttpClientService
    {
        private const string baseAddress = "https://localhost:7139/api/";
        private static HttpClient Client { get 
                => new() { BaseAddress = new Uri(baseAddress) }; }
        public static async Task<List<VolLightDto>> GetVolLights(DateTime dateJour)
        {
            string route = $"vols/search/{dateJour.ToString("yyyy-MM-dd")}";
            var response = await Client.GetAsync(route);
            if (response.IsSuccessStatusCode)
            {
                string resultat = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<VolLightDto>>(resultat)
                ?? throw new FormatException($"Erreur Http : {route}");
            }
            throw new Exception(response.ReasonPhrase);
        }

        public static async Task<bool> PostClient(Client client)
        {
            string route = $"clients";
            var jsonString = JsonConvert.SerializeObject(client);

            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var response = await Client.PostAsync(route, httpContent);
            return response.IsSuccessStatusCode ? true : 
                throw new Exception(response.ReasonPhrase);
        }

    }
}
