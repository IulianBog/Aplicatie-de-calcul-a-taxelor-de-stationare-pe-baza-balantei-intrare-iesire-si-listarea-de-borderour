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
            HttpContext.Session.SetString ("OTF", otf.Name.ToString());
            return RedirectToAction("Index");
        }

        public IActionResult Sterge_ViewBag()
        {
            HttpContext.Session.Remove("Station");
            HttpContext.Session.Remove("OTF");

            ViewData["Nr_Train"] = "";
            ViewData["Nr_Vagone"] = "";
            ViewData["Data_Time"] = "";

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
            CRUD crud = new CRUD();

            ViewData["Nr_Train"] = crud.Fill_ViewBag_Train_Nr(transaction.Id);
            ViewData["Nr_Vagone"] = crud.Fill_ViewBag_Vagone_Nr(transaction.Id);
            ViewData["Data_Time"] = crud.Fill_ViewBag_Data_Time(transaction.Id);

            /*
            HttpContext.Session.SetString("Nr_Train",
                                crud.Fill_ViewBag_Train_Nr(transaction.Id).ToString());
            HttpContext.Session.SetInt32("Nr_Vagone",
                                crud.Fill_ViewBag_Vagone_Nr(transaction.Id));
            HttpContext.Session.SetString("Data_Time",
                                crud.Fill_ViewBag_Data_Time(transaction.Id).ToString());
            */

            ViewBag.Nr_Train = HttpContext.Session.GetString("Nr_Train");
            ViewBag.Nr_Vagone = HttpContext.Session.GetString("Nr_Vagone");
            ViewBag.Data_Time = HttpContext.Session.GetString("Data_Time");

            return RedirectToAction("Index");
        }

        public IActionResult Update(TransactionModel transaction)
        {
            

            return RedirectToAction("Index");
        }
    }
}
