using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OspreraWebAPI.Controllers
{
    [RoutePrefix("api/AfiliadoDatos")]
    public class AfiliadoDatosController : ApiController
    {
        [HttpGet]
        [Route("BuscarPorNroDocumento")]
        public List<BE.AfiBeneficiariosOspep> BuscarPorNroDocumento(double pNroDocumento)
        {            
            return DAL.AfiBeneficiariosOspep.instancia.BuscarPorNroDocumento(pNroDocumento);

        }
    }
}
