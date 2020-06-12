using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OspreraWebAPI.Controllers
{
    /// <summary>
    /// Controlador para testear la conexion con el SQL
    /// </summary>
    [RoutePrefix("api/Test")]
    public class TestController : ApiController
    {
        [HttpGet]
        [Route("Fecha")]
        public HttpResponseMessage TestFecha()
        {
            var test = DAL.Test.instancia.TestFecha();
            
            try
            {
                switch (test.TestId)
                {
                    case 1:
                        return Request.CreateResponse(HttpStatusCode.OK, test.Fecha.ToString("dd/MM/yyyy HH:mm:ss") + " Sitio web funcionando ok!");

                    default:
                        return Request.CreateResponse(HttpStatusCode.NotFound, "No se encuentra el registro");
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.InnerException.Message);
            }
        }
    }
}
