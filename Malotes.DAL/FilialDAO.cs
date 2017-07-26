using Malotes.Data;
using Malotes.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malotes.DAL
{
    public class FilialDAO
    {
        readonly DbHelper _dbHelper = new DbHelper("Malotes");

        public Filial ObterPorId(Int32 id)
        {
            DbParametros parametros = new DbParametros();
            parametros.Adicionar(new DbParametro("@IdFilial", id));
            Filial filial = null;

            using (SqlDataReader dataReader = (SqlDataReader)_dbHelper.ExecutarDataReader("GetFilial", parametros, CommandType.StoredProcedure))
            {
                if (dataReader.Read())
                {
                    filial = new Filial
                    {
                        FilialId = Int32.Parse(dataReader["FilialId"].ToString()),
                        CodigoPMWeb = Int32.Parse(dataReader["CodigoPMWeb"].ToString()),
                        DataCadastro = DateTime.Parse(dataReader["dataCadastro"].ToString()),
                        DescricaoCompleta = dataReader["DescricaoCompleta"].ToString()
                    };
                }

                dataReader.Close();
                _dbHelper.CloseConnection();
                dataReader.Dispose();

                return filial;
            }
        }

        public List<Filial> ObterFilialPorIdUsuario(Int32 idUsuario)
        {
            List<Filial> listFiliais = new List<Filial>();
            DbParametros parametros = new DbParametros();
            parametros.Adicionar(new DbParametro("@idUsuario", idUsuario));

            using (SqlDataReader dataReader = (SqlDataReader)_dbHelper.ExecutarDataReader("GetFilialByIdUsuario", parametros, CommandType.StoredProcedure))
            {
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Filial filial = new Filial
                        {
                            FilialId = dataReader.GetInt32(dataReader.GetOrdinal("FilialId")),
                            CodigoPMWeb = dataReader.GetInt32(dataReader.GetOrdinal("CodigoPMWeb")),
                            DataCadastro = dataReader.GetDateTime(dataReader.GetOrdinal("DataCadastro")),
                        };

                        listFiliais.Add(filial);
                    }
                }

                dataReader.Close();
                _dbHelper.CloseConnection();
                dataReader.Dispose();

                return listFiliais;
            }
        }

        public List<Filial> ObterFilialDestinatario()
        {
            List<Filial> oFilialDest = null;


            using (SqlDataReader dataReader = (SqlDataReader)_dbHelper.ExecutarDataReader("GetFilialDest", CommandType.StoredProcedure))
            {
                if (dataReader.HasRows)
                {
                    oFilialDest = new List<Filial>();
                    while (dataReader.Read())
                    {
                        oFilialDest.Add(new Filial
                        {
                            FilialId = Int32.Parse(dataReader["FilialId"].ToString()),
                            DescricaoAbreviada1 = dataReader["DescricaoAbreviada1"].ToString()
                        });

                    }
                }

                dataReader.Close();
                dataReader.Dispose();
                _dbHelper.CloseConnection();

                return oFilialDest;
            }
        }
    }
}
