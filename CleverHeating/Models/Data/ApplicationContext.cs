using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CleverHeating.Models;

namespace CleverHeating.Models 
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
           : base(options)
        {

        }
        public DbSet<Office> Office { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Subscribe> Subscribe { get; set; }
        public DbSet<Statistic> Statistic { get; set; }
    }
}
