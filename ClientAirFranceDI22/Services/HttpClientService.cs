using AirFranceDI22Model.Dao;
using AirFranceDI22Model.Dto;
using ClientAirFranceDI22.Models;
using ClientAirFranceDI22.ViewModels;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Windows.Xps.Serialization;

namespace ClientAirFranceDI22.Services
{
    public static class HttpClientService
    {
        private const string baseAddress = "https://localhost:7139/";
        private static HttpClient? client = null;

        private static HttpClient Client
        {
            get
            {
                if (client == null)
                    client = new() { BaseAddress = new Uri(baseAddress) };
                return client;
            }
        }

        public static async Task<bool> Login(string email, string pwd)
        {
            string route = "login?useCookies=true&useSessionCookies=true";
            var jsonString = JsonConvert.SerializeObject(new LoginUser
            {
                Email = email,
                Password = pwd
            });

            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await Client.PostAsync(route, httpContent);
            return response.IsSuccessStatusCode ? true :
                throw new Exception(response.ReasonPhrase);
        }



        public static async Task<List<VolLightDto>> GetVolLights(DateTime dateJour)
        {
            string route = $"api/vols/search/{dateJour.ToString("yyyy-MM-dd")}";
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
            string route = $"api/clients";
            var jsonString = JsonConvert.SerializeObject(client);

            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await Client.PostAsync(route, httpContent);
            return response.IsSuccessStatusCode ? true : 
                throw new Exception(response.ReasonPhrase);
        }

    }
}
