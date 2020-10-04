using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocadoraDeImoveis.Models
{
    [Table("Contratos")]
    class Contrato:BaseModel
    {
        public DateTime DataVencimento { get; set; }
        public int IdImovel { get; set; }
        public int IdLocatario { get; set; }
        public double ValorAluguel { get; set; }
        public double ComissaoCorretor { get; set; }
        public int IdCorretor { get; set; }
    }
}
