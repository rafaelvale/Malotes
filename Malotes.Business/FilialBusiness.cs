using Malotes.DAL;
using Malotes.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malotes.Business
{
    public class FilialBusiness
    {
        public List<Filial> ObterFilialPorIdUsuario(Int32 idUsuario)
        {
            List<Filial> listFilial = new FilialDAO().ObterFilialPorIdUsuario(idUsuario);

            if (listFilial == null || listFilial.Count == 0)
                throw new MyException("Não foi possível recuperar a filial do usuário");

            return listFilial;
        }
        public Filial ObterFilial(Int32 idFilial)
        {
            return new FilialDAO().ObterPorId(idFilial);
        }

        public List<Filial> ObterFilialDest()
        {
            return new FilialDAO().ObterFilialDestinatario();
            
        }
    }
}
