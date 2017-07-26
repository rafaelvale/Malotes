using Malotes.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Malotes
{
    public partial class Redirecionar : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if(Request.QueryString["p"] != null)
                {
                    String destino = Request.QueryString["p"];
                    Redirect(CriptografiaBusiness.Descriptografar(destino));
                }
                else
                {
                    RemoverSessao();
                    Redirect("0");
                }
            }
            catch (Exception ex)
            {
                ExcecaoBusiness.Adicionar(ex, HttpContext.Current.Request.Url.AbsolutePath);
            }

        }
        private void Redirect(string destino)
        {
            try
            {
                switch (destino)
                {
                    case "0":
                        new AuditoriaLogBusiness().AdicionarLogLogout(Request.Browser);
                        RemoverSessao();
                        FormsAuthentication.SignOut();
                        Response.Redirect("Signout.aspx", false);
                        break;
                    case "10":
                    case "9":
                    case "8":
                    case "7":
                    case "6":
                    case "5":
                    case "4":
                    case "3":
                    case "2":
                    case "1":
                        {
                            Int32 idPerfil = Int32.Parse(destino);
                            SetarPerfilUsuario(idPerfil);
                            Response.Redirect(ResolveUrl("~/CockPit.aspx"), false);
                        }
                        break;
                    case "99":
                        Response.Redirect(ResolveUrl("~/CockPit.aspx"), false);
                        break;
                    case "50":
                        Response.Redirect(ResolveUrl("~/ConfiguracoesConta.aspx"), false);
                        break;
                    default:
                        Response.Redirect(ResolveUrl("~/Login.aspx?error=true"), false);
                        break;
                }
            }
            catch (Exception ex)
            {
                ExcecaoBusiness.Adicionar(ex, HttpContext.Current.Request.Url.AbsolutePath);
                RemoverSessao();
                Response.Redirect(ResolveUrl("~/Login.aspx?error=true"), false);

            }
        }
        private void RemoverSessao()
        {
            Session["usuario"] = null;
            Session["perfil"] = null;


            Session.RemoveAll();
            Session.Abandon();
        }

        private void SetarPerfilUsuario(Int32 PerfilId)
        {
            Session["perfil"] = null;

            Session["perfil"] = PerfilId;
        }
    }
}