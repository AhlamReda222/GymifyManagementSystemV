using GymifyManagementSystem.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymifyManagementSystem.DAL.Models;
namespace GymifyManagementSystem.DAL.Database
{

    public class GymifyContext : IdentityDbContext<ApplicationUser, IdentityRole<string>, string>  
    {
        public GymifyContext(DbContextOptions<GymifyContext> options) : base(options) { }

        public DbSet<admins> admins { get; set; }
        public DbSet<articles> articles { get; set; }
        public DbSet<nutritionist> nutritionists { get; set; }
        public DbSet<order> orders { get; set; }
        public DbSet<products> products { get; set; }
        public DbSet<trainer> trainers { get; set; }
        public DbSet<user> users { get; set; }
    }
}