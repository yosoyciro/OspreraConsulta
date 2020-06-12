using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace DAL
{
    public class Test
    {
        static ISession session;
        public static Test instancia = new Test();
        private Test()
        {
            session = DAL.GenerarSesion.Instancia.Session;            
        }

        public BE.Test TestFecha()
        {
            int testid = 1;
            BE.Test oTest = session.Get<BE.Test>(testid);
            oTest.Fecha = DateTime.Now;

            try
            {                
                session.Merge(oTest);

                return oTest;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void GrabarFechaTest(BE.Test pTest)
        {
            try
            {
                //session.Update(pTest);
                session.Flush();
                //session.Refresh(pTest);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }    
}

