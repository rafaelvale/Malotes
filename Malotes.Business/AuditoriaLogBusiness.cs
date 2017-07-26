using Malotes.Data;
using Malotes.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Malotes.Business
{
    public class AuditoriaLogBusiness
    {
        public List<AuditoriaLog> ObterLog(Int32 idTipoLog, Usuario usuario)
        {
            return new AuditoriaLogDAO().Obter(usuario);
        }
        public void AdicionarLogLogin(HttpBrowserCapabilities browser)
        {
            const String descricao = "Login";
            AdicionarLog(1, new Util().GetSessaoUsuario().UsuarioId, descricao, browser);
        }
        public void AdicionarLogLogout(HttpBrowserCapabilities browser)
        {
            const String descricao = "Logout";
            AdicionarLog(1, new Util().GetSessaoUsuario().UsuarioId, descricao, browser);
        }
        public void AdicionarLogPrimeiroAcesso(HttpBrowserCapabilities browser)
        {
            const String descricao = "Login - Primeiro Acesso";
            AdicionarLog(4, new Util().GetSessaoUsuario().UsuarioId, descricao, browser);
        }
        public void AdicionarLogAlteracaoSenha(HttpBrowserCapabilities browser)
        {
            const String descricao = "Senha Alterada";
            AdicionarLog(2, new Util().GetSessaoUsuario().UsuarioId, descricao, browser);
        }
        public void AdicionarLogAlteracaoNotificao(HttpBrowserCapabilities browser)
        {
            const String descricao = "Notificações de Email Alterada";
            AdicionarLog(3, new Util().GetSessaoUsuario().UsuarioId, descricao, browser);
        }

        

        public void AdicionarLog(Int32 idTipoLog, Int32 idUsuario, String descricao, HttpBrowserCapabilities browser)
        {
            new AuditoriaLogDAO().Adicionar(idTipoLog, idUsuario, new Util().GetSessaoPerfilAtivo(), descricao,
                HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"],
                Dns.GetHostName(),
                HttpContext.Current.Request.ServerVariables["LOGON_USER"],
                browser.Type,
                browser.Browser,
                browser.Version);
        }
    }
}
