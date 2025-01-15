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
    public class DeleteModel : PageModel
    {
        private readonly MeciuriAplicatie.Data.MeciuriAplicatieContext _context;

        public DeleteModel(MeciuriAplicatie.Data.MeciuriAplicatieContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sportteam = await _context.SportTeam.FindAsync(id);
            if (sportteam != null)
            {
                SportTeam = sportteam;
                _context.SportTeam.Remove(SportTeam);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
