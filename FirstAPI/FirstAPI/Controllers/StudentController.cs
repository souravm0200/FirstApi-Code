using FirstAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace FirstAPI.Controllers
{
    public class StudentController : ApiController
    {
        [HttpGet]
        [Route("api/Students")]
        public HttpResponseMessage GetStudent()
        {
            
                using (DBContext db = new DBContext())
                {
                    try
                    {
                        var students = db.Students.ToList();
                        if (students.Count != 0)
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, db.Students.ToList());
                        }
                        else
                        {
                            return Request.CreateResponse(HttpStatusCode.BadRequest, db.Students.ToList());
                        }
                    }
                    catch (Exception ex)
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                    }
                }
            
        }

        


    }
}
