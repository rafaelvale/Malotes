using Malotes.Entity;
using System;
using System.Collections.Generic;
using Malotes.DAL;

namespace Malotes.Business
{
    public class PerfilBusiness
    {
        public List<Perfil> ObterPorIdUsuario(Int32 idUsuario)
        {
            List<Perfil> listPerfil = new PerfilDAO().ObterPorIdUsuario(idUsuario);

            if (listPerfil == null)
                throw new MyException("Não foi possível recuperar perfil do usuário");

            return listPerfil;
        }
        public Perfil ObterPorId(Int32 idPerfil)
        {
            return new PerfilDAO().ObterPorId(idPerfil);
        }
    }
}
