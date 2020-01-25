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

namespace CSHARPMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<string> employeeName = new List<string>();
            //Employee example = new Employee();
            //ViewBag.response = example["data"];
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://dummy.restapiexample.com/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.GetAsync("api/v1/employees");  // Blocking call! 
            response.Wait();

            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                JObject emps = JObject.Parse(result.Content.ReadAsStringAsync().Result);
                var strData = JsonConvert.DeserializeObject(result.Content.ReadAsStringAsync().Result);
                var datas = emps["data"];
                foreach (var s in datas)
                {
                    //employeeName.Add(s.ToString());
                    employeeName.Add(s["employee_name"].ToString());
                }
                 ViewBag.Employees = datas;
                ViewBag.EmployeeNames = new SelectList(employeeName);

               //var readTask = result.Content.ReadAsStringAsync().Result;

                //var message = JsonConvert.DeserializeObject<List<string>>(datas.ToString());

                //JObject products = JObject.Parse(response.Content.ReadAsStringAsync().Result);
                //JObject productJson = JObject.Parse(products);
                //employee = products;
            }
            return View();
        }
    }
}