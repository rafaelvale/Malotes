using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malotes.Entity
{
    class UsuarioPerfil
    {
        public Int32 UsuarioXPerfilId { get; set; }
        public Int32 UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public Int32 PerfilId { get; set; }
        public Perfil Perfil { get; set; }
        public DateTime DataCadastro { get; set; }
        public Boolean Ativo { get; set; }
        public DateTime? DataDesativacao { get; set; }
    }
}
