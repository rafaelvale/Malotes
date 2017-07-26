using Malotes.Data;
using Malotes.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Malotes.DAL
{
    public class PerfilDAO
    {
        readonly DbHelper _dbHelper = new DbHelper("Malotes");

        public List<Perfil> ObterPorIdUsuario(Int32 idUsuario)
        {
            List<Perfil> listPerfil = new List<Perfil>();

            DbParametros parametros = new DbParametros();
            parametros.Adicionar(new DbParametro("@idUsuario", idUsuario));

            using (SqlDataReader dataReader = ((SqlDataReader)_dbHelper.ExecutarDataReader("GetPerfil", parametros, CommandType.StoredProcedure)))
            {
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Perfil perfil = new Perfil
                        {
                            PerfilId = Int32.Parse(dataReader["PerfilId"].ToString()),
                            Descricao = dataReader["descricao"].ToString()

                        };
                        listPerfil.Add(perfil);
                    }
                    dataReader.Close();
                    _dbHelper.CloseConnection();
                    dataReader.Dispose();
                }
                return listPerfil;
            }
        }
        public Perfil ObterPorId(Int32 idPerfil)
        {
            Perfil oPerfil = null;

            DbParametros parametros = new DbParametros();
            parametros.Adicionar(new DbParametro("@IdPerfil", idPerfil));

            using (SqlDataReader dataReader = ((SqlDataReader)_dbHelper.ExecutarDataReader("GetPerfilById", parametros, CommandType.StoredProcedure)))
            {
                if (dataReader.Read())
                {
                    oPerfil = new Perfil
                    {
                        PerfilId = dataReader.GetInt32(dataReader.GetOrdinal("PerfilId")),
                        Descricao = dataReader.GetString(dataReader.GetOrdinal("Descricao"))
                    };
                }

                dataReader.Close();
                dataReader.Dispose();
                _dbHelper.CloseConnection();

                return oPerfil;
            }
        }
    }
}
