using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Models
{
    public class Bord
    {
        public string OTF_Id_Bor { get; set; }

        public string Station_Id_Bor { get; set; }

        public DateTime DateTime_Bor { get; set; }

        public int Sess_Id { get; set; }

        public int Ordine { get; set; }

        public DateTime Data_Ora { get; set; }

        public int Sold_Ini { get; set; }

        public int Vag_In { get; set; }

        public int Vag_Out { get; set; }

        public int Vag_Ore { get; set; }

        public int Sold_Fin { get; set; }

        public double Pret_Unitar { get; set; }

        public double Valoare { get; set; }

        public string OTF_Id { get; set; }

        public string Station_Id { get; set; }

        public List<Bord> lstBorderouri { get; set; }
    }
}
