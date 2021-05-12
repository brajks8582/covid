using CovidHospitalsMgmt.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace CovidHospitalsMgmt.Data
{
    //Write your code here
    public class CovidHospitalDBContext : DbContext
    {
        public CovidHospitalDBContext() : base("name = CHM_DB") { }
            public DbSet<CovidHospital> CovidHospitals { get; set; }
        }
}
