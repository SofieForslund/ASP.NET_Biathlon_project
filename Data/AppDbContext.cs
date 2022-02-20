using BiathlonSuccess.Models.Poco;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiathlonSuccess.Data
{
    public class AppDbContext : DbContext
    {
        private readonly DbContextOptions _options;

        public DbSet<Day> Days { get; set; }
        public DbSet<Shooting> Shootings { get; set; }
        public DbSet<Shooter> Shooters { get; set; }
        public DbSet<ShotSeries> ShotSeries { get; set; }
        public DbSet<Shot> Shots { get; set; }
        public DbSet<ShotFiringCoordinates> FiringCoordinates { get; set; }
        public DbSet<TrainingFacilityLocation> TrainingFacilities { get; set; }
        public DbSet<ShooterStatistics> ShooterStatistics { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            _options = options;
        }

    }
}
