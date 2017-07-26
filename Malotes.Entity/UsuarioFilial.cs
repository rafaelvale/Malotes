using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malotes.Entity
{
    class UsuarioFilial
    {
        public Int32 UsuarioXFilialId { get; set; }
        public Int32 UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public Int32 FilialId { get; set; }
        public Filial Filial { get; set; }
        public DateTime DataCadastro { get; set; }
        public Boolean Ativo { get; set; }
        public DateTime? DataDesativacao { get; set; }
    }
}
