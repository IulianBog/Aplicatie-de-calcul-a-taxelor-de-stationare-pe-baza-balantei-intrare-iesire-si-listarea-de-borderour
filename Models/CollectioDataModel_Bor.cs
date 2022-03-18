using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Models
{
    public class CollectioDataModel_Bor
    {
        public string OTF_Id_Bor { get; set; }

        public string Station_Id_Bor { get; set; }

        public DateTime DateTime_Bor { get; set; }

        public List<Bord> lstBorderouri { get; set; }

        public IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> OTFs { get; set; }
        public IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> Stations { get; set; }
        public int Sold_Ini { get; set; }

        public int Vag_In { get; set; }

        public int Vag_Out { get; set; }

        public int Vag_Ore { get; set; }

        public int Sold_Fin { get; set; }

        public double Pret_Unitar { get; set; }

        public double Valoare { get; set; }

        public string OTF_Id { get; set; }

        public string Station_Id { get; set; }

        public string Message { set; get; }

        public int Id_Sesiune_Bor { set; get; }

    }
}
