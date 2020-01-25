using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using CSHARPMVC.Models;
using System.Web.Mvc;

namespace CSHARPMVC.Models
{
    public class Employee
    {
        public int id { get; set; }
        public string employee_name { get; set; }
        public string employee_salary { get; set; }
        public int employee_age { get; set; }

    }

}
