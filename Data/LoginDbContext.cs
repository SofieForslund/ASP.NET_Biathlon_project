using BiathlonSuccess.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiathlonSuccess.Data
{
    public class LoginDbContext : IdentityDbContext
    {
        private readonly DbContextOptions _options;

        public DbSet<ApplicationUser> AppUsers { get; set; }

        public LoginDbContext(DbContextOptions<LoginDbContext> options) : base(options)
        {
            _options = options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
