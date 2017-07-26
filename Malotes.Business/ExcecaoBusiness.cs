using Malotes.DAL;
using Malotes.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Malotes.Business
{
    public class ExcecaoBusiness
    {
        public static void Adicionar(Exception excecao, String url)
        {
            try
            {
                Int32 idUsuario = 0;
                Int32 idPerfil = 0;

                Object sessao = HttpContext.Current.Session["usuario"];
                if (sessao != null)
                    idUsuario = ((Usuario)sessao).UsuarioId;

                sessao = HttpContext.Current.Session["perfil"];
                if (sessao != null)
                    idPerfil = Convert.ToInt32(sessao);

                new ExcecaoDAO().Adicionar(
                    excecao,
                    url,
                    idUsuario,
                    idPerfil,
                    excecao.GetType().Name == "MyException" ? 1 : 2);
            }
            catch (Exception)
            {

            }
        }
    }
}
