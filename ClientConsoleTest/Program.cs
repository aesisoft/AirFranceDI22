
using System.Text;

const string baseAddress = "https://localhost:7139/";
HttpClient client = new() { BaseAddress = new Uri(baseAddress) };


// Login
var jsonString = "{ \"email\": \"nadine.clavere@equadex.net\", \"password\": \"MotDePasse@2024\" }";
var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
var response = await client.PostAsync("login?useCookies=true&useSessionCookies=true", httpContent);
Console.WriteLine(response);


// Accès autorisé
HttpClient client2 = new() { BaseAddress = new Uri(baseAddress) };
response = await client2.GetAsync("WeatherForecast");
if (response.IsSuccessStatusCode)
{
    string resultat = await response.Content.ReadAsStringAsync();
    Console.WriteLine(resultat);
}
else Console.WriteLine(response);


Console.ReadKey();