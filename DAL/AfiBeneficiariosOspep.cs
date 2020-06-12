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
    public class AfiBeneficiariosOspep
    {
        #region Singleton
        private static ISession session;
        public static DAL.AfiBeneficiariosOspep instancia = new DAL.AfiBeneficiariosOspep();

        private AfiBeneficiariosOspep()
        {
            session = DAL.GenerarSesion.Instancia.Session;
        }
        #endregion

        public List<BE.AfiBeneficiariosOspep> BuscarPorNroDocumento(double pNroDocumento)
        {
            UInt64 nrodocumento = Convert.ToUInt64(pNroDocumento);
            List<BE.AfiBeneficiariosOspep> afiBeneficiariosOspeps;
            int indice = 0;
            int registros = 0;
            List<int> codigos = new List<int>();
            do
            {
                indice += 1;
                switch (indice)
                {
                    case 1:
                        codigos.Add(27);
                        codigos.Add(28);
                        codigos.Add(29);
                        codigos.Add(77);

                        afiBeneficiariosOspeps = session.Query<BE.AfiBeneficiariosOspep>()
                            .Where(a => a.Documento == pNroDocumento)
                            .Where(a => a.Condicion == "Si")
                            .Where(a => !codigos.Contains(a.Codigo)).ToList();

                        registros = afiBeneficiariosOspeps.Count();
                        codigos.Clear();
                        break;

                    case 2:
                        codigos.Add(77);
                        afiBeneficiariosOspeps = session.Query<BE.AfiBeneficiariosOspep>()
                            .Where(a => a.Documento == nrodocumento && a.Condicion == "Si")
                            .Where(a => codigos.Contains(a.Codigo)).ToList();
                        registros = afiBeneficiariosOspeps.Count();
                        codigos.Clear();
                        break;

                    case 3:
                        codigos.Add(27);
                        codigos.Add(28);

                        afiBeneficiariosOspeps = session.Query<BE.AfiBeneficiariosOspep>()
                            .Where(a => a.Documento == nrodocumento && a.Condicion == "Si")
                            .Where(a => codigos.Contains(a.Codigo)).ToList();
                        registros = afiBeneficiariosOspeps.Count();
                        codigos.Clear();
                        break;

                    case 4:
                        codigos.Add(29);
                        afiBeneficiariosOspeps = session.Query<BE.AfiBeneficiariosOspep>()
                            .Where(a => a.Documento == nrodocumento && a.Condicion == "Si")
                            .Where(a => codigos.Contains(a.Codigo)).ToList();
                        registros = afiBeneficiariosOspeps.Count();
                        codigos.Clear();
                        break;

                    case 5:
                        codigos.Add(27);
                        codigos.Add(28);
                        codigos.Add(29);
                        codigos.Add(77);

                        afiBeneficiariosOspeps = session.Query<BE.AfiBeneficiariosOspep>()
                            .Where(a => a.Documento == nrodocumento && a.Condicion == "Ap")
                            .Where(a => !codigos.Contains(a.Codigo)).ToList();
                        registros = afiBeneficiariosOspeps.Count();
                        codigos.Clear();
                        break;

                    case 6:
                        codigos.Add(77);
                        afiBeneficiariosOspeps = session.Query<BE.AfiBeneficiariosOspep>()
                            .Where(a => a.Documento == nrodocumento && a.Condicion == "Ap")
                            .Where(a => codigos.Contains(a.Codigo)).ToList();
                        registros = afiBeneficiariosOspeps.Count();
                        codigos.Clear();
                        break;

                    case 7:
                        codigos.Add(27);
                        codigos.Add(28);
                        afiBeneficiariosOspeps = session.Query<BE.AfiBeneficiariosOspep>()
                            .Where(a => a.Documento == nrodocumento && a.Condicion == "Ap")
                            .Where(a => codigos.Contains(a.Codigo)).ToList();
                        registros = afiBeneficiariosOspeps.Count();
                        codigos.Clear();
                        break;

                    case 8:
                        codigos.Add(29);
                        afiBeneficiariosOspeps = session.Query<BE.AfiBeneficiariosOspep>()
                            .Where(a => a.Documento == nrodocumento && a.Condicion == "Ap")
                            .Where(a => codigos.Contains(a.Codigo)).ToList();
                        registros = afiBeneficiariosOspeps.Count();
                        codigos.Clear();
                        break;

                    case 9:
                        afiBeneficiariosOspeps = session.Query<BE.AfiBeneficiariosOspep>()
                            .Where(a => a.Documento == nrodocumento).ToList();
                        registros = afiBeneficiariosOspeps.Count();
                        break;

                    default:
                        afiBeneficiariosOspeps = session.Query<BE.AfiBeneficiariosOspep>()
                            .Where(a => a.Documento == nrodocumento).ToList();
                        registros = afiBeneficiariosOspeps.Count();

                        if (registros == 0)
                        {
                            //afiBeneficiariosOspeps.Add(new BE.AfiBeneficiariosOspep { Nombre = "* Documento NO figura en Padrón *", Resultado = "* Documento NO figura en Padrón *" });
                            //registros = 1;
                            AfiliadoNoEncontrado(ref afiBeneficiariosOspeps, ref registros);
                        }
                        break;
                }

            } while (registros == 0);

            //Grabo la auditoria
            AuditoriaWS(afiBeneficiariosOspeps, nrodocumento);

            return afiBeneficiariosOspeps;
        }

        private void AuditoriaWS(List<BE.AfiBeneficiariosOspep> pAfiBeneficiariosOspeps, UInt64 pNroDocumento)
        {
            CRUDAuditoriaWS.instancia.Agregar(pAfiBeneficiariosOspeps[0], pNroDocumento);
        }

        private void AfiliadoNoEncontrado(ref List<BE.AfiBeneficiariosOspep> pAfiBeneficiarioOspeps, ref int pRegistros)
        {
            string mensaje = "* Documento NO figura en Padrón *";
            byte[] bytes = Encoding.Default.GetBytes(mensaje);
            mensaje = Encoding.GetEncoding(1252).GetString(bytes);
            pAfiBeneficiarioOspeps.Add(new BE.AfiBeneficiariosOspep { Nombre = mensaje , Resultado = "* Documento NO figura en Padrón *" });
            pRegistros = 1;
        }

    }
}

