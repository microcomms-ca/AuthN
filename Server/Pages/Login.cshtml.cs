
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Server.Models;

namespace Server.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public LoginRequest LoginRequest { get; set; } = default!;
        public void OnGet(LoginRequest loginRequest)
        {
            LoginRequest = loginRequest;
        }

        public IActionResult OnPost(LoginRequest loginRequest)
        {
            return Redirect(loginRequest.RedirectUri + "?code=" + loginRequest.Code + "&state=" + loginRequest.State + "&nonce=" + loginRequest.Nonce);
        }

    }
}
