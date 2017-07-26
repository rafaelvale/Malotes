using Malotes.Business;
using Malotes.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Malotes.MasterPage
{
    public partial class MasterDefault : System.Web.UI.MasterPage
    {
        protected String menuUsuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Usuario sessaoUsuario = new Util().GetSessaoUsuario();
                Int32 idPerfilAtivo = new Util().GetSessaoPerfilAtivo();
                MontarMenu(sessaoUsuario, idPerfilAtivo);

                Page.Title = String.Format("Malotes - {0}", new PerfilBusiness().ObterPorId(idPerfilAtivo).Descricao);
            }
            catch (Exception ex)
            {
                ExcecaoBusiness.Adicionar(ex, HttpContext.Current.Request.Url.AbsolutePath);
                Response.Redirect(ResolveUrl("~/Login.aspx?error=true"), false);
            }
        }

        void MontarMenu(Usuario usuario, Int32 idPerfil)
        {
            menuUsuario = MontarMenuUsuario(usuario, idPerfil);


        }


        private String MontarMenuUsuario(Usuario usuario, Int32 idPerfil)
        {
            StringBuilder menu = new StringBuilder();
            menu.Append("<li class=\"dropdown\"><a  href=\"#\" class=\"dropdown-toggle\" data-toggle=\"dropdown\">");
            menu.Append(usuario.PrimeiroNome);
            menu.Append(" <img src='../../Content/Image/img1.png' width='8' height='6'/>");
            menu.Append("</a>");
            menu.Append("<ul class=\"dropdown-menu\">");
            menu.Append("<li class=\"nav-header\">Perfil</li>");

            foreach (Perfil perfil in usuario.Perfil)
            {
                menu.Append(perfil.PerfilId == idPerfil
                    ? String.Format("<li class=\"active\"><a href=../../Redirecionar.aspx?p={0}>{1}</a></li>",
                        CriptografiaBusiness.Criptografar(perfil.PerfilId.ToString()), perfil.Descricao)
                    : String.Format("<li><a href=../../Redirecionar.aspx?p={0}>{1}</a></li>",
                        CriptografiaBusiness.Criptografar(perfil.PerfilId.ToString()), perfil.Descricao));
            }

            menu.Append("<li class=\"divider\"></li>");
            menu.Append(String.Format("<li><a target=\"_blank\" href=\"../../Redirecionar.aspx?p={0}\">Configurações da Conta</a></li>", CriptografiaBusiness.Criptografar("50")));
            menu.Append("<li class=\"divider\"></li>");
            menu.Append(String.Format("<li><a href=\"../../Redirecionar.aspx?p={0}\">Sair</a></li>", CriptografiaBusiness.Criptografar("0")));
            menu.Append("</ul>");
            menu.Append("</li>");

            return menu.ToString();
        }
    }
}