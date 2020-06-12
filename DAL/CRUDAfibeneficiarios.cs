using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;

namespace DAL
{
    public class CRUDAfiBeneficiarios
    {
        #region Singleton
        private static ISession session;
        public static DAL.CRUDAfiBeneficiarios instancia = new DAL.CRUDAfiBeneficiarios();

        private CRUDAfiBeneficiarios()
        {
            session = DAL.GenerarSesion.Instancia.Session;
        }
        #endregion

        public BE.AfiBeneficiarios BuscarPorCUIL(double pCUIL)
        {
            return session.Query<BE.AfiBeneficiarios>().Where(a => a.Cuil == pCUIL).FirstOrDefault();
        }        
    }
}

