using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Malotes.Data
{
    class DbGerenciador
    {
        internal static IDbConnection PegarConexao(String nomeConexao)
        {
            return PegarConexao(nomeConexao, "sqlserver");
        }
        internal static IDbConnection PegarConexao(String nomeConexao, String servidor)
        {
            IDbConnection conexao = new SqlConnection();

            conexao.ConnectionString = PegarStringConexao(nomeConexao);
            conexao.Open();
            return conexao;
        }
        static String PegarStringConexao(String nomeConexao)
        {
            return ConfigurationManager.ConnectionStrings[nomeConexao].ConnectionString;
        }
    }
}
