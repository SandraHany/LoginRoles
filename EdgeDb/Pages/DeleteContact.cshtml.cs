using EdgeDB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Threading.Tasks;

namespace EdgeDb.Pages;
[Authorize(Roles = "Admin")]
public class DeleteContactModel : PageModel
{
    private readonly EdgeDBClient _edgeDBClient;
    public DeleteContactModel(EdgeDBClient edgeDBClient)
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
        var result = await _edgeDBClient.QueryAsync<ContactClass>(query, parameters);
        Contact = result.FirstOrDefault();
        if (Contact == null)
            return NotFound();
        return Page();
    }
    public async Task<IActionResult> OnPostAsync(Guid id)
    {
        var query = $@"DELETE Contact FILTER .id = <uuid>'{id}';";
        await _edgeDBClient.ExecuteAsync(query);
        return RedirectToPage("./ContactsList");
    }

}