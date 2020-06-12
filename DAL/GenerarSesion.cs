using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;

namespace DAL
{
    public class GenerarSesion
    {

        #region ATRIBUTOS
        private ISessionFactory _sessionFactory;
        private ISession _session;
        #endregion

        #region PROPIEDADES
        /// <summary>
        /// Propiedad sesión de NHibernate
        /// </summary>
        public ISession Session
        {
            get
            {
                if (null == this._session || !this._session.IsOpen)
                    this._session = this.OpenSession();

                return _session;

            }
            set { this._session = value; }
        }
        #endregion

        #region CONSTRUCTOR SINGLETON
        //public static GenerarSesion instance { get; private set; }
        private static volatile GenerarSesion instance;
        private static object syncRoot = new Object();
        GenerarSesion()
        {
        }

        public static GenerarSesion Instancia
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new GenerarSesion();
                    }
                }

                return instance;
            }
        }
        #endregion

        #region METODOS CONFIGURACIÓN
        /// <summary>
        /// Método que abre la sesión
        /// </summary>
        /// <returns>La sesión activa</returns>
        private ISession OpenSession()
        {
            //Open and return the nhibernate session
            return this.SessionFactory().OpenSession();
        }

        /// <summary>
        /// Método que nos sirve para testear si tenemos conexión con la base de datos
        /// </summary>
        /// <returns>True si hay conexión y false en caso contrario</returns>
        public bool TestConnection()
        {
            ISessionFactory _iSession = this.SessionFactory();

            if (null == _iSession)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Método que crea la session factory
        /// </summary>
        public ISessionFactory SessionFactory()
        {
            try
            {
                //Siempre que no la hayamos creado antes
                if (_sessionFactory == null)
                {
                    var cfg = new NHibernate.Cfg.Configuration();
                    cfg.Configure();

                    var mapper = new ModelMapper();

                    //Especifico uno por unos los mapeos de las entidades
                    //mapper.AddMappings(typeof(BE.AfiliadoDatos).Assembly.GetTypes());
                    mapper.AddMapping<MapAfiBeneficiariosOspep>();
                    mapper.AddMapping<MapTest>();
                    mapper.AddMapping < MapAuditoriaWS>();
                    mapper.AddMapping<MapAfiBeneficiarios>();
                    
                    var mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();

                    cfg.AddMapping(mapping);

                    _sessionFactory = cfg.BuildSessionFactory();
                }
                return _sessionFactory;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        #endregion

    }
}

