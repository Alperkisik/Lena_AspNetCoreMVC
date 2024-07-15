using Application.Login.Requests;
using Application.Login.Services.Abstract;
using Application.Login.Services.Concrete;
using Domain.Common;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Domain.Dtos;

namespace Lena_AspNetCoreMVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService loginService;

        public LoginController(ILoginService loginService)
        {
            this.loginService = loginService;
        }
        public IActionResult Index()
        {
            return View(new LoginRequest
            {
                Username = "",
                Password = "",
                RememberMe = false
            });
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> LoginVerify(LoginRequest loginRequest, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid) return Json(Result.Failure("Username or Password is incorrect."));

            var result = await loginService.LoginVerify(loginRequest, cancellationToken);

            if (result.IsFailure) return Json(result);

            SignIn(GetClaims(result.Data as User), loginRequest.RememberMe);

            var redirectTo = RedirectToUrl();

            return Json(Result.Success(redirectTo));
        }

        private async void SignIn(List<Claim> claims, bool isPersistent)
        {
            var expiresUtc = isPersistent ? DateTimeOffset.UtcNow.AddMonths(3) : DateTimeOffset.UtcNow.AddDays(1);

            var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
               CookieAuthenticationDefaults.AuthenticationScheme,
               new ClaimsPrincipal(claimIdentity),
               new AuthenticationProperties
               {
                   ExpiresUtc = expiresUtc,
                   IsPersistent = isPersistent
               });
        }

        private List<Claim> GetClaims(User user)
        {
            return new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name)
            };
        }

        private string RedirectToUrl()
        {
            return Url.Action("Index", "FormManagement")!;
        }
    }
}
