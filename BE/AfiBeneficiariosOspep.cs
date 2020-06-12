using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BE
{
    public class AfiBeneficiariosOspep
    {
        public AfiBeneficiariosOspep()
        {
        }
        public virtual double Correlativo { get; set; }
        public virtual double Cuil { get; set; }
        public virtual byte Tipo { get; set; }
        public virtual string TipoDoc { get; set; }
        public virtual double Documento { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Resultado { get; set; }

        public virtual string Parentesco { get; set; }
        public virtual string Sexo { get; set; }
        public virtual string FechaNac { get; set; }
        public virtual double BocaExpendio { get; set; }
        public virtual string BE { get; set; }
        public virtual string Afiliado { get; set; }
        public virtual string Condicion { get; set; }

        public virtual int Codigo { get; set; }
    }
}
