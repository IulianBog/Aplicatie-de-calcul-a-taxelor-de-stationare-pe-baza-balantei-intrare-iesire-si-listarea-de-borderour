using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Models
{
    public class Taxes_TypesModel
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }
    }
}
