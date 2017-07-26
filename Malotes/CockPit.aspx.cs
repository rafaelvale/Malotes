using Malotes.Business;
using Malotes.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Malotes
{
    public partial class CockPit : Page
    {

        public int PaginaAtual
        {
            get
            {
                object o = ViewState["_PaginaAtual"];
                if (o == null)
                    return 0;
                return (int)o;
            }

            set
            {
                if (value < 0)
                    ViewState["_PaginaAtual"] = 0;
                else
                    ViewState["_PaginaAtual"] = value;
            }
        }


        //void ExibirModal()
        //{
        //    if (new Util().GetSessaoUsuario().ExibirModal)
        //    {
        //        UsuarioBusiness.AtualizarExibicaoModal(new Util().GetSessaoUsuario());
        //        Page.ClientScript.RegisterStartupScript(GetType(), "script1", "<script>$(document).ready(function () {$('#modal-content').modal();})</script>");
        //    }
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Usuario sessaoUsuario = new Util().GetSessaoUsuario();
                Int32 idPerfilAtivo = new Util().GetSessaoPerfilAtivo();
                MontarTela(sessaoUsuario, idPerfilAtivo);

                if (!Page.IsPostBack)
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "script", "<script>$(document).ready(function () {$('.container-fluid').delay(300).fadeIn();})</script>");
                   // ExibirModal();
                }
                else
                    Page.ClientScript.RegisterStartupScript(GetType(), "script", "<script>$(document).ready(function () {$('.container-fluid').delay(10).fadeIn();})</script>");

            }
            catch (Exception ex)
            {
                var msg = "<script type=\"text/javascript\">alert('" + ex.Message.Replace("'", "").Replace(Environment.NewLine, string.Empty) + "')</script>";
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", msg);
                
                ExcecaoBusiness.Adicionar(ex, HttpContext.Current.Request.Url.AbsolutePath);
            }


        }

        

        void MontarTela(Usuario usuario, Int32 idPerfil)
        {
            if(idPerfil == 2)
            {
                btnEnviar.Visible = false;
                btnRec.Visible = false;
                btnFac.Visible = true;



            }
            else if(idPerfil == 3)
            {

                btnEnviar.Visible = true;
                btnRec.Visible = true;
                btnFac.Visible = false;

            }
            else
            {

                btnEnviar.Visible = true;
                btnRec.Visible = true;
                btnFac.Visible = true;
            }
        }

        
    }
}