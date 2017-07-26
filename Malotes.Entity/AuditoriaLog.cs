using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malotes.Entity
{
    public class AuditoriaLog
    {
        public Int32 IdLog { get; set; }
        public Int32 IdUsuario { get; set; }
        public Int32 IdTipoLog { get; set; }
        public DateTime DataCadastro { get; set; }
        public String Descricao { get; set; }
        public String IP { get; set; }
        public String NomeMaquina { get; set; }
        
    }
}
