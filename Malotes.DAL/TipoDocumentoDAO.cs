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
    public class TipoDocumentoDAO
    {
        readonly DbHelper _dbHelper = new DbHelper("Malotes");

        public List<Tipodocumento> ObterTipoDoc()
        {
            List<Tipodocumento> oTipoDocumento = null;


            using (SqlDataReader dataReader = (SqlDataReader)_dbHelper.ExecutarDataReader("GetTipoDocumento", CommandType.StoredProcedure))
            {
                if (dataReader.HasRows)
                {
                    oTipoDocumento = new List<Tipodocumento>();
                    while(dataReader.Read())
                    {
                        oTipoDocumento.Add(new Tipodocumento
                        {
                            IdTipoDoc = Int32.Parse(dataReader["id"].ToString()),
                            TipoDoc = dataReader["TipoDoc"].ToString()
                        });
                        
                    }
                }

                dataReader.Close();
                dataReader.Dispose();
                _dbHelper.CloseConnection();

                return oTipoDocumento;
            }
        }
        public List<Urgencia> ObterUrgencia()
        {
            List<Urgencia> oTipoUrgencia = null;


            using (SqlDataReader dataReader = (SqlDataReader)_dbHelper.ExecutarDataReader("GetUrgencia", CommandType.StoredProcedure))
            {
                if (dataReader.HasRows)
                {
                    oTipoUrgencia = new List<Urgencia>();
                    while (dataReader.Read())
                    {
                        oTipoUrgencia.Add(new Urgencia
                        {
                            Id = Int32.Parse(dataReader["Id"].ToString()),
                            TipoUrgencia = dataReader["Urgencia"].ToString()
                        });

                    }
                }

                dataReader.Close();
                dataReader.Dispose();
                _dbHelper.CloseConnection();

                return oTipoUrgencia;
            }
        }

     

    }
}
