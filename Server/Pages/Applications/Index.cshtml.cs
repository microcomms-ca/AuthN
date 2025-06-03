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
    public class IndexModel : PageModel
    {
        private readonly Server.Models.AuthNContext _context;

        public IndexModel(Server.Models.AuthNContext context)
        {
            _context = context;
        }

        public IList<Application> Application { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Application = await _context.Applications.ToListAsync();
        }
    }
}
