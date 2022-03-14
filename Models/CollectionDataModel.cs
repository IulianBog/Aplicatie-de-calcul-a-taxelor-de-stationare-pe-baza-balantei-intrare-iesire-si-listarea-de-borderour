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

        [Required]
        [Display(Name = "OTF")]
        public string SelectionOTF { get; set; }
        public Dictionary<string, OTFModel> OTF { get; set; }

        [Required]
        [Display(Name = "Statie")]
        public string SelectionStation { get; set; }
        public Dictionary<string, StationModel> Station { get; set; }

        public Dictionary<int, Taxes_TypesModel> Taxes_Types { get; set; }

        public Dictionary<int, Taxes_ValueModel> Taxes_Values { get; set; }

        public Dictionary<string, Trafic_TypeModel> Trafic_Types { get; set; }

        public List<TransactionModel> Transactions { get; set; }

    }
}
