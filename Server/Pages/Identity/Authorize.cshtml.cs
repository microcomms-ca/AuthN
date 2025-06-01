using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Server.Models;

namespace Server.Pages.Identity
{
    public class AuthorizeModel : PageModel
    {
        public IActionResult OnGet(AuthRequest request)
        {
            return RedirectToPage("/Login", new LoginRequest
            {
                Code = Guid.NewGuid().ToString(),
                RedirectUri = request.redirect_uri,
                Nonce = Guid.NewGuid().ToString(),
                RequestedScopes = [request.scope],
                State = request.state
            });
        }
    }
}