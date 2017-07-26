using Malotes.Entity;
using System;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Text.RegularExpressions;



namespace Malotes.Business
{
    public class Util
    {
        public enum TipoMensagem
        {
            Informacao, 
            Erro, 
            Alerta
        }

        public Usuario GetSessaoUsuario()
        {
            Object sessaoUsuario = HttpContext.Current.Session["usuario"];
            if (sessaoUsuario == null)
                throw new MyException("Não foi possivel recuperar a sessão do usuário");

            return (Usuario)sessaoUsuario;
        }

        public Int32 GetSessaoPerfilAtivo()
        {
            Object sessaoPerfilAtivo = HttpContext.Current.Session["perfil"];
            if (sessaoPerfilAtivo == null)
                throw new MyException("Não foi possível recuperar a sessão do perfil do usuário");

            return Int32.Parse(sessaoPerfilAtivo.ToString());
        }

        public static void ExibirMensagem(Label label, string mensagem, TipoMensagem tipoMensagem)
        {
            label.Text = mensagem;
            label.Visible = true;

            switch (tipoMensagem)
            {
                case TipoMensagem.Informacao:
                    label.CssClass = "alert alert-info fade.in";
                    break;
                case TipoMensagem.Erro:
                    label.CssClass = "alert alert-error fade.in";
                    break;
                case TipoMensagem.Alerta:
                    label.CssClass = "alert alert-danger fade.in";
                    break;
                default:
                    label.CssClass = "alert";
                    break;
            }
        }

        //public static void ObterServidorDados(Label label)
        //{
        //    label.Visible = System.Configuration.ConfigurationManager.ConnectionStrings["Malotes"].ConnectionString.Contains("10.11.5.26");

        //    label.Text = "DATABASE - HOMOLOGAÇÃO";
        //}

        public static String LimparDominioEmail(String email)
        {
            return email.Contains("@rohr") ? email.Substring(0, email.IndexOf("@", StringComparison.Ordinal)) : email;
        }


    }
}
