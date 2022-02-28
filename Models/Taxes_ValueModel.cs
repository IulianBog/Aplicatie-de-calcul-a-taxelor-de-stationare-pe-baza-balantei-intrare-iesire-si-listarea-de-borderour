using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Models
{
    public class Taxes_ValueModel
    {
        [Key]
        public int Id { get; set; }

        public string Date_To_Start { get; set; }

        public float CT1_C { get; set; }

        public float CT2_C { get; set; }
        
        public float CT1_M { get; set; }

        public float CT2_M { get; set; }

        public int Taxes_Types_Id { get; set; }

    }
}
