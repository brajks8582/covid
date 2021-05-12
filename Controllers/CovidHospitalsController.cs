using CovidHospitalsMgmt.Data;
using CovidHospitalsMgmt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CovidHospitalsMgmt.Controllers
{
    public class CovidHospitalsController : Controller
    {
        public CovidHospitalDBContext ctx = new CovidHospitalDBContext();
        // GET
        public ActionResult Index()
        {
            var list = (from s in ctx.CovidHospitals orderby s.City select s).ToList();
            return View(list);
        }
        [HttpGet]
        public ActionResult AddCovidHospital()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCovidHospital(CovidHospital covidHospital)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ctx.CovidHospitals.Add(covidHospital);
                    ctx.SaveChanges();
                    return RedirectToAction("Details",covidHospital);
                }
                else
                {
                    return View("error");
                }

            }
            catch (Exception )
            {
                return View("error");
            }
        }

        public ActionResult Details(CovidHospital covidHospital)
        {

            
            return View(covidHospital);
        }










    }
}
