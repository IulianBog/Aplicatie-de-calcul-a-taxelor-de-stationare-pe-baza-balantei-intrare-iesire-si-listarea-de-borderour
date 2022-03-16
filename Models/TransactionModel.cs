using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Models
{
    public class TransactionModel
    {
        [Key]
        public int Id { get; set; }

        public string Sens { get; set; }

        public string Date_Time { get; set; }

        public string Train_Number { get; set; }

        public int Vagon_Number { get; set; }

        public DateTime Time_Stamp { get; set; }

        public int User_Id { get; set; }

        public string OTF_Id { get; set; }

        public string Station_Id { get; set; }

        public List<TransactionModel> lstTransactions { get; set; }
    }
}
