using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MeciuriAplicatie.Data;
using MeciuriAplicatie.Models;

namespace MeciuriAplicatie.Pages.SportTeams
{
    public class EditModel : PageModel
    {
        private readonly MeciuriAplicatie.Data.MeciuriAplicatieContext _context;

        public EditModel(MeciuriAplicatie.Data.MeciuriAplicatieContext context)
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

            var sportteam =  await _context.SportTeam.FirstOrDefaultAsync(m => m.Id == id);
            if (sportteam == null)
            {
                return NotFound();
            }
            SportTeam = sportteam;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(SportTeam).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SportTeamExists(SportTeam.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SportTeamExists(int id)
        {
            return _context.SportTeam.Any(e => e.Id == id);
        }
    }
}
