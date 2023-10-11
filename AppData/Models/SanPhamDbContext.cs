using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class SanPhamDbContext : DbContext
    {
        public SanPhamDbContext()
        {
            
        }
        public SanPhamDbContext(DbContextOptions<SanPhamDbContext> options):base (options)
        {
            
        }
        public DbSet<SanPham> sanPhams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=Hải\SQLEXPRESS;
Initial Catalog=NET105_LAB_3_4;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
