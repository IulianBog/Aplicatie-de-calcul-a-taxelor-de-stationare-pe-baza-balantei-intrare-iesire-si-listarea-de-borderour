using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Models
{
    public class CollectionDataModel
    {
        public IEnumerable<CheckpointModel> Checkpoint { get; set; }

        public IEnumerable<OTFModel> OTF { get; set; }

        public IEnumerable<StationModel> Station { get; set; }

        public IEnumerable<Taxes_TypesModel> Taxes_Types { get; set; }

        public IEnumerable<Taxes_ValueModel> Taxes_Values { get; set; }

        public IEnumerable<Trafic_TypeModel> Trafic_Types { get; set; }

        public IEnumerable<TransactionModel> Transactions { get; set; }

    }
}
