using Malotes.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malotes.Data
{
    public class AuditoriaLogDAO
    {
        readonly DbHelper _dbHelper = new DbHelper("Malotes");

        public List<AuditoriaLog> Obter (Usuario usuario)
        {
            List<AuditoriaLog> listLog = null;

            DbParametros parametros = new DbParametros();

            parametros.Adicionar(new DbParametro("@IdUsuario", usuario.UsuarioId));

            using (SqlDataReader dataReader = (SqlDataReader)_dbHelper.ExecutarDataReader("GetAuditoriaLog", parametros, CommandType.StoredProcedure))
            {
                if (dataReader.HasRows)
                {
                    listLog = new List<AuditoriaLog>();
                    while (dataReader.Read())
                    {
                        listLog.Add(new AuditoriaLog
                        {
                            IdUsuario = dataReader.GetInt32(dataReader.GetOrdinal("IdUsuario")),
                            IdTipoLog = dataReader.GetInt32(dataReader.GetOrdinal("IdTipoLog")),
                            DataCadastro = dataReader.GetDateTime(dataReader.GetOrdinal("DataCadastro")),
                            Descricao = dataReader.GetString(dataReader.GetOrdinal("descricao")),
                            IP = dataReader.GetString(dataReader.GetOrdinal("IP")),
                            NomeMaquina = dataReader.GetString(dataReader.GetOrdinal("NomeMaquina"))

                        });
                    }
                }
                dataReader.Close();
                dataReader.Dispose();
                _dbHelper.CloseConnection();

                return listLog;
            }
        }

        public void Adicionar(Int32 idTipoLog, Int32 idUsuario, Int32 idPerfil, String descricao, String ip, String nomeMaquina, String userWindows,
            String browserType, String browserName, String browserVersion)
        {
            DbParametros parametros = new DbParametros();
            parametros.Adicionar(new DbParametro("@idUsuario", idUsuario));
            parametros.Adicionar(new DbParametro("@idPerfil", idPerfil));
            parametros.Adicionar(new DbParametro("@idTipoLog", idTipoLog));
            parametros.Adicionar(new DbParametro("@Descricao", descricao));
            parametros.Adicionar(new DbParametro("@IP", ip));
            parametros.Adicionar(new DbParametro("@NomeMaquina", nomeMaquina));
            parametros.Adicionar(new DbParametro("@UserWindows", userWindows));
            parametros.Adicionar(new DbParametro("@BrowserType", browserVersion));
            parametros.Adicionar(new DbParametro("@browserName", browserName));
            parametros.Adicionar(new DbParametro("@browserVersion", browserVersion));


            _dbHelper.ExecutarNonQuery("Application_AddAuditoriaLog", parametros, CommandType.StoredProcedure);

        }

    }
}
