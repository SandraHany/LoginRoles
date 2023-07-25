using EdgeDB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Reflection.PortableExecutable;
namespace EdgeDb.Pages;
[Authorize]
public class ContactsListModel : PageModel
{
    public List<ContactClass> Contacts { get; set; } = new();
    public string? SearchFirstName { get; set; } = string.Empty;
    public string? SearchLastName { get; set; } = string.Empty;
    public string? SearchEmail { get; set; } = string.Empty;
    private readonly EdgeDBClient _edgeDBClient;
    public ContactsListModel(EdgeDBClient edgeDBClient)
    {
        _edgeDBClient = edgeDBClient;
    }
    public async Task OnGetAsync()
    {
        var query = @"SELECT Contact { Id :=.id, FirstName :=.first_name, LastName :=.last_name, Email :=.email, Username :=.username, Password :=.password, Role :=.role, Title :=.title, Description :=.description, DateofBirth :=.date_of_birth, IsMarried :=.is_married };";
        var result = await _edgeDBClient.QueryAsync<ContactClass>(query);
        Contacts = result.ToList();
    }
    public async Task OnPostFilterFirstName()
    {
        await FilterFirstName();
    }
    private async Task FilterFirstName()
    {
        var client = new EdgeDBClient();
        if (!string.IsNullOrEmpty(SearchFirstName))
        {
            var result = await client.QueryAsync<ContactClass>($"SELECT Contact {{ Id :=.id, FirstName :=.first_name, LastName :=.last_name, Email :=.email, Username :=.username, Password :=.password, Role :=.role, Title :=.title, Description :=.description, DateofBirth :=.date_of_birth, IsMarried :=.is_married }} FILTER .first_name ILIKE '%{SearchFirstName}%'");
            Contacts = result.ToList();
        }
    }
    public async Task OnPostFilterLastName()
    {
        await FilterLastName();
    }
    private async Task FilterLastName()
    {
        var client = new EdgeDBClient();
        if (!string.IsNullOrEmpty(SearchFirstName))
        {
            var result = await client.QueryAsync<ContactClass>($"SELECT Contact {{ Id :=.id, FirstName :=.first_name, LastName :=.last_name, Email :=.email, Username :=.username, Password :=.password, Role :=.role, Title :=.title, Description :=.description, DateofBirth :=.date_of_birth, IsMarried :=.is_married}} FILTER .last_name ILIKE '%{SearchLastName}%'");
            Contacts = result.ToList();
        }
    }
    public async Task OnPostFilterEmail()
    {
        await FilterEmail();
    }
    private async Task FilterEmail()
    {
        var client = new EdgeDBClient();
        if (!string.IsNullOrEmpty(SearchFirstName))
        {
            var result = await client.QueryAsync<ContactClass>($"SELECT Contact {{ Id :=.id, FirstName :=.first_name, LastName :=.last_name, Email :=.email, Username :=.username, Password :=.password, Role :=.role, Title :=.title, Description :=.description, DateofBirth :=.date_of_birth, IsMarried :=.is_married }} FILTER .email ILIKE '%{SearchEmail}%'");
            Contacts = result.ToList();
        }
    }
}

