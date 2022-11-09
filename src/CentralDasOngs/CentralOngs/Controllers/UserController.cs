using System;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CentralOngs.Controllers
{
    public class UserController<T> : Controller
    {
        protected readonly DatabaseContext _context;

        public UserController(DatabaseContext context)
        {
            _context = context;
        }

        protected void createViewStateAndBank()
        {
            ViewData["StateList"] = new SelectList(_context.StateModel, "Name", "Name");
            ViewData["BankList"] = new SelectList(_context.BankModel, "Code", "Name");
        }

        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

    }
}

