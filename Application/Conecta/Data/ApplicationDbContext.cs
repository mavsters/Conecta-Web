using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Conecta.Models;
using Conecta.Models.CountryStructure;
using Conecta.Models.Events;
using Conecta.Models.User;
using Conecta.Models.Coins;
using Conecta.Models.Type;
using Conecta.Models.Routes;
using Conecta.Models.Points;
using Conecta.Models.Location;

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
        public DbSet<Conecta.Models.Events.Event> Event { get; set; }
        public DbSet<Conecta.Models.User.UserMain> UserMain { get; set; }
        public DbSet<Conecta.Models.User.Person> Person { get; set; }
        public DbSet<Conecta.Models.Coins.Benefits> Benefits { get; set; }
        public DbSet<Conecta.Models.Type.CategoryType> CategoryType { get; set; }
        public DbSet<Conecta.Models.Type.EventType> EventType { get; set; }
        public DbSet<Conecta.Models.Type.PlaceType> PlaceType { get; set; }
        public DbSet<Conecta.Models.Routes.Route> Route { get; set; }
        public DbSet<Conecta.Models.Points.PointsMain> PointsMain { get; set; }
        public DbSet<Conecta.Models.Coins.QRMain> QRMain { get; set; }
        public DbSet<Conecta.Models.Location.Place> Place { get; set; }
        public DbSet<Conecta.Models.Location.LocationMain> LocationMain { get; set; }
        public DbSet<Conecta.Models.Events.Place_Event> Place_Event { get; set; }
        public DbSet<Conecta.Models.Events.UserMain_Event> UserMain_Event { get; set; }

    }
}
