using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Models
{
    public class CollectionDataModel
    {
        public Dictionary<int, CheckpointModel> Checkpoint { get; set; }

        //[Required(ErrorMessage = "Selectati OTF!")]
        //[Display(Name = "OTF")]
        //public string SelectionOTF { get; set; }
        public Dictionary<string, OTFModel> OTF { get; set; }

        //[Required(ErrorMessage = "Selectati statia!")]
        //[Display(Name = "Statie")]
        //public string SelectionStation { get; set; }
        public Dictionary<string, StationModel> Station { get; set; }

        public Dictionary<int, Taxes_TypesModel> Taxes_Types { get; set; }

        public Dictionary<int, Taxes_ValueModel> Taxes_Values { get; set; }

        public Dictionary<string, Trafic_TypeModel> Trafic_Types { get; set; }

        public List<TransactionModel> Transactions { get; set; }
        public IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> OTFs { get; set; }
        public IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> Stations { get; set; }
        public string userId { get; set; }
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Selectati sensul!")]
        public string Sens { get; set; }
        [Required(ErrorMessage = "Alegeti data!")]
        public DateTime Date_Time { get; set; }
        [Required(ErrorMessage = "Introduceti numarul trenului!")]
        public string Train_Number { get; set; }
        [Required(ErrorMessage = "Introduceti numarul vagonului!")]
        public int Vagon_Number { get; set; }

        public DateTime Time_Stamp { get; set; }

        public int User_Id { get; set; }
        //[Required(ErrorMessage = "Selectati OTF!")]
        public string OTF_Id { get; set; }
        //[Required(ErrorMessage = "Selectati statia!")]
        public string Station_Id { get; set; }
        public string StmtType { get; set; }
        public string buttonText { get; set; }
        public string buttonCancel { get; set; }
        public string Message { get; set; }
        public List<TransactionModel> lstTransactions { get; set; }
        public void OnPostCancel()
        {
            Id = 0;
            Train_Number = "";
            Vagon_Number = 0;
            OTF_Id = "";
            Station_Id = "";
            Message = "S-a realizat cancel!";
            buttonCancel = "cancel";
        }
    }
}
