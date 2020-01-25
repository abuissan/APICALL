using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using CSHARPMVC.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using CSHARPMVC.Modules;

namespace CSHARPMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<string> employeeName = new List<string>();

            EpiconWSC e = new EpiconWSC
            {
                Address = @"http://dummy.restapiexample.com/",
                Service = @"api/v1/employees"
            };

            var datas = e.Execute()["data"];

                
                foreach (var s in datas)
                {
                    //employeeName.Add(s.ToString());
                    employeeName.Add(s["employee_name"].ToString());
                }
                 ViewBag.Employees = datas;
                ViewBag.EmployeeNames = new SelectList(employeeName);

            
            return View();
        }
    }
}