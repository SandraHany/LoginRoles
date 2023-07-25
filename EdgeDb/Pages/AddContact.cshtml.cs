using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data;
using EdgeDB;
using Microsoft.AspNetCore.Http.Extensions;
using System;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authorization;

namespace EdgeDb.Pages;
[Authorize(Roles = "Admin")]
public class AddContactModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    [BindProperty]
    public ContactClass ContactObject { get; set; }

    private static string ConvertToEdgeDBLocalDate(DateTime date)
    {
        return $"<cal::local_date>'{date:yyyy-MM-dd}'";
    }
    public async Task<IActionResult> OnPost()
    {
        if (ModelState.IsValid)
        {
            ContactObject.IsMarried = Request.Form["radgroup"] == "Yes";
            var client = new EdgeDBClient();
            ContactObject.Password = ContactClass.HashPassword(ContactObject.Password);
            if (ContactObject != null)
            {
            var query = @"
                INSERT Contact {
                    first_name := <str>$first_name,
                    last_name := <str>$last_name,
                    email := <str>$email,
                    username := <str>$username,
                    password := <str>$password,
                    role := <str>$role,
                    title := <str>$title,
                    description := <str>$description,
                    date_of_birth := <str>$date_of_birth,
                    is_married := <bool>$is_married
                }
            ";
            var parameters = new Dictionary<string, object>
            {
                { "first_name", ContactObject.FirstName },
                { "last_name", ContactObject.LastName },
                { "email", ContactObject.Email },
                { "username", ContactObject.Username },
                { "password", ContactObject.Password },
                { "role", ContactObject.Role },
                { "title", ContactObject.Title },
                { "description", ContactObject.Description },
                { "date_of_birth",ContactObject.DateofBirth},
                { "is_married", ContactObject.IsMarried}
            };
                await client.ExecuteAsync(query, parameters);
            }
            ModelState.AddModelError(string.Empty, "Contact added successfully.");
        }
        return Page();
    }
}

