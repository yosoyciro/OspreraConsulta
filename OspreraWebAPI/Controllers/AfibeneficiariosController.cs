using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OspreraWebAPI.Controllers
{
    [RoutePrefix("api/AfiBeneficiarios")]
    public class AfiBeneficiariosController : ApiController
    {
        [HttpGet]
        [Route("BuscarPorCUIL")]
        public BE.AfiBeneficiarios BuscarPorNroDocumento(double pCUIL)
        {
            return DAL.CRUDAfiBeneficiarios.instancia.BuscarPorCUIL(pCUIL);

        }
    }
}
