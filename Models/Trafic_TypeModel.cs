﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Models
{
    public class Trafic_TypeModel
    {
        [Key]
        public char Id { get; set; }

        public string Name { get; set; }
    }
}
