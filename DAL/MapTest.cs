using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;

namespace DAL
{
    public class MapTest : ClassMapping<BE.Test>
    {
        public MapTest()
        {
            Id(x => x.TestId, id =>
            {
                id.Generator(
                    Generators.Identity
                    );
            });
            //Property(p => p.Fecha, m =>
            //{
            //    m.Formula("GETDATE()");
            //});
            Property(p => p.Fecha);
        }

    }
}

