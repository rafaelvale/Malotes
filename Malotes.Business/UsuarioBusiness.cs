using Malotes.DAL;
using Malotes.Entity;
using System;
using System.Collections.Generic;
using System.Web;

namespace Malotes.Business
{
    public class UsuarioBusiness
    {

        public static Usuario ValidarUsuarioSenha(String login, String senha)
        {
            Usuario oUsuario = new UsuarioDAO().ValidarAcesso(login, senha, HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]);

            if(oUsuario == null)
            {
                throw new MyException("Combinação de usuário e senha inválidos");
            }

            if (oUsuario.Bloqueado)
            {
                throw new MyException("Usuário bloqueado devido as tentativas inválidas de acesso");
            }

            if (!oUsuario.Ativo)
            {
                throw new MyException("Usuário desativado");
            }

            oUsuario.Filial = new FilialBusiness().ObterFilialPorIdUsuario(oUsuario.UsuarioId);
            oUsuario.Perfil = new PerfilBusiness().ObterPorIdUsuario(oUsuario.UsuarioId);

            return oUsuario;
        }

        static Boolean ValidarSenhaAtual(String senhaAtual, Usuario usuario)
        {
            return new UsuarioDAO().ValidarSenhaAtual(senhaAtual, usuario.UsuarioId);
        }

        public static void AlterarSenha(String senhaAtual, String novaSenha, String confirmarSenha, Usuario usuario)
        {
            if (String.IsNullOrWhiteSpace(senhaAtual) || String.IsNullOrWhiteSpace(novaSenha) || String.IsNullOrWhiteSpace(confirmarSenha))
                throw new MyException("Todos os campos da seção segurança são obrigatórios");

            if (String.Compare(senhaAtual, novaSenha, StringComparison.Ordinal) == 0)
                throw new MyException("A nova senha não pode ser igual a senha atual");

            if (String.Compare(novaSenha, confirmarSenha, StringComparison.Ordinal) != 0)
                throw new MyException("A nova senha não corresponde com a confirmação");

            if (novaSenha.Length < 6)
                throw new MyException("A nova senha é muito curta");

            if (!ValidarSenhaAtual(senhaAtual, usuario))
                throw new MyException("A senha atual não corresponde com a senha cadastrada");

            new UsuarioDAO().AtualizarSenha(novaSenha, usuario.UsuarioId);
        }
        public static Usuario ObterPorId(Int32 idUsuario)
        {
            Usuario oUsuario = new UsuarioDAO().ObterPorId(idUsuario);
            oUsuario.Filial = new FilialBusiness().ObterFilialPorIdUsuario(oUsuario.UsuarioId);
            oUsuario.Perfil = new PerfilBusiness().ObterPorIdUsuario(oUsuario.UsuarioId);

            return oUsuario;
        }
        public static void AtualizarEmail(String email, Usuario usuario)
        {
            if(email.Contains("@"))
                throw new MyException("Informe o email sem o @");

            if (email.Contains("rohr"))
                throw new MyException("Informe o email sem o domínio");

            if (email.Contains(".com.br"))
                throw new MyException("Informe o email sem o domínio");

            if (!String.IsNullOrEmpty(email))
                email = String.Format("{0}@rohr.com.br", email.Trim());
            else
                email = String.Empty;

            new UsuarioDAO().AtualizarEmail(email, usuario.UsuarioId);

            usuario.Email = email;

        }

        public static List<Usuario> ObterTodos()
        {
            return new UsuarioDAO().ObterTodos();
        }
    }
}
