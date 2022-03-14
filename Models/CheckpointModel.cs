using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Models
{
    public class CheckpointModel
    {
        [Key]
        public int Id { get; set; }

        public int Balance_Wagons { get; set; }
        
        public string OTF_Id { get; set; }

        public string Station_Id { get; set; }

        public string Data_Check { get; set; }

        public int Transaction_Id { get; set; }
    }
}
