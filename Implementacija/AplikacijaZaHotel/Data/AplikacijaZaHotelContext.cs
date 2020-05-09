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
        public AplikacijaZaHotelContext(DbContextOptions<AplikacijaZaHotelContext> options)
            : base(options)
        {
        }

        public DbSet<Sadrzaj> Sadrzaj { get; set; }
    }
}
