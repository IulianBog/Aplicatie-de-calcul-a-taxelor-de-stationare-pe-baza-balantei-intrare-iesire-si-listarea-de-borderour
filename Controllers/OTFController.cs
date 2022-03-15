using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proiect.Models;
using Proiect.Services;
using System.Data;
using System.Web;
using Microsoft.AspNetCore.Http;


namespace Proiect.Controllers
{
    public class OTFController : Controller
    {
        public IActionResult Index()
        {
            CollectionDataModel tabel = new CollectionDataModel();
            GatheringInformation gatheringinformation = new GatheringInformation();
            tabel.Transactions = gatheringinformation.GetTransaction();

            ViewBag.Station = HttpContext.Session.GetString("Station");
            ViewBag.OTF = HttpContext.Session.GetString("OTF");

            List<OTFModel> Selectie_OTF = new List<OTFModel>();
            tabel.OTFs = gatheringinformation.GetOTFs();
            tabel.Stations = gatheringinformation.GetStations();

            return View(tabel); 
        }

        public IActionResult OTF_Selection()
        {
            OTFModel otfModel = new OTFModel();
            GatheringInformation gatheringinformation = new GatheringInformation();
            otfModel.Selectie_OTF = gatheringinformation.GetOTF();
           
            return View(otfModel);
        }

        public IActionResult Station_Selection()
        {
            StationModel stationModel = new StationModel();
            GatheringInformation gatheringinformation = new GatheringInformation();
            stationModel.Selectie_Station = gatheringinformation.GetStation();

            return View(stationModel);
        }

        public IActionResult Update_Station(StationModel station)
        {
            HttpContext.Session.SetString("Station", station.Name.ToString());
            return RedirectToAction("Index");
        }

        public IActionResult Update_OTF(OTFModel otf)
        {
            HttpContext.Session.SetString("OTF", otf.Name.ToString());
            return RedirectToAction("Index");
        }

        public IActionResult Sterge_ViewBag()
        {
            HttpContext.Session.Remove("Station");
            HttpContext.Session.Remove("OTF");
            return RedirectToAction("Index");
        }

        public IActionResult Logical_Delete(TransactionModel transaction)
        { 
            CRUD crud = new CRUD();
            
            crud.Delete_Transactions(transaction.Id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Create_Transaction(CollectionDataModel collection)
        {
            CRUD crud = new CRUD();
            
            return RedirectToAction("Index");
        }

        public IActionResult Edit(TransactionModel transaction)
        {
            return View();
        }
        public IActionResult Update(TransactionModel transaction)
        {
            CRUD crud = new CRUD();

            crud.Update_Transactions(transaction.Id);

            return RedirectToAction("Index");
        }
    }
}
