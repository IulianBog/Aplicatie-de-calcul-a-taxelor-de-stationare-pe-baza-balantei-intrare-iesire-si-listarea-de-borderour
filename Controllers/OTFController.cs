using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proiect.Models;
using Proiect.Services;

namespace Proiect.Controllers
{
    public class OTFController : Controller
    {
        public IActionResult Index()
        {
            CollectionDataModel collectiondata = new CollectionDataModel();
            GatheringInformation gatheringinformation = new GatheringInformation();

            collectiondata.Checkpoint = gatheringinformation.GetCheckpoint();
            collectiondata.OTF = gatheringinformation.GetOTF();
            collectiondata.Station = gatheringinformation.GetStation();
            collectiondata.Taxes_Types = gatheringinformation.GetTaxes_Types();
            collectiondata.Taxes_Values = gatheringinformation.GetTaxes_Value();
            collectiondata.Trafic_Types = gatheringinformation.GetTrafic_Type();
            collectiondata.Transactions = gatheringinformation.GetTransaction();

            return View(collectiondata);
        }
    }
}
