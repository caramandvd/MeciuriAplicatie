using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MeciuriAplicatie.Data;
using MeciuriAplicatie.Models;

namespace MeciuriAplicatie.Pages.SportTeams
{
    public class DetailsModel : PageModel
    {
        private readonly MeciuriAplicatie.Data.MeciuriAplicatieContext _context;

        public DetailsModel(MeciuriAplicatie.Data.MeciuriAplicatieContext context)
        {
            _context = context;
        }

        public SportTeam SportTeam { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sportteam = await _context.SportTeam.FirstOrDefaultAsync(m => m.Id == id);
            if (sportteam == null)
            {
                return NotFound();
            }
            else
            {
                SportTeam = sportteam;
            }
            return Page();
        }
    }
}
