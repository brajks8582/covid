using CovidHospitalsMgmt.CustomFilters;
using CovidHospitalsMgmt.Data;
using CovidHospitalsMgmt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CovidHospitalsMgmt.Controllers
{
    [CustomExceptionFilter]
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
            CovidHospital ch = new CovidHospital();
            ch.Beds = 0;
            return View(ch);
        }
        [HttpPost]
        public ActionResult AddCovidHospital(CovidHospital covidHospital)
        {
            var ctx =new  CovidHospitalDBContext();
            try
            {
                if (ModelState.IsValid)
                {
                    ctx.CovidHospitals.Add(covidHospital);
                    ctx.SaveChanges();
                    return RedirectToAction("Details",new { id = covidHospital.HospitalID});
                }
                else
                {
                    return View(covidHospital);
                }

            }
            catch (Exception )
            {
                return View("error");
            }
        }

        public ActionResult Details(int? id)
        {
            var ctx = new CovidHospitalDBContext();
            CovidHospital c = null;
            if (id != null)
            {
                c = ctx.CovidHospitals.Where(model => model.HospitalID == id).FirstOrDefault();
                return View(c);
            }
            
            return View();
        }
    }
}
