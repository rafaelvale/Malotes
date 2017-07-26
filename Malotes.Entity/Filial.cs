using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malotes.Entity
{
    public class Filial
    {
        public Int32 FilialId { get; set; }
        public String DescricaoCompleta { get; set; }
        public String DescricaoAbreviada1 { get; set; }
        public String DescricaoAbreviada2 { get; set; }
        public Int32 CodigoPMWeb { get; set; }
        public Int32 CodigoMater { get; set; }
        public DateTime DataCadastro { get; set; }
        public Boolean Ativo { get; set; }

        public Filial() { }
        public Filial(Int32 idFilial)
        {
            FilialId = idFilial;
        }
    }
}
