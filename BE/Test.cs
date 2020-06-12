using System;
using System.Runtime.Serialization;

namespace BE
{
    //[Serializable]
    //[DataContract]
    public class Test
    {
        
        public Test()
        {
            //this.Fecha = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        }
        public virtual int TestId { get; set; }
        public virtual DateTime Fecha { get; set; }
    }
}
