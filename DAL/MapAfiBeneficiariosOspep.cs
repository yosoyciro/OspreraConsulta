using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;

namespace DAL
{
    public class MapAfiBeneficiariosOspep : ClassMapping<BE.AfiBeneficiariosOspep>
    {
        public MapAfiBeneficiariosOspep()
        {
            Id(x => x.Correlativo, id =>
            {
                id.Generator(
                    Generators.Identity
                    );
            });
            Property(p => p.Cuil);
            Property(p => p.Tipo);
            Property(p => p.TipoDoc, m =>
            {
                m.Formula("dbo.TipoDoc(Tipo)");
            });
            Property(p => p.Documento);
            Property(p => p.Nombre);
            Property(p => p.Resultado, m =>{
                m.Formula("dbo.Cobertura(Correlativo)");
            });
            Property(p => p.Parentesco, m => {
                m.Formula("dbo.DescribeParentesco(Codigo)");
            });
            Property(p => p.Sexo);
            Property(p => p.FechaNac, m => {
                m.Formula("dbo.FechaClarion(FechaNac)");
            });
            Property(p => p.BocaExpendio);
            Property(p => p.BE, m => {
                m.Formula("dbo.DescribeBocaExpendio(BocaExpendio)");
            });
            Property(p => p.Afiliado, m => {
                m.Formula("dbo.DescribeTipoAfiliado(Codigo)");
            });
            Property(p => p.Condicion);
            Property(p => p.Codigo);
        }
        
    }
}
