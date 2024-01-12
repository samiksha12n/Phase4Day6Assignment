using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Phase4Day6Assignment.Models;

namespace Phase4Day6Assignment.Data
{
    public class Phase4Day6AssignmentDbContext : DbContext
    {
        public Phase4Day6AssignmentDbContext (DbContextOptions<Phase4Day6AssignmentDbContext> options)
            : base(options)
        {
        }

        public DbSet<Phase4Day6Assignment.Models.Movies> Movies { get; set; } = default!;
    }
}
