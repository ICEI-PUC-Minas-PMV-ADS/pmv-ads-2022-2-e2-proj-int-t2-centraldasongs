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
using System.Xml.Linq;

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


        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DoLogin([Bind("Email, Password")] UserVoluntarioModel userVoluntarioModel)
        {
            UserVoluntarioModel user = await _context.UserVoluntarioModel
                  .Where(u => u.Email == userVoluntarioModel.Email)
                  .FirstOrDefaultAsync<UserVoluntarioModel>();

            if (user == null)
            {
                ViewBag.MensageLogin = "Usuario e/ou Senha invalidos";
                return View();
            }

            if (user.Password == userVoluntarioModel.Password)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.UserData, user.Id.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, user.Name),
                    new Claim(ClaimTypes.Role, user.UserType.ToString())
                };

                var userIdentity = new ClaimsIdentity(claims, "login");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                var properties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    ExpiresUtc = DateTime.Now.ToLocalTime().AddDays(7),
                };
                await HttpContext.SignInAsync(principal, properties);
                return Redirect("/");
            }
            ViewBag.MensageLogin = "Usuario e/ou Senha invalidos";
            return View();
        }
    }
}
