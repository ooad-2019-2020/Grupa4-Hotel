using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplikacijaZaHotel.Models
{
    public class Vrsta
    {
        public int VrstaId { get; set; }
        public string Naziv { get; set; }
        public bool Balkon { get; set; }
        public int Kapacitet { get; set; }
        public double Cijena { get; set; }
        public virtual ICollection<Soba> Sobas { get; set; }
    }
}
