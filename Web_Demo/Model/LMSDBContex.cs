using System;
using Microsoft.EntityFrameworkCore;

namespace Web_Demo.Model
{
    public class LMSDBContex : DbContext
    {

        public DbSet<CityDto> cities { get; set; }


        public LMSDBContex(DbContextOptions<LMSDBContex> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<CityDto>().HasKey(x => x.Id);
            modelBuilder.Entity<CityDto>().Property(x => x.Id).ValueGeneratedOnAdd();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder contextOptionsBuilder){
            var connectionString = "server = localhost; userid = root; pwd = rootroot; port = 3006; database = WebDemo; sslmode = none";
            contextOptionsBuilder.UseMySQL(connectionString);
            base.OnConfiguring(contextOptionsBuilder);
        }
    }
}
