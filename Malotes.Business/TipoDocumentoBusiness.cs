using Malotes.Data;
using Malotes.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malotes.Business
{
    public class TipoDocumentoBusiness
    {
        public List<Tipodocumento> ObterTipos()
        {
            return new TipoDocumentoDAO().ObterTipoDoc();
        }
        public List<Urgencia> ObterTipoUrgencia()
        {
            return new TipoDocumentoDAO().ObterUrgencia();
        }
    }
}
