using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocadoraDeImoveis.Models
{
    [Table("Contratos")]
    public class Contrato:BaseModel
    {
        private DateTime DataVencimento { get; set; }
        private int IdImovel { get; set; }
        private int IdLocatario { get; set; }
        private double ValorAluguel { get; set; }
        private double ComissaoCorretor { get; set; }
    }
}
