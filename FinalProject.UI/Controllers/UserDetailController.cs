using Core.Entity;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.UI.Controllers
{
    public class UserDetailController : Controller
    {
        private readonly IAuthenticate _IAuthenticateRepository;
        public UserDetailController(IAuthenticate authenticateRepository)
        {
            _IAuthenticateRepository = authenticateRepository;
        }
        public IActionResult Index()
        {
            return View("~/Views/Authenticate/CreateUserDetail.cshtml");
        }
        public async Task<IActionResult> CreateUser(AuthenticateModel model)
        {
            var response = await _IAuthenticateRepository.CreateUser(model);
            return Json(response);
        }
    }
}
