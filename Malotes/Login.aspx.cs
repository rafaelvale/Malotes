using Malotes.Business;
using Malotes.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Malotes
{
    public partial class Login : Page
    {
        private void ValidarUsuarioSenha()
        {
            try
            {
                Usuario usuario = UsuarioBusiness.ValidarUsuarioSenha(txtUsuario.Text, txtSenha.Text);

                if (!usuario.Ativo)
                    lblMensagem.Text = "Usuário desativado";
                else if (usuario.PrimeiroAcesso)
                {
                    Session["usuario"] = usuario;
                    SetarPerfil(usuario);

                    FormsAuthenticationTicket o = new FormsAuthenticationTicket(usuario.UsuarioId.ToString(), false, 40);
                    FormsAuthentication.Encrypt(o);
                    FormsAuthentication.RedirectFromLoginPage(usuario.UsuarioId.ToString(), false);
                    Response.Redirect("ConfiguracoesConta.aspx", false);
                }
                else
                {
                    Session["usuario"] = usuario;
                    SetarPerfil(usuario);
                    new AuditoriaLogBusiness().AdicionarLogLogin(Request.Browser);

                    FormsAuthenticationTicket o = new FormsAuthenticationTicket(usuario.UsuarioId.ToString(), false, 40);
                    FormsAuthentication.Encrypt(o);
                    FormsAuthentication.RedirectFromLoginPage(usuario.UsuarioId.ToString(), false);
                    Response.Redirect(String.Format("Redirecionar.aspx?p={0}", CriptografiaBusiness.Criptografar("99")), false);
                } 
            }
            catch (MyException ex )
            {
                lblMensagem.Text = ex.Message;
                ExcecaoBusiness.Adicionar(ex, HttpContext.Current.Request.Url.AbsolutePath);

            }
            catch(Exception ex)
            {
                lblMensagem.Text = ex.Message;

                ExcecaoBusiness.Adicionar(ex, HttpContext.Current.Request.Url.AbsolutePath);
            }
        }

        private void SetarPerfil(Usuario usuario)
        {
            if (usuario.Perfil == null || usuario.Perfil.Count == 0)
                throw new MyException("Não foi possível recuperar o perfil do usuário");

            var idPerfil = from p in usuario.Perfil
                           where p.PerfilId == 1
                           select p.PerfilId;

            if (idPerfil.Any())
                Session["perfil"] = 1;
           
        }

        private void VerificarNavegador()
        {
            HttpBrowserCapabilities navegador = Request.Browser;

            if (navegador.Browser != "IE" || navegador.MajorVersion > 9)
                lblNavegador.Visible = false;

            else
            {
                lblNavegador.Text = "O seu navegador não é compatível com o Malotes. Entre em contato com DSI para que seja feita uma atualização.";
                lblNavegador.Visible = true;
                btnAcessar.Enabled = false;
            }
        }
        private void ValidarMultiploAcesso(Int32 idUsuario)
        {
            const string msg = "<script type=\"text/javascript\">alert('Este usuário já está conectado. Será feito logout do usuário conectado.');</script>";
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", msg);
            Dictionary<Int32, string> dic = ((Dictionary<Int32, string>)Application["Sessions"]);
            if(Application["Sessions"] == null)
            {
                dic = new Dictionary<Int32, string>();
                Application.Add("Sessions", dic);
                ((Dictionary<Int32, string>)Application["Sessions"]).Add(idUsuario, Session.SessionID);
            }
            else
            {
                if (dic.ContainsKey(idUsuario))
                {
                    ((Dictionary<Int32, string>)Application["Sessions"]).Remove(idUsuario);
                    ((Dictionary<Int32, string>)Application["Sessions"]).Add(idUsuario, Session.SessionID);
                }
                else
                {
                    ((Dictionary<Int32, string>)Application["Sessions"]).Add(idUsuario, Session.SessionID);
                }
            }
        }
        protected void btnAcessar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarUsuarioSenha();
            }
            catch(Exception ex)
            {
                ExcecaoBusiness.Adicionar(ex, HttpContext.Current.Request.Url.AbsolutePath);
                lblMensagem.Text = ex.Message;

            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                VerificarNavegador();

                if(!IsPostBack && Request.QueryString["reason"] != null && Request.QueryString["reason"] == "@@M$")
                {
                    throw new Exception("Varias sessões com o mesmo usuário não é permitido.");
                }
            }
            catch (Exception ex)
            {
                ExcecaoBusiness.Adicionar(ex, HttpContext.Current.Request.Url.AbsolutePath);
                lblMensagem.Text = ex.Message;

                Session.Abandon();
                Session.Clear();
                FormsAuthentication.SignOut();
            }

        }
    }
}