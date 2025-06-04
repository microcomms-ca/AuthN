using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Server.Models;

namespace Server.Pages.Applications
{
    public class CreateModel : PageModel
    {
        private readonly Server.Models.AuthNContext _context;

        public CreateModel(Server.Models.AuthNContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            Application = new Application();
            // Generate a random 5-digit number for ClientId
            var random = new Random();
            Application.ClientId = random.Next(10000, 100000);
            
            Application.ClientSecret = Guid.NewGuid().ToString();

          
            Application.IssueDate = DateOnly.FromDateTime(DateTime.Today);
            Application.ExpiryDate = DateOnly.FromDateTime(DateTime.Today.AddMonths(1));

            return Page();
        }

        [BindProperty]
        public Application Application { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Applications.Add(Application);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
