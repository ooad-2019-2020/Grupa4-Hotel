using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AplikacijaZaHotel.Models;

namespace AplikacijaZaHotel.Data
{
    public class AplikacijaZaHotelContext : DbContext
    {
        public AplikacijaZaHotelContext (DbContextOptions<AplikacijaZaHotelContext> options)
            : base(options)
        {
        }

        

        public DbSet<AplikacijaZaHotel.Models.Vrsta> Vrsta { get; set; }

        public DbSet<AplikacijaZaHotel.Models.Soba> Soba { get; set; }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=AplikacijaZaHotelContext-51a2a9bc-fbba-4ffd-a91d-52eba6496dfd;Trusted_Connection=True;");
        }
        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Soba>().HasAlternateKey(u => u.BrojSobe);
            modelBuilder.Entity<Soba>().HasAlternateKey(u => new { u.BrojSobe });
        }*/

    }
}
