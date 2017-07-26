using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malotes.Entity
{
    public class Urgencia
    {
        public Int32 Id { get; set; }
        public String TipoUrgencia { get; set; }

        public Urgencia()
        {}
        public Urgencia(Int32 idUrgencia)
        {
            Id = idUrgencia;
        }
    }
}
