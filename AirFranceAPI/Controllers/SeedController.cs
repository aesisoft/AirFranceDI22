using AirFranceDI22Model.Context;
using AirFranceDI22Model.Dao;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AirFranceAPI.Controllers;
public class SeedController(
    AirFranceDI22Context context, 
    UserManager<User> userManager,
    RoleManager<User> roleManager) : Controller
{
    public ActionResult<bool> InitRoles()
    {

        return true;
    }


    public ActionResult<bool> InitData()
    {

        if (context.Compagnies.Any()) return false;

        context.Compagnies.Add(new Compagnie { Nom = "Air France" });
        context.Compagnies.Add(new Compagnie { Nom = "Lufthansa" });
        context.Compagnies.Add(new Compagnie { Nom = "Air Waves" });
        context.Compagnies.Add(new Compagnie { Nom = "Transavia" });
        context.SaveChanges();

        context.Villes.Add(new Ville { Id = 1, Nom = "Pau" });
        context.Villes.Add(new Ville { Id = 2, Nom = "Paris" });
        context.Villes.Add(new Ville { Id = 3, Nom = "Saint-denis" });
        context.Villes.Add(new Ville { Id = 4, Nom = "Berlin" });
        context.Villes.Add(new Ville { Id = 5, Nom = "Lyon" });
        context.Villes.Add(new Ville { Id = 6, Nom = "New York" });
        context.Villes.Add(new Ville { Id = 7, Nom = "Tunis" });
        context.Villes.Add(new Ville { Id = 8, Nom = "Toulouse" });
        context.Villes.Add(new Ville { Id = 9, Nom = "Madrid" });
        context.SaveChanges();

        context.Aeroports.Add(new Aeroport { Nom = "Pau", VilleId = 1 });
        context.Aeroports.Add(new Aeroport { Nom = "Orly", VilleId = 2 });
        context.Aeroports.Add(new Aeroport { Nom = "Charles De Gaulle", VilleId = 2 });
        context.Aeroports.Add(new Aeroport { Nom = "Saint-denis", VilleId = 3 });
        context.Aeroports.Add(new Aeroport { Nom = "Berlin", VilleId = 4 });
        context.Aeroports.Add(new Aeroport { Nom = "Lyon", VilleId = 5 });
        context.Aeroports.Add(new Aeroport { Nom = "New York JFK", VilleId = 6 });
        context.Aeroports.Add(new Aeroport { Nom = "Tunis", VilleId = 7 });
        context.Aeroports.Add(new Aeroport { Nom = "Toulouse", VilleId = 8 });
        context.Aeroports.Add(new Aeroport { Nom = "Adolfo Suarez", VilleId = 9 });
        context.SaveChanges();

        return true;
    }
}
