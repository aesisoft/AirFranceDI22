using AirFranceDI22Model.Dao;
using AirFranceDI22webSecure.Models;
using AirFranceDI22webSecure.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AirFranceDI22webSecure.Controllers;

public class AccountController(SignInManager<User> signInManager, UserManager<User> userManager) : Controller
{
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginVM model)
    {
        if (ModelState.IsValid)
        {
            //login
            var result = await signInManager.PasswordSignInAsync(model.Username!, model.Password!, model.RememberMe, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Invalid login attempt");
            return View(model);
        }
        return View(model);
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterVM model)
    {
        if (ModelState.IsValid)
        {
            User user = new()
            {
                //Name = model.Name,
                UserName = model.Email,
                Email = model.Email,
                //Address = model.Address
            };

            var result = await userManager.CreateAsync(user, model.Password!);

            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, false);

                return RedirectToAction("Index", "Home");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
        return View(model);
    }

    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();
        return RedirectToAction("Index","Home");
    }
}
