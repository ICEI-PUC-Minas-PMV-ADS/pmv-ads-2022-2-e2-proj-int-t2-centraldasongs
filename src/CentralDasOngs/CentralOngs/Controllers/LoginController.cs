using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CentralOngs.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CentralOngs.Controllers
{
    public class LoginController : Controller
    {
        protected readonly DatabaseContext _context;

        public LoginController(DatabaseContext context)
        {
        }


        // GET: UserOng
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserModel userModel)
        {
            //UserModel user = await _context.UserOngModel
            //    .FirstOrDefaultAsync(u => u.Email == userModel.Email);

            //UserModel userVoluntario = await _context.UserVoluntarioModel
            //    .FirstOrDefaultAsync(u => u.Email == userModel.Email);

            //if (user == null || userVoluntario == null)
            //{
            //    ViewBag.MensageLogin = "Usuario e/ou Senha invalidos";
            //    return View();
            //}

            //if( user == null)
            //{
            //    user = userVoluntario;
            //}

            //if (user.Password == userModel.Password)
            //{
            //    var claims = new List<Claim>
            //    {
            //        new Claim(ClaimTypes.Name, user.Name),
            //        new Claim(ClaimTypes.UserData, user.Id.ToString()),
            //        new Claim(ClaimTypes.NameIdentifier, user.Name),
            //        new Claim(ClaimTypes.Role, user.UserType.ToString())
            //    };

            //    var userIdentity = new ClaimsIdentity(claims, "login");
            //    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
            //    var properties = new AuthenticationProperties
            //    {
            //        AllowRefresh = true,
            //        ExpiresUtc = DateTime.Now.ToLocalTime().AddDays(7), // Definindo tempo de login do usuario no sistema
            //        IsPersistent = true
            //    };

            //    await HttpContext.SignInAsync(principal, properties);
            //    return Redirect("/"); //Redirecionaria para a home principal
            //}
            ViewBag.MensageLogin = "Usuario e/ou Senha invalidos";
            return View();
        }
    }
}
