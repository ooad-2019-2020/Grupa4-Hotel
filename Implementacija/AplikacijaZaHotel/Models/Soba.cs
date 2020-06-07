using Abp.Runtime.Validation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AplikacijaZaHotel.Models
{
   
    public class Soba
    {
        public int Id { get; set; }

        //[Index("BrojSobe_Index", IsUnique = true)]
        public int BrojSobe { get; set; }
        public int VrstaID { get; set; }
        public virtual Vrsta Vrsta { get; set; }
    }
}
