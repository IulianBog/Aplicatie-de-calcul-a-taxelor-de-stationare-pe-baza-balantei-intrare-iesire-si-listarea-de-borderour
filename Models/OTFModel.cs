using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Models
{
    public class OTFModel
    {
        [Key]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Trafic_Type_Id { get; set; }
    }
}
