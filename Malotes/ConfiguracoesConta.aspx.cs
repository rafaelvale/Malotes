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
    public partial class ConfiguracoesConta : BasePage
    {
        void ExibirAlerta(Usuario usuario)
        {
            if (usuario.PrimeiroAcesso)
            {
                lblAlerta.Text = "Este é o seu primeiro acesso. Para continuar altere a sua senha";
                lblAlerta.Visible = true;

                ckListNotificacoes.Enabled = true;
                panelSenha.Visible = true;
                linkEditarSenha.Visible = false;
                linkEditarNotificacoes.Visible = false;
                panelAcao.Visible = true;
                panelSessaoSenha.Visible = false;
                panelAtividadeConta.Visible = false;
            }
            else
            {
                lblAlerta.Text = String.Empty;
                lblAlerta.Visible = true;
                panelAtividadeConta.Visible = true;
            }
        }
        void CarregarDadosUsuario(Usuario usuario)
        {
            lblNome.Text = String.Format("{0} {1}", usuario.PrimeiroNome, usuario.Sobrenome);
            if (usuario.DataUltimaAlteracaoSenha.HasValue)
                lblDataAlteracaoSenha.Text = String.Format("{0} às {1}", usuario.DataUltimaAlteracaoSenha.Value.ToString("dd/MM/yyy"), usuario.DataUltimaAlteracaoSenha.Value.ToString("HH:mm:ss"));
            lblCadastroUsuario.Text = usuario.DataCadastro.ToString("dd/MM/yyy");
            lblMatricula.Text = usuario.Matricula.ToString();


            lblEmail.Text = usuario.Email ?? "Não informado";
        }

        void CarregarFilialUsuario(Usuario usuario)
        {
            lblFilial.Text = String.Empty;

            lblFilial.Text = usuario.Filial.Count == 1 ? "Filial:" : "Filiais: ";

            for(int i = 0; i < usuario.Filial.Count; i++)
            {
                Filial filial = new FilialBusiness().ObterFilial(usuario.Filial[i].CodigoPMWeb);
                lblFilial.Text += filial.DescricaoCompleta.ToLower();
                if (i != usuario.Filial.Count - 1)
                    lblFilial.Text += " | ";
            }
        }

        void CarregarPerfilUsuario(Usuario usuario)
        {
            lblPerfil.Text = String.Empty;

            lblPerfil.Text = usuario.Perfil.Count == 1 ? "Perfil: " : "Perfis: ";

            for(int i =0; i< usuario.Perfil.Count; i++)
            {
                lblPerfil.Text += usuario.Perfil[i].Descricao;
                if (i != usuario.Perfil.Count - 1)
                    lblPerfil.Text += " | ";
            }
        }
        void AtualizarUsuario()
        {
            Usuario oUsuario = new Util().GetSessaoUsuario();
            UsuarioBusiness.AlterarSenha(txtSenhaAtual.Text, txtNovaSenha.Text, txtConfirmarSenha.Text, oUsuario);
            new AuditoriaLogBusiness().AdicionarLogAlteracaoSenha(Request.Browser);
            //new NotificaoUsuarioBusiness().Atualizar(oUsuario, RecuperarNotificacaoUsuarioEmail());
            new AuditoriaLogBusiness().AdicionarLogAlteracaoNotificao(Request.Browser);

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack) return;

                Usuario oUsuario = UsuarioBusiness.ObterPorId(new Util().GetSessaoUsuario().UsuarioId);
                ExibirAlerta(oUsuario);
                CarregarDadosUsuario(oUsuario);
                CarregarFilialUsuario(oUsuario);
                CarregarPerfilUsuario(oUsuario);

                //CarregarPerfilNotificacoesEmail(oUsuario);

            }
            catch (Exception ex)
            {
                lblAlerta.Text = ex.Message;
                lblAlerta.Visible = true;
                ExcecaoBusiness.Adicionar(ex, HttpContext.Current.Request.Url.AbsolutePath);

            }
        }

        protected void btnContinuar_Click(object sender, EventArgs e)
        {
            try
            {
                AtualizarUsuario();
                Usuario oUsuario = new Util().GetSessaoUsuario();
                oUsuario.PrimeiroAcesso = false;
                Session["usuario"] = oUsuario;

                Response.Redirect(String.Format("Redirecionar.aspx?p={0}", CriptografiaBusiness.Criptografar("99")), false);
            }
            catch (Exception ex)
            {
                lblAlerta.Text = ex.Message;
                lblAlerta.Visible = true;
                ExcecaoBusiness.Adicionar(ex, HttpContext.Current.Request.Url.AbsolutePath);

            }
        }
        protected void btnDesistir_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect(
                    new Util().GetSessaoUsuario().PrimeiroAcesso
                    ? String.Format("Redirecionar.aspx?p={0}", CriptografiaBusiness.Criptografar("0"))
                    : String.Format("Redirecionar.aspx?p={0}", CriptografiaBusiness.Criptografar("99")), false);
            }
            catch (Exception ex)
            {
                ExcecaoBusiness.Adicionar(ex, HttpContext.Current.Request.Url.AbsolutePath);

            }
        }
    }
}