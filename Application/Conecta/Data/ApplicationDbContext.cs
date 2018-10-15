using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Conecta.Models;
using Conecta.Models.CountryStructure;

namespace Conecta.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Country> Country { get; set; }
        public DbSet<Province> Province { get; set; }
        public DbSet<Commune> Commune { get; set; }
        public DbSet<Neighborhood> Neighborhood { get; set; }
        public DbSet<Map> Map { get; set; }

    }
}
