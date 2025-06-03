using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Pages.Applications
{
    public class DetailsModel : PageModel
    {
        private readonly Server.Models.AuthNContext _context;

        public DetailsModel(Server.Models.AuthNContext context)
        {
            _context = context;
        }

        public Application Application { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var application = await _context.Applications.FirstOrDefaultAsync(m => m.Id == id);

            if (application is not null)
            {
                Application = application;

                return Page();
            }

            return NotFound();
        }
    }
}
