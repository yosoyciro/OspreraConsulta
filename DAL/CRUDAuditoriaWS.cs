using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace DAL
{
    public class CRUDAuditoriaWS
    {
        static ISession session;
        public static CRUDAuditoriaWS instancia = new CRUDAuditoriaWS();
        private CRUDAuditoriaWS()
        {
            session = DAL.GenerarSesion.Instancia.Session;
        }

        public void Agregar(BE.AfiBeneficiariosOspep pAfiBeneficiariosOspep, double pNroDocumento)
        {
            BE.AuditoriaWS oAuditoriaWS = new BE.AuditoriaWS();
            oAuditoriaWS.Usuario = "";
            oAuditoriaWS.FechaHora = DateTime.Now;
            oAuditoriaWS.TipoDoc = "DNI";
            oAuditoriaWS.NroDoc = pNroDocumento;
            oAuditoriaWS.Respuesta = "Afiliado: " + pAfiBeneficiariosOspep.Nombre.Trim() + " - Respuesta: " + pAfiBeneficiariosOspep.Resultado.Trim();
            
            try
            {
                session.SaveOrUpdate(oAuditoriaWS);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
