using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace MahChat.Pages
{
    public class LoginModel : PageModel
    {
        [Required,BindProperty]
        public string Username { get; set; }

        [Required, BindProperty]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }


        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }


        public IActionResult OnPost([FromQuery] string returnUrl = null)
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            //string username = Request.Form["username"];
            //string password = Request.Form["password"];


            string username = Username;
            string password = Password;

            if (password != "mahdiar") return Page();

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,username),
                new Claim(ClaimTypes.Role,"support")
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var properties = new AuthenticationProperties
            {
                RedirectUri = returnUrl ?? Url.Content("~/")
            };

            return SignIn(new ClaimsPrincipal(identity), properties, CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
