using FirstAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FirstAPI.Controllers
{
    public class FacultyController : ApiController
    {
        [HttpGet]
        [Route("api/Faculties")]

        public HttpResponseMessage GetFaculty()
        {

            using (DBContext db = new DBContext())
            {
                try
                {
                    var faculties = db.Faculties.ToList();
                    if (faculties.Count != 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, db.Faculties.ToList());
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, db.Faculties.ToList());
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
