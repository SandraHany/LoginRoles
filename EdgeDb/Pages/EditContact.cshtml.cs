using EdgeDb.Pages;
using EdgeDB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Reflection.PortableExecutable;
namespace EdgeDb.Pages;
[Authorize(Roles = "Admin")]
public class EditContactModel : PageModel
{
    private readonly EdgeDBClient _edgeDBClient;
    public EditContactModel(EdgeDBClient edgeDBClient)
    {
        _edgeDBClient = edgeDBClient;
    }
    [BindProperty]
    public ContactClass Contact { get; set; }
    public async Task<IActionResult> OnGetAsync(Guid id)
    {
        var query = $@"SELECT Contact {{
            Id :=.id,
            FirstName := .first_name,
            LastName := .last_name,
            Email := .email,
            Username := .username,
            Role := .role,
            Title := .title,
            Description := .description,
            DateofBirth := .date_of_birth,
            IsMarried := .is_married
        }} FILTER .id = <uuid>$id;";
        var parameters = new Dictionary<string, object>
        {
            { "id", id }
        };
        var result = await _edgeDBClient.QueryAsync<ContactClass>(query,parameters);
        Contact = result.FirstOrDefault();
        if (Contact == null)
            return NotFound();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();
        var query = $@"
            UPDATE Contact 
                FILTER .id = <uuid>$id
                SET {{
                    first_name := <str>$first_name,
                    last_name := <str>$last_name,
                    email := <str>$email,
                    username := <str>$username,
                    role := <str>$role,
                    title := <str>$title,
                    description := <str>$description,
                    date_of_birth := <str>$date_of_birth,
                    is_married := <bool>$is_married
                }}

            ;";
        var parameters = new Dictionary<string, object>
        {
            { "id", Contact.Id },
            { "first_name", Contact.FirstName },
            { "last_name", Contact.LastName },
            { "email", Contact.Email },
            { "username", Contact.Username },
            { "role", Contact.Role },
            { "title", Contact.Title },
            { "description", Contact.Description },
            { "date_of_birth", Contact.DateofBirth },
            { "is_married", Contact.IsMarried }
        };
        await _edgeDBClient.ExecuteAsync(query, parameters);
        return RedirectToPage("./ContactsList");
    }
}