using FPT_BOOKSHOP.Models.DTO;
using FPT_BOOKSHOP.Repositories.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace FPT_BOOKSHOP.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class AccountController : Controller
    {
        private readonly IUserAuthenticationService _service;
        public AccountController(IUserAuthenticationService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult AddAccount()
        {
            return View();
        }

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

        public IActionResult ResetPassword(string username)
        {
            TempData["user"] = username;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var result = await _service.ResetPasswordAsync(model, (string)TempData["user"]);
            TempData["msg"] = result.Message;
            return RedirectToAction("ResetPassword", "Account");
        }
    }
}
