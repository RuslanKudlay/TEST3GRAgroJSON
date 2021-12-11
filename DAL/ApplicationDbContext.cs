using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Volume> Volumes { get; set; }
        public DbSet<PropertyVolume> PropertyVolumes { get; set; }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
