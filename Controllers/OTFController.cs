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
        [HttpGet]
        public IActionResult Index(int id = 0, String type = null)
        {
            CollectionDataModel tabel = new CollectionDataModel();
            GatheringInformation gatheringinformation = new GatheringInformation();
            CRUD trn = new CRUD();
            tabel.Transactions = gatheringinformation.GetTransaction();



            if (id > 0 && !String.IsNullOrWhiteSpace(type))
            {
                try
                {
                    if (type.ToLower().Equals("d"))
                    {
                        tabel.Id = id;
                        tabel.User_Id = ViewBag.session == null ? 0 : ViewBag.session;
                        tabel.StmtType = "Delete";
                        ViewBag.OTF_Id = HttpContext.Session.GetString("OTF_Id");
                        tabel.OTF_Id = ViewBag.OTF_Id;
                        ViewBag.Station_Id = HttpContext.Session.GetString("Station_Id");
                        tabel.Station_Id = ViewBag.Station_Id;
                        //tabel.Train_Number = "";
                        //tabel.Vagon_Number = 0;
                        //tabel.Date_Time = null;

                        tabel.buttonText = "Adaugare";
                        tabel = trn.Delete_Transactions(tabel);

                        if (tabel.Message.Equals("success"))
                        {
                            tabel.Message = "Tranzactie stearsa cu succes! S-a sters inregistrarea cu id-ul : " + id;
                        }
                        List<TransactionModel> lstTanssd = new List<TransactionModel>();
                        var lstTansd = gatheringinformation.GetTransaction();
                        if (ViewBag.OTF_Id != null && ViewBag.Station_Id != null)
                        {
                            lstTanssd = lstTansd.Where(c => c.OTF_Id == ViewBag.OTF_Id)
                                    .Where(c => c.Station_Id == ViewBag.Station_Id)
                                    .ToList();//gatheringinformation.GetTransactionById(0).lstTransactions;
                                              //else lstTans = new List<TransactionModel>();
                            tabel.OTF_Id = ViewBag.OTF_Id;
                            tabel.Station_Id = ViewBag.Station_Id;
                        }



                        tabel.lstTransactions = lstTanssd;
                        tabel.buttonText = "Adaugare";
                        tabel.StmtType = "Insert";
                    }
                    else if (type.ToLower().Equals("e"))
                    {
                        tabel = gatheringinformation.GetTransactionById(id);
                        tabel.StmtType = "Update";
                        tabel.buttonText = "Update";
                        tabel.Message = "";
                        HttpContext.Session.SetInt32("Id", id);
                        ViewBag.OTF_Id = HttpContext.Session.GetString("OTF_Id");
                        tabel.OTF_Id = ViewBag.OTF_Id;
                        ViewBag.Station_Id = HttpContext.Session.GetString("Station_Id");
                        tabel.Station_Id = ViewBag.Station_Id;
                        List<TransactionModel> lstTansse = new List<TransactionModel>();
                        var lstTanse = gatheringinformation.GetTransaction();
                        if (ViewBag.OTF_Id != null && ViewBag.Station_Id != null)
                        {
                            lstTansse = lstTanse.Where(c => c.OTF_Id == ViewBag.OTF_Id)
                                    .Where(c => c.Station_Id == ViewBag.Station_Id)
                                    .ToList();//gatheringinformation.GetTransactionById(0).lstTransactions;
                                              //else lstTans = new List<TransactionModel>();
                        }
                        tabel.lstTransactions = lstTansse;

                    }
                }
                catch (Exception ex)
                {
                    tabel.lstTransactions = null;
                    tabel.buttonText = "Adaugare";
                    tabel.StmtType = "Insert";
                    tabel.Message = ex.Message.ToString();
                }
            }
            else
            {

                tabel.StmtType = "Insert";
                tabel.buttonText = "Adaugare";
                ViewBag.OTF_Id = HttpContext.Session.GetString("OTF_Id");
                ViewBag.Station_Id = HttpContext.Session.GetString("Station_Id");
                List<TransactionModel> lstTanss = new List<TransactionModel>();
                var lstTans = gatheringinformation.GetTransaction();
                if (ViewBag.OTF_Id != null && ViewBag.Station_Id != null)
                {
                    lstTanss = lstTans.Where(c => c.OTF_Id == ViewBag.OTF_Id)
                            .Where(c => c.Station_Id == ViewBag.Station_Id)
                            .ToList();//gatheringinformation.GetTransactionById(0).lstTransactions;
                                      //else lstTans = new List<TransactionModel>();
                    tabel.OTF_Id = ViewBag.OTF_Id;
                    tabel.Station_Id = ViewBag.Station_Id;
                }



                tabel.lstTransactions = lstTanss;
                tabel.Message = "OTFId: " + (ViewBag.OTF_Id == null ? " " : ViewBag.OTF_Id) + " StationId:  " + (ViewBag.Station_Id == null ? " " : ViewBag.Station_Id) + "; inregistrari: " + tabel.lstTransactions.Count();

            }

            if (tabel.lstTransactions == null || tabel.lstTransactions.Count == 0)
            {
                tabel.lstTransactions.Add(new TransactionModel
                {
                    Id = 0,
                    Sens = "Sosiri",
                    Date_Time = "",
                    Train_Number = "",
                    Vagon_Number = 0,
                    OTF_Id = null,
                    Station_Id = null,
                    lstTransactions = new List<TransactionModel>()

                });
            }
            tabel.OTFs = gatheringinformation.GetOTFs();
            tabel.Stations = gatheringinformation.GetStations();
            return View(tabel);
        }


        [HttpPost]
        public ActionResult Index(CollectionDataModel tabel)
        {
            CRUD trn = new CRUD();
            GatheringInformation gatheringinformation = new GatheringInformation();
            if (ModelState.IsValid)
            {
                CollectionDataModel e = new CollectionDataModel();
                ViewBag.Id = HttpContext.Session.GetInt32("Id");
                e = trn.validate_transaction(tabel);
                if (e.Message != "success")
                {
                    e.Message = e.Message;
                }
                else

                if (ViewBag.Id != null)
                {
                    tabel.Id = ViewBag.Id;
                    e = trn.Update_Transactions(tabel);
                }
                else
                {
                    e = trn.Create_Transactions(tabel);
                    HttpContext.Session.SetInt32("Id", e.Id);

                }
                e.OTFs = gatheringinformation.GetOTFs();
                e.Stations = gatheringinformation.GetStations();

                ViewBag.OTF_Id = HttpContext.Session.GetString("OTF_Id");
                ViewBag.Station_Id = HttpContext.Session.GetString("Station_Id");
                List<TransactionModel> lstTanssad = new List<TransactionModel>();
                var lstTansad = gatheringinformation.GetTransaction();
                if (ViewBag.OTF_Id != null && ViewBag.Station_Id != null)
                {
                    lstTanssad = lstTansad.Where(c => c.OTF_Id == ViewBag.OTF_Id)
                            .Where(c => c.Station_Id == ViewBag.Station_Id)
                            .ToList();//gatheringinformation.GetTransactionById(0).lstTransactions;
                                      //else lstTans = new List<TransactionModel>();
                    tabel.OTF_Id = ViewBag.OTF_Id;
                    tabel.Station_Id = ViewBag.Station_Id;
                }
                var c = lstTanssad;
                if (c != null)
                {
                    e.lstTransactions = c;
                }
                else
                    e.lstTransactions = new List<TransactionModel>();



                e.Sens = tabel.Sens;
                e.Date_Time = Convert.ToDateTime(tabel.Date_Time);
                e.Train_Number = tabel.Train_Number;
                e.Vagon_Number = tabel.Vagon_Number;
                e.OTF_Id = tabel.OTF_Id;
                e.Station_Id = tabel.Station_Id;
                e.StmtType = tabel.StmtType;
                e.Message = e.Message;
                if (!String.IsNullOrWhiteSpace(e.Message) && e.Message.Equals("success"))
                {
                    e.buttonText = "Editare";
                    if (e.Message.ToLower().Equals("success"))
                    {
                        e.Message = "Transactie salvata cu succes!";
                    }
                    e.StmtType = "Update";
                }
                else
                {
                    e.buttonText = "Adaugare";
                    e.StmtType = "Insert";
                }

                return View(e);
            }
            else
            {
                var c = gatheringinformation.GetTransaction();
                if (c != null)
                {
                    tabel.lstTransactions = c;
                }
                tabel.buttonText = "Adaugare";
                tabel.StmtType = "Insert";
                return View(tabel);
            }
        }


        public IActionResult cancelData()
        {
            HttpContext.Session.Remove("Id");
            HttpContext.Session.Remove("OTF_Id");
            HttpContext.Session.Remove("Station_Id");
            return RedirectToAction("Index");
        }
        public IActionResult setDrops(CollectionDataModel transaction)
        {
            HttpContext.Session.SetString("OTF_Id", transaction.OTF_Id);
            HttpContext.Session.SetString("Station_Id", transaction.Station_Id);

            return RedirectToAction("Index");
        }

        public IActionResult Logical_Delete(CollectionDataModel transaction)
        {
            Index(transaction.Id, "d");
            return View();
        }
        public IActionResult EditBtn(CollectionDataModel transaction)
        {
            Index(transaction.Id, "e");
            return View();
        }

        /*    public IActionResult OTF_Selection()
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
        */

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

        public IActionResult Creare(CollectionDataModel col)
        {
            col.userId = HttpContext.Session.GetString("User_Id");
            return RedirectToAction("Index");
        }

        public IActionResult Logical_Delete(TransactionModel transaction)
        {
            // Logical_Delete logical = new Logical_Delete();

            HttpContext.Session.SetInt32("Stergere_Id", transaction.Id);
            ViewBag.StergereId = HttpContext.Session.GetInt32("Stergere_Id");

            //logical.Delete_Transactions(ViewBag.StergereId);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Borderouri()
        {
            GatheringInformation gatheringinformation = new GatheringInformation();
            CollectioDataModel_Bor tabel = new CollectioDataModel_Bor();
            Borderouri BOR = new Borderouri();
            tabel.lstBorderouri = BOR.GetBorderouri();
            ViewBag.OTF_Id = HttpContext.Session.GetString("OTF_Id_Bor");
            ViewBag.Station_Id = HttpContext.Session.GetString("Station_Id_Bor");

            tabel.OTFs = gatheringinformation.GetOTFs();
            tabel.Stations = gatheringinformation.GetStations();

            tabel.OTF_Id_Bor = ViewBag.OTF_Id;
            tabel.Station_Id_Bor = ViewBag.Station_Id;

            return View(tabel);
        }

        [HttpPost]
        public ActionResult Borderouri(CollectioDataModel_Bor tabel)
        {
            Borderouri b = new Borderouri();
            CollectioDataModel_Bor e = new CollectioDataModel_Bor();
            GatheringInformation gatheringinformation = new GatheringInformation();
            //List<CollectioDataModel_Bor> lsst_Bor = new List<CollectioDataModel_Bor>();
            CRUD trn = new CRUD();
            e.OTFs = gatheringinformation.GetOTFs();
            List<Bord> lsst_Bor = new List<Bord>();
            e.Stations = gatheringinformation.GetStations();
            var lst_Bor = b.GetBorderouri();
            if (ViewBag.OTF_Id != null && ViewBag.Station_Id != null)
            {
                lsst_Bor = lst_Bor.Where(c => c.OTF_Id == ViewBag.OTF_Id)
                        .Where(c => c.Station_Id == ViewBag.Station_Id)
                        .ToList();//gatheringinformation.GetTransactionById(0).lstTransactions;
                                  //else lstTans = new List<TransactionModel>();
                tabel.OTF_Id = ViewBag.OTF_Id;
                tabel.Station_Id = ViewBag.Station_Id;
            }
            var c = lsst_Bor;
            if (c != null)
            {
                e.lstBorderouri = c;
            }
            else
                e.lstBorderouri = new List<Bord>();

            return View(e);
        }

 
        public IActionResult setDrops_Borderouri(CollectioDataModel_Bor transaction)
        {
            
            HttpContext.Session.SetString("OTF_Id_Bor", transaction.OTF_Id_Bor);
            HttpContext.Session.SetString("Station_Id_Bor", transaction.Station_Id_Bor);
           // HttpContext.Session.SetString("Data_Time", transaction.Date_Time.ToString());

            return RedirectToAction("Borderouri");
        }

        public ActionResult Genereaza_Borderouri(CollectioDataModel_Bor borderouri)
        {
           
            Borderouri bor = new Borderouri();
            borderouri =  bor.Gen_Bord(borderouri);
            if (borderouri.Message == "success") 
            {
                Borderouri();
            }
            return View();
        }



    }
}
