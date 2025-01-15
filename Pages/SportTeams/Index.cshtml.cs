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
    public class IndexModel : PageModel
    {
        private readonly MeciuriAplicatie.Data.MeciuriAplicatieContext _context;

        public IndexModel(MeciuriAplicatie.Data.MeciuriAplicatieContext context)
        {
            _context = context;
        }

        public IList<SportTeam> SportTeam { get;set; } = default!;

        public async Task OnGetAsync()
        {
            SportTeam = await _context.SportTeam.ToListAsync();
        }
    }
}
