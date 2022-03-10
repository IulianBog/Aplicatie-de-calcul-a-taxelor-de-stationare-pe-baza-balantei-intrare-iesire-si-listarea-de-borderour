using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Models
{
    public class StationModel
    {
        [Key]
        public string Id { get; set; }

        [ViewData]
        public string Name { get; set; }

        public int Taxes_Values_Id { get; set; }

        public Dictionary<string, string> Selectie_Station { get; set; }
    }
}
