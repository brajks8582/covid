using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CovidHospitalsMgmt.CustomFilters
{
    public class CustomExceptionFilterAttribute : FilterAttribute, IExceptionFilter
    {
        static string scriptTag = "<script type=\"\" language=\"\">{0}</script>";

        public static void ConsoleLog(string message)
        {
            string function = "console.log('{0}');";
            string log = string.Format(GenerateCodeFromFunction(function), message);
            HttpContext.Current.Response.Write(log);

        }
        static string GenerateCodeFromFunction(string function)
        {
            return string.Format(scriptTag, function);
        }
        public void OnException(ExceptionContext filterContext)
        {
            ConsoleLog(filterContext.Exception.Message);
        }
    }
}