using FPT_BOOKSHOP.Models.DTO;
using FPT_BOOKSHOP.Repositories.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FPT_BOOKSHOP.Controllers
{
    public class UserAuthenticationController : Controller
    {
        private readonly IUserAuthenticationService _service;
        public UserAuthenticationController(IUserAuthenticationService service)
        {
            this._service = service;
        }
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            model.Role = "Customer";
            var result = await _service.RegistrationAsync(model);
            TempData["msg"] = result.Message;
            return RedirectToAction(nameof(Registration));
        }
        
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _service.LoginAsync(model);
            if(result.StatusCode == 1)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["msg"] = result.Message;
                return RedirectToAction(nameof(Login));
            }
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _service.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult>ChangePassword(ChangePasswordModel model)
        {
            if (!ModelState.IsValid)
              return View(model);
            var result = await _service.ChangePasswordAsync(model, User.Identity.Name);
            TempData["msg"] = result.Message;
            return RedirectToAction("ChangePassword", "UserAuthentication");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AddAccount()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddAccount(RegistrationModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await _service.RegistrationAsync(model);
            TempData["msg"] = result.Message;
            return RedirectToAction(nameof(AddAccount));
        }

        [Authorize(Roles = "Admin")]
        public IActionResult ResetPassword(string username)
        {
            TempData["user"] = username;
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var result = await _service.ResetPasswordAsync(model, (string)TempData["user"]);
            TempData["msg"] = result.Message;
            return RedirectToAction("ResetPassword", "UserAuthentication");
        }
    }
}