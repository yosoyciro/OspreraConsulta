using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class AuditoriaWS
    {
        public AuditoriaWS()
        {
        }

        public virtual int AuditoriaWSId { get; set; }
        public virtual string Usuario { get; set; }
        public virtual DateTime FechaHora { get; set; }
        public virtual string TipoDoc { get; set; }
        public virtual double NroDoc { get; set; }
        public virtual string Respuesta { get; set; }
    }
}
