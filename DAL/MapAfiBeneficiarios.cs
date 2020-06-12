using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;

namespace DAL
{
    public class MapAfiBeneficiarios : ClassMapping<BE.AfiBeneficiarios>
    {
        
        public MapAfiBeneficiarios()
        {
            Table("AfiBeneficiarios");

            Id(x => x.Correlativo);
            Property(p => p.Cuil);
            Property(p => p.Baja);
            Property(p => p.BocaExpendio);
            Property(p => p.Condicion);
            Property(p => p.Codigo);
            Property(p => p.AfiUatre);
            Property(p => p.Rural);            
        }

    }
}
