using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Models
{
    public class CollectionDataModel
    {
        [Required]
        [Display(Name = "OTF")]
        public string SelectionOTF { get; set; }


        [Required]
        [Display(Name = "Statie")]
        public string SelectionStation { get; set; }

        public IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> OTFs { get; set; }

        public IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> Stations { get; set; }

        public List<TransactionModel> Transactions { get; set; }

    }
}
