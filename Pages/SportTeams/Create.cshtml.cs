using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MeciuriAplicatie.Data;
using MeciuriAplicatie.Models;

namespace MeciuriAplicatie.Pages.SportTeams
{
    public class CreateModel : PageModel
    {
        private readonly MeciuriAplicatie.Data.MeciuriAplicatieContext _context;

        public CreateModel(MeciuriAplicatie.Data.MeciuriAplicatieContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public SportTeam SportTeam { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.SportTeam.Add(SportTeam);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
