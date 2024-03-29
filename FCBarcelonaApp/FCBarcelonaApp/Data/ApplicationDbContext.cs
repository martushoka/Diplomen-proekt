﻿using FCBarcelonaApp.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using FCBarcelonaApp.Models.Game;
using FCBarcelonaApp.Models.Order;

namespace FCBarcelonaApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<MyTeam> MyTeams { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<FCBarcelonaApp.Models.Game.GameCreateVM> GameCreateVM { get; set; }
        public DbSet<FCBarcelonaApp.Models.Game.GameIndexVM> GameIndexVM { get; set; }
        public DbSet<FCBarcelonaApp.Models.Game.GameEditVM> GameEditVM { get; set; }
        public DbSet<FCBarcelonaApp.Models.Game.GameDetailsVM> GameDetailsVM { get; set; }
        public DbSet<FCBarcelonaApp.Models.Game.GameDeleteVM> GameDeleteVM { get; set; }
        public DbSet<FCBarcelonaApp.Models.Order.OrderConfirmVM> OrderConfirmVM { get; set; }
    }
}
