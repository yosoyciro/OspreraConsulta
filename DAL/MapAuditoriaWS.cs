using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;

namespace DAL
{
    class MapAuditoriaWS : ClassMapping<BE.AuditoriaWS>
    {
        public MapAuditoriaWS()
        {
            Id(x => x.AuditoriaWSId, id =>
            {
                id.Generator(
                    Generators.Identity);
            });

            Property(p => p.Usuario);
            Property(p => p.FechaHora);
            Property(p => p.TipoDoc);
            Property(p => p.NroDoc);
            Property(p => p.Respuesta);
        }
    }
}
