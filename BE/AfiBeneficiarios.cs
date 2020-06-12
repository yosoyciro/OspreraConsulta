using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class AfiBeneficiarios
    {
        public AfiBeneficiarios()
        {
        }
        public virtual int Correlativo { get; set; }
        public virtual double Cuil { get; set; }
        public virtual string Baja { get; set; }
        public virtual string BocaExpendio { get; set; }
        public virtual string Condicion { get; set; }
        public virtual int Codigo { get; set; }
        public virtual string AfiUatre { get; set; }
        public virtual string Rural { get; set; }
    }
}
