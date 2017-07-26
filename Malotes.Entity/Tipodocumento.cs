using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malotes.Entity
{
    public class Tipodocumento
    {
        public Int32 IdTipoDoc { get; set; }
        public String TipoDoc { get; set; }

        public Tipodocumento() { }

        public Tipodocumento(Int32 idTipoDoc)
        {
            IdTipoDoc = idTipoDoc;
        }

    }


}
