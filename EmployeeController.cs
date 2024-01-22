using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVC_WebAPI_Project.Controllers
{
    public class EmployeeController : ApiController
    {
        [Route("api/getemployee")]
        public HttpResponseMessage GetEmployee()
        {
            List<string> outputList = new List<string>();

            List<EmpPerson> EmpLst = new List<EmpPerson>
            {
                new EmpPerson{Name="Bharat Vyas",Age=30},
                new EmpPerson{Name="Ashish Kalla",Age=22}
            };

            string EmpLstStr = JsonConvert.SerializeObject(EmpLst);

            outputList.Add("Success");
            outputList.Add("Total Records: "+EmpLst.Count.ToString());
            outputList.Add(EmpLstStr);


            ResponseModel res = new ResponseModel();
            res.StatusCode = HttpStatusCode.OK;
            res.Message = "Employee List ";
            res.Data = outputList.ToArray();

            HttpResponseMessage _response = Request.CreateResponse(HttpStatusCode.OK,res);

            return _response;
        }


    }

    public class ResponseModel
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; } 
        public object Data { get; set; }    

    }

    public class EmpPerson
    {
        public string Name { get; set; }    
        public int Age { get; set; }
    }

}
