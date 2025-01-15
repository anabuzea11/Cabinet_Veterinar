using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Cabinet_Veterinar.Models;

namespace Cabinet_Veterinar.Data
{
    public class Cabinet_VeterinarContext : IdentityDbContext
    {
        public Cabinet_VeterinarContext (DbContextOptions<Cabinet_VeterinarContext> options)
            : base(options)
        {
        }

        public DbSet<Cabinet_Veterinar.Models.Pacient> Pacient { get; set; } = default!;
        public DbSet<Cabinet_Veterinar.Models.Proprietar> Proprietar { get; set; } = default!;
        public DbSet<Cabinet_Veterinar.Models.Consultatie> Consultatie { get; set; } = default!;
    }
}
