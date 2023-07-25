using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data;
using EdgeDB;
using Microsoft.AspNetCore.Http.Extensions;
using System;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using System.IO;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace EdgeDb.Pages;
public class IndexModel : PageModel
{
    [BindProperty]
    public LoginInput LoginInput { get; set; }
    public bool IsLoggedIn = false;
    public async Task<ContactClass> AuthenticateUser(string username, string password)
    {
        ContactClass user = null;
        var client = new EdgeDBClient();
        if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
        {
            string hashed = ContactClass.HashPassword(password);
            var result = await client.QueryAsync<ContactClass>($"SELECT Contact {{ FirstName :=.first_name, LastName :=.last_name, Email :=.email, Username :=.username, Password :=.password, Role :=.role, Title :=.title, Description :=.description, DateofBirth :=.date_of_birth, IsMarried :=.is_married }} FILTER .username = '{username}' ");
            if (result.Any())
            {
                user = result.First();
                string filePath = "debug.txt";
                using (var streamWriter = new StreamWriter(filePath))
                {
                    streamWriter.WriteLine(user.Username);
                    streamWriter.WriteLine(user.Password);
                }
            }
        }
        return await Task.FromResult(user);
    }
    public async Task<IActionResult> OnPostAsync()
    {
        if (ModelState.IsValid)
        {
            var user = await AuthenticateUser(LoginInput.Username, LoginInput.Password);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return Page();
            }
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
            };
            if (user.Role == "Admin")
            {
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            }
            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));
            return RedirectToPage("/ContactsList");
        }
        return Page();
    }
    public void OnGet()
    {
        if (User.Identity.IsAuthenticated)
        {
            IsLoggedIn = true;
            RedirectToPage("/ContactsList");
        }
    }
    public async Task<IActionResult> OnPostLogout()
    {
        await HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme
        );
        return RedirectToPage();
    }
}
public class LoginInput
{
    [Required(ErrorMessage = "Username is required.")]
    public string Username { get; set; }
    [Required(ErrorMessage = "Password is required.")]
    public string Password { get; set; }
}