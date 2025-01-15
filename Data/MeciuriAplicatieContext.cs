using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MeciuriAplicatie.Models;

namespace MeciuriAplicatie.Data
{
    public class MeciuriAplicatieContext : DbContext
    {
        public MeciuriAplicatieContext (DbContextOptions<MeciuriAplicatieContext> options)
            : base(options)
        {
        }

        public DbSet<MeciuriAplicatie.Models.SportTeam> SportTeam { get; set; } = default!;
    }
}
