using AirFranceDI22Model.Context;
using AirFranceDI22Model.Dao;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AirFranceAPI.Controllers;

/// <summary>
/// Controleur peremettant de récupérer les informations de l'utilisateur connecté
/// à utiliser après un login
/// </summary>
[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CurrentUserController : ControllerBase
{    
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public CurrentUserController( UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager=roleManager;
    }

    // Get: api/CurrentUser
    [HttpGet]
    public async Task<ActionResult<User>> GetUser()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    // Get: api/CurrentUser/Roles
    [HttpGet]
    [Route("Roles")]
    public async Task<ActionResult<IList<string>>> GetUserRoles()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return NotFound();
        }

        var roles = await _userManager.GetRolesAsync(user);
        return Ok(roles);
    }



}
