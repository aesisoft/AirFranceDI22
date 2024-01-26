using AirFranceDI22Model.Context;
using AirFranceDI22Model.Dao;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AirFranceAPI.Controllers;

/// <summary>
/// Controleur permettant de créer le jeu de données initial
/// à utiliser après une migration 
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class SeedsController : ControllerBase
{
    private readonly AirFranceDI22Context _context;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public SeedsController(AirFranceDI22Context context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    {
        _context = context;
        _userManager = userManager;
        _roleManager=roleManager;
    }

    // POST: api/Seeds/CreateRoles
    [HttpPost]
    [Route("CreateRoles")]
    public async Task<ActionResult<bool>> PostCreateRoles()
    {
        if (!(await _roleManager.RoleExistsAsync("Administrateur")))
        {
            await _roleManager.CreateAsync(new IdentityRole("Administrateur"));
        }
        if (!(await _roleManager.RoleExistsAsync("Utilisateur")))
        {
            await _roleManager.CreateAsync(new IdentityRole("Utilisateur"));
        }
        return true;
    }

    // POST: api/Seeds/CreateUsers
    [HttpPost]
    [Route("CreateUsers")]
    public async Task<ActionResult<bool>> PostCreateUsers()
    {

        //Création d'un utilisateur admin
        if(!_userManager.Users.Where(u => u.UserName == "admin").Any())
        {
            var user = new User();
            user.UserName = "admin";
            user.Email = "admin@default.com";
            string userPWD = "123@Abc";

            IdentityResult chkUser = await _userManager.CreateAsync(user, userPWD);

            //ajout du role Admin    
            if (chkUser.Succeeded)
            {
                var result = await _userManager.AddToRoleAsync(user, "Administrateur");
            }
        }

        //Création d'un utilisateur user
        if (!_userManager.Users.Where(u => u.UserName == "nadine").Any())
        {
            var user = new User();
            user.UserName = "nadine";
            user.Email = "nadine@default.com";
            string userPWD = "123@Abc";

            IdentityResult chkUser = await _userManager.CreateAsync(user, userPWD);

            //ajout du role Admin    Administrateur
            if (chkUser.Succeeded)
            {
                var result = await _userManager.AddToRoleAsync(user, "Utilisateur");
            }
        }
       


        return true;
    }

    // POST: api/Seeds/InitDatas
    [HttpPost]
    [Route("InitDatas")]
    public async Task<ActionResult<bool>> PostInitDatas()
    {
        if (_context.Compagnies.Any()) return true;

        _context.Compagnies.Add(new Compagnie { Nom = "Air France" });
        _context.Compagnies.Add(new Compagnie { Nom = "Lufthansa" });
        _context.Compagnies.Add(new Compagnie { Nom = "Air Waves" });
        _context.Compagnies.Add(new Compagnie { Nom = "Transavia" });
        await _context.SaveChangesAsync();

        _context.Villes.Add(new Ville { Id = 1, Nom = "Pau" });
        _context.Villes.Add(new Ville { Id = 2, Nom = "Paris" });
        _context.Villes.Add(new Ville { Id = 3, Nom = "Saint-denis" });
        _context.Villes.Add(new Ville { Id = 4, Nom = "Berlin" });
        _context.Villes.Add(new Ville { Id = 5, Nom = "Lyon" });
        _context.Villes.Add(new Ville { Id = 6, Nom = "New York" });
        _context.Villes.Add(new Ville { Id = 7, Nom = "Tunis" });
        _context.Villes.Add(new Ville { Id = 8, Nom = "Toulouse" });
        _context.Villes.Add(new Ville { Id = 9, Nom = "Madrid" });
        await _context.SaveChangesAsync();

        _context.Aeroports.Add(new Aeroport { Nom = "Pau", VilleId = 1 });
        _context.Aeroports.Add(new Aeroport { Nom = "Orly", VilleId = 2 });
        _context.Aeroports.Add(new Aeroport { Nom = "Charles De Gaulle", VilleId = 2 });
        _context.Aeroports.Add(new Aeroport { Nom = "Saint-denis", VilleId = 3 });
        _context.Aeroports.Add(new Aeroport { Nom = "Berlin", VilleId = 4 });
        _context.Aeroports.Add(new Aeroport { Nom = "Lyon", VilleId = 5 });
        _context.Aeroports.Add(new Aeroport { Nom = "New York JFK", VilleId = 6 });
        _context.Aeroports.Add(new Aeroport { Nom = "Tunis", VilleId = 7 });
        _context.Aeroports.Add(new Aeroport { Nom = "Toulouse", VilleId = 8 });
        _context.Aeroports.Add(new Aeroport { Nom = "Adolfo Suarez", VilleId = 9 });
        await _context.SaveChangesAsync();

        return true;
    }

}
