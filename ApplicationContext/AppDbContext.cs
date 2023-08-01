using CarPark.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CarPark.API.ApplicationContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ParkingRule> ParkingRules { get; set; }
        public DbSet<ParkingTicket> ParkingTickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ParkingRule>().HasData(
                new ParkingRule { Id = 1, EntranceFee = 2, FirstHourCost = 3, SuccessiveHourCost = 4 }
            );
        }
    }
}
