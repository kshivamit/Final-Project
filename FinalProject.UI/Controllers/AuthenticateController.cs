using Core.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.UI.Controllers
{
    public class AuthenticateController : Controller
    {
        private readonly IAuthenticate _IAuthenticateRepository;
        public AuthenticateController(IAuthenticate authenticateRepository)
        {
            _IAuthenticateRepository = authenticateRepository;
        }
        public IActionResult Index()
        {
            return View("~/Views/Authenticate/Login.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> LoginUser(AuthenticateModel model)
        {
            var response = await _IAuthenticateRepository.IsAuthenticate(model);
            if (response)
            {
                HttpContext.Session.SetString("Username", model.UserName);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Authenticate");
            }
        }
    }
}
