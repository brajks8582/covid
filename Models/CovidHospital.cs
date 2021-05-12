using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CovidHospitalsMgmt.Models
{
    public enum City
    {
        Select,
        Chennai,
        Delhi,
        Kolkata,
        Mumbai
    }

    public class CovidHospital 
    {
        //Define properties with data annotations
        //
        [Key]
        public int HospitalID { get; set; }


        [Required(ErrorMessage = "Please Provide Hospital Name")]
        [MaxLength(255)]
        public string HospitalName { get; set; }


        [Required(ErrorMessage = "Please Select a City")]
        [DisplayName("City")]
        public City City { get; set; }

        
        [DisplayName("Open for Online Registrations?")]
        public bool OnlineRegistrations { get; set; }
        
        
        [Required(ErrorMessage = "Should be between 100 and 900")]
        [DisplayName("No Of Beds")]
        [Range(100, 900)]
        public int Beds { get; set; }
        
        
        [Required(ErrorMessage = "Please Provide Valid Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
        [Editable(true)]
        public DateTime? StartDate { get; set; }
    }
}