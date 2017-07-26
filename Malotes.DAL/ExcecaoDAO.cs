using Malotes.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malotes.DAL
{
    public class ExcecaoDAO
    {
        readonly DbHelper _dbHelper = new DbHelper("Malotes");

        public void Adicionar(Exception exception,String Url, Int32 idUsuario, Int32 idPerfil, Int32 idTipoExcecao)
        {
            Object stackTrace = DBNull.Value;
            if (!String.IsNullOrEmpty(exception.StackTrace))
                exception.StackTrace.ToString();

            DbParametros parametros = new DbParametros();
            parametros.Adicionar(new DbParametro("@Message", exception.Message));
            parametros.Adicionar(new DbParametro("@StackTrace", stackTrace));
            parametros.Adicionar(new DbParametro("@URL", Url));
            parametros.Adicionar(new DbParametro("@IdUsuario", idUsuario));
            parametros.Adicionar(new DbParametro("@IdPerfil", idPerfil));
            parametros.Adicionar(new DbParametro("@IdTipoExcecao", idTipoExcecao));
            _dbHelper.ExecutarNonQuery("Application_AddExcecao", parametros, CommandType.StoredProcedure);

            _dbHelper.CloseConnection();
        }
    }
}
